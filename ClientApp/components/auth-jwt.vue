<template lang="pug">
	div
		h1 Authorization
		p Login form and JWT Token storage.
		div.form-horizontal
			div.form-group
				label.col-md-2.control-label(for="username") Email
				div.col-md-6
					input.form-control(type="email",id="username",value="",v-model="loginModel.email")
			div.form-group
				label.col-md-2.control-label(for="pass") Password
				div.col-md-6
					input.form-control(type="password",id="pass",value="",v-model="loginModel.password")
			div.form-group
				div.col-sm-offset-2.col-sm-10
					button.btn.btn-default(@click="logIn()", v-if="!isAuth") Login 
					|	 
					button.btn.btn-default(@click="logOut()", v-if="isAuth") LogOut
					|	 
					button.btn.btn-info(@click="test()") Auth Test

		br
		p Model: [Email: {{loginModel.email}}, Pass: {{loginModel.password}}]
		p isAuth: 
			strong {{ isAuth }}
		p Token: 
		strong(style="word-wrap: break-word;") {{ visualToken }}
</template>

<script>
	import { mapActions, mapState } from "vuex";
	export default {
		data() {
			return {
				loginModel: {
					email: "adohk@adohk.com",
					password: "!asdfASDF1234"
				}
			};
		},
		computed: {
			...mapState({
				isAuth: state => state.user.isAuth,
				visualToken: state => state.user.token
			})
		},
		methods: {
			...mapActions(["LOGIN", "LOGOUT", "TEST"]),
			logIn() {
				this.LOGIN(this);
			},
			logOut() {
				this.LOGOUT();
			},
			test() {
				this.TEST(this);
			}
		},
		created() {}
	};
</script>
