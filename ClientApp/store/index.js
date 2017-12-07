import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

// STATE
const state = {
    counter: 0,
    forecasts: []
}

// MUTATIONS
const mutations = {
    MAIN_SET_COUNTER(state, obj) {
        state.counter = obj.counter
    },
    SET_FORECASTS(state, forecasts) {
        state.forecasts = forecasts
    }
}

// ACTIONS
// Check this .then() and lambda for directly mapping response.data, should work though.
// It is bitching to me about the "this" here with await, try without if it doesn't work.
const actions = ({
    SET_COUNTER({ commit }, obj) {
        commit('MAIN_SET_COUNTER', obj)
    },
    async GET_FORECASTS({ commit }) {
        await axios.get('/api/SampleData/WeatherForecasts').then(forecasts => commit('SET_FORECASTS', forecasts.data))
            .catch(console.log(error))
    }
})

export default new Vuex.Store({
    state,
    mutations,
    actions
});