<template lang="pug">
div
	h1 Weather forecast
	p This component demonstrates fetching data from the server.
	.table-responsive(v-if="forecasts")
		table.table
			thead
				tr
					th Index
					th Date
					th Temp. (C)
					th Temp. (F)
					th Summary
			tbody
				tr(v-for="({dateFormatted, temperatureC, temperatureF, summary}, index) in forecasts" :key="index")
					td {{ index }}
					td {{ dateFormatted }}
					td {{ temperatureC }}
					td {{ temperatureF }}
					td {{ summary }}
	p(v-else-if="forecasts == null")
		em Could not contact server.
			p
			button.btn.btn-default(@click="Retry()") Retry
	p(v-else)
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
		...mapActions(['GET_FORECASTS']),

		Retry() {
			this.GET_FORECASTS(this)
		}		
    },
    created() {
        this.GET_FORECASTS(this)
    }
}
</script>
