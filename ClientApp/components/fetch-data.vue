<template lang="pug">
div
	h1 Weather forecast
	p This component demonstrates fetching data from the server.
	table.table(v-if="forecasts")
		thead
			tr
				th Date
				th Temp. (C)
				th Temp. (F)
				th Summary
		tbody
			tr(v-for="{dateFormatted, temperatureC, temperatureF, summary} in forecasts")
				td {{ dateFormatted }}
				td {{ temperatureC }}
				td {{ temperatureF }}
				td {{ summary }}
	p(v-else="")
		em Loading...
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
	data() {
		return {}
	},
	computed: {
		...mapState(['forecasts'])
	},
	methods: {
        ...mapActions(['GET_FORECASTS'])
    },
    created() {
        this.GET_FORECASTS(this)
    }
}
</script>

<style>
</style>
