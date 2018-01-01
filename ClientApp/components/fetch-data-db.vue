<template lang="pug">
div
	h1 Contacts Data
	p This component demonstrates fetching data from the database.
	p GET to: 
		code api/DbData/id/{id}
		|	For find method.
	p GET to: 
		code api/DbData/name/{FirstName}
		|	For where method.
	p POST to: 
		code api/auth/Register
		|	To register a new user.
	p GET to: 
		code api/auth/GetUsers
		|	To obtain registered users.
	.table-responsive(v-if="contacts")
		table.table
			thead
				tr
					th Id
					th Email
					th FirstName
					th LastName
					th Phone
			tbody
				tr(v-for="{id, email, firstName, lastName, phone} in contacts" :key="id")
					td {{ id }}
					td {{ email }}
					td {{ firstName }}
					td {{ lastName }}
					td {{ phone }}
	p(v-else-if="contacts == null")
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
		...mapState(['contacts'])
	},
	methods: {
		...mapActions(['GET_CONTACTS']),
		
		Retry() {
			this.GET_FORECASTS(this)
		}		
    },
    created() {		
        this.GET_CONTACTS(this)
    }
}
</script>

<style>
</style>
