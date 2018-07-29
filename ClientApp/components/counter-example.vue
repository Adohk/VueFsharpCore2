<template lang="pug">
	div
		h1 Counter
		p This is a simple example of a Vue.js component & Vuex
		p
			| Current count (Vuex):
			strong  {{ currentCount }}
		p
			| Auto count:
			strong  {{ autoCount }}
		button(@click="incrementCounter()") Increment
		button(@click="resetCounter()") Reset
</template>

<script>
	import { mapActions, mapState } from "vuex";

	export default {
		data() {
			return {
				autoCount: 0
			};
		},
		computed: {
			...mapState({
				currentCount: state => state.counter
			})
		},
		methods: {
			...mapActions(["SET_COUNTER"]),

			incrementCounter: function() {
				var counter = this.currentCount + 1;
				this.SET_COUNTER({ counter: counter });
			},

			resetCounter: function() {
				this.SET_COUNTER({ counter: 0 });
				this.autoCount = 0;
			}
		},
		created() {
			setInterval(() => {
				this.autoCount += 1;
			}, 1000);
		}
	};
</script>
