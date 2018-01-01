import Vue from 'vue'
import Vuex from 'vuex'
import { mutations } from './mutations'
import { actions } from './actions'

Vue.use(Vuex)

// STATE
const state = {
    counter: 0,
    forecasts: [],
    contacts: []
}

export default new Vuex.Store({
    state,
    mutations,
    actions
});