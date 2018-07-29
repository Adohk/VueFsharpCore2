<template lang="pug">
.main-nav
	.navbar.navbar-inverse
		.navbar-header
			button.navbar-toggle(type="button" @click="toggleCollapsed")
				span.sr-only Toggle navigation
				span.icon-bar
				span.icon-bar
				span.icon-bar
			a.navbar-brand(href="/") VueFsharpCore2
		.clearfix
		transition(name="slide")
			.navbar-collapse.collapse.in(v-show="!collapsed" @click="toggleCollapsed")
				ul.nav.navbar-nav
					li(v-for="route in routes")
						router-link(:to="route.path" activeClass="active", exact=true)
							span(:class="route.style" )
							|  {{ route.display }}
</template>

<script>
	import { routes } from "../routes";

	export default {
		data() {
			return {
				routes,
				collapsed: true
			};
		},
		methods: {
			toggleCollapsed: function(event) {
				this.collapsed = !this.collapsed;
			}
		}
	};
</script>

<style>
	.slide-enter-active,
	.slide-leave-active {
		transition: max-height 0.35s;
	}

	.slide-enter,
	.slide-leave-to {
		max-height: 0px;
	}

	.slide-enter-to,
	.slide-leave {
		max-height: 20em;
	}
</style>
