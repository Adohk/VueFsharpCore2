// MUTATIONS
export const mutations = {

    MAIN_SET_COUNTER(state, obj) {
        state.counter = obj.counter
    },

    SET_FORECASTS(state, forecasts) {
        state.forecasts = forecasts
    }

}