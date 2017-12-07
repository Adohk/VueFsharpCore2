<template>
<div>
	<h1>Counter</h1>
	<p>This is a simple example of a Vue.js component & Vuex</p>
	<p>
		Current count (Vuex):<strong> {{ currentCount }} </strong>
	</p>
	<p>
		Auto count:<strong> {{ autoCount }} </strong>
	</p>
	<button @click="incrementCounter()">Increment</button>
	<button @click="resetCounter()">Reset</button>
</div>
</template>

<script>
import { mapActions, mapState } from 'vuex'

export default {
	data() {
		return {
			autoCount: 0,
		}
	},
	computed: {
		...mapState({
			currentCount: state => state.counter
		})
	},
	methods: {
		...mapActions(['SET_COUNTER']),
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
			this.autoCount += 1
		}, 1000)
	}
}
</script>

<style>
</style>
