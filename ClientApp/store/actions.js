// ACTIONS
export const actions = ({

    SET_COUNTER({ commit }, obj) {
        commit('MAIN_SET_COUNTER', obj)
    },

    async GET_FORECASTS({ commit }, vm) {
        commit('SET_FORECASTS', false)
        await vm.$axios.get('/api/SampleData/WeatherForecasts').then(res => res.data)
            .then(forecasts => commit('SET_FORECASTS', forecasts))
            .catch(error => {
                console.log(error);
                commit('SET_FORECASTS', null);
            })
    }

})