<template>
    <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        <!-- Instead of doing an 'if-not' logic here, which is clunky, use v-else below the 'if-forecasts' table -->
        <!-- <p v-if="!forecasts"><em>Loading...</em></p> -->
        <table class="table" v-if="forecasts">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                <!-- This is optional but a nice way of showcasing Vue's ability to destructure objects using a v-for -->
                <!-- Make sure this works, but I believe it should fire fine -->
                <tr v-for="{dateFormatted, temperatureC, temperatureF, summary} in forecasts" >
                    <td>{{ dateFormatted }}</td>
                    <td>{{ temperatureC }}</td>
                    <td>{{ temperatureF }}</td>
                    <td>{{ summary }}</td>
                </tr>
            </tbody>
        </table>
        <p v-else><em>Loading...</em></p>
    </div>
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
        this.GET_FORECASTS()
    }	
}
</script>

<style>
</style>
