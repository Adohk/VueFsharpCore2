import Vue from "vue";
import VueAxiosPlugin from "vue-axios-plugin";
import router from "./router";
import store from "./store";
import { sync } from "vuex-router-sync";
import App from "components/app-root";

Vue.config.productionTip = false;
Vue.use(VueAxiosPlugin);

sync(store, router);

const app = new Vue({
	store,
	router,
	...App
});

export { app, router, store };
