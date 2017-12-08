import Vue from 'vue'
import Vuex from 'vuex'

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
const actions = ({
    SET_COUNTER({ commit }, obj) {
        commit('MAIN_SET_COUNTER', obj)
    },
    GET_FORECASTS({ commit }, instance) {
        instance.$axios.get('/api/SampleData/WeatherForecasts').then(forecasts => commit('SET_FORECASTS', forecasts.data))
            .catch(error => console.log(error))
    }
})

export default new Vuex.Store({
    state,
    mutations,
    actions
});