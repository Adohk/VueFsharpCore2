import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// STATE
const state = {
    counter: 0,
		forecasts: [],
}

// MUTATIONS
const mutations = {
    MAIN_SET_COUNTER (state, obj) {
        state.counter = obj.counter
    },
		SET_FORECASTS (state, forecasts) {
			state.forecasts = forceasts
		}
}

// ACTIONS
const actions = ({
    SET_COUNTER ({ commit }, obj) {
        commit('MAIN_SET_COUNTER', obj)
    },
		GET_FORECASTS ({commit}) {
			// ES2017 async/await syntax via babel-plugin-transform-async-to-generator
			// TypeScript can also transpile async/await down to ES5
			try {
					// Check this .then() and lambda for directly mapping response.data, should work though.
					// It is bitching to me about the "this" here with await, try without if it doesn't work.
					let forecasts = await this.$http.get('/api/SampleData/WeatherForecasts').then(res => res.data)
					commit('SET_FORECASTS', forecasts)
			}
			catch (error) {
					console.log(error)
			}
			// Old promise-based approach
			//this.$http
			//    .get('/api/SampleData/WeatherForecasts')
			//    .then(response => {
			//        console.log(response.data)
			//        this.forecasts = response.data
			//    })
			//    .catch((error) => console.log(error))*/
		}
})

export default new Vuex.Store({
    state,
    mutations,
    actions
});
