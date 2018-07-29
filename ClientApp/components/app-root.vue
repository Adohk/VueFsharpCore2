<template lang="pug">
	#app.container-fluid
		.row
			.col-sm-3
				nav-menu(params="route: route")
			.col-sm-9
				transition(name="fade" mode="out-in" appear)
					router-view
</template>

<script>
	import Vue from "vue";
	const NavMenu = () => import("./nav-menu");

	Vue.component("nav-menu", NavMenu);

	export default {
		data() {
			return {};
		}
	};
</script>

<style>
	.fade-enter-active,
	.fade-leave-active {
		transition: opacity 0.05s;
	}
	.fade-enter,
	.fade-leave-to {
		opacity: 0;
	}
</style>
