// ACTIONS
export const actions = {
	SET_COUNTER({ commit }, obj) {
		commit("MAIN_SET_COUNTER", obj);
	},

	async GET_FORECASTS({ commit }, vm) {
		commit("SET_FORECASTS", false);
		await vm.$axios
			.get("/api/SampleData/WeatherForecasts")
			.then(res => {
				if (res.status != 200) {
					throw new Error(res.data);
				} else {
					return res.data;
				}
			})
			.then(forecasts => commit("SET_FORECASTS", forecasts))
			.catch(error => {
				console.log(error);
				commit("SET_FORECASTS", null);
			});
	},

	async GET_CONTACTS({ commit }, vm) {
		commit("SET_CONTACTS", false);
		await vm.$axios
			.get("/api/DbData/ContactsData")
			.then(res => {
				if (res.status != 200) {
					throw new Error(res.data);
				} else {
					return res.data;
				}
			})
			.then(contacts => commit("SET_CONTACTS", contacts))
			.catch(error => {
				console.log(error);
				alert(error);
				commit("SET_CONTACTS", null);
			});
	},

	async LOGIN({ commit }, vm) {
		commit("SET_USER", false);
		await vm.$axios
			.post("/api/auth/login", vm.loginModel)
			.then(res => {
				if (res.status != 200) {
					throw new Error(res.data);
				} else {
					return res.data;
				}
			})
			.then(token => {
				let user = {
					isAuth: true,
					token: token
				};
				localStorage.setItem("user-token", token);
				commit("SET_USER", user);
			})
			.catch(error => {
				console.log(error);
				alert(error);
				let user = {
					isAuth: false,
					token: null
				};
				commit("SET_USER", user);
			});
	},

	async LOGOUT({ commit }) {
		let user = {
			isAuth: false,
			token: null
		};
		localStorage.removeItem("user-token");
		commit("SET_USER", user);
	},

	async TEST({ commit }, vm) {
		let token = localStorage.getItem("user-token");
		let header = { Authorization: `Bearer ${token}` };
		await vm.$axios
			.get("/api/auth/LoginTest3", { headers: header })
			.then(res => {
				if (res.status != 200) {
					throw new Error(res.data);
				} else {
					return res.data;
				}
			})
			.then(response => alert(response))
			.catch(error => {
				alert(error);
			});
	}
};
