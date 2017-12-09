<template lang="pug">
	div
		h1 Hello, world!
		p Welcome to your new single-page application, built with:
		ul
			li
				a(href="https://get.asp.net/") ASP.NET Core
				|  and
				b  F#
				|  for cross-platform server-side code
			li
				a(href="https://vuejs.org/") Vue.js
				|  and 
				a(href="https://vuex.vuejs.org/en/") Vuex
				|                     for client-side code
			li
				a(href="https://webpack.github.io/") Webpack
				|  for building and bundling client-side resources
			li
				a(href="http://getbootstrap.com/") Bootstrap
				|  for layout and styling
			li
				a(href="api/SampleData/WeatherForecasts") API sample data
				|  from the dotnet controller
		p To help you get started, we've also set up:
		ul
			li
				strong Client-side navigation
				| . For example, click
				em Counter
				|  then
				em Back
				|  to return
				|                 here.
			li
				strong Webpack dev middleware
				| . In development mode, there's no need to run the
				code webpack
				|                     build tool. Your client-side resources are dynamically built on demand. Updates are available as soon
				|                 as you modify any file.
			li
				strong Hot module replacement
				| . In development mode, you don't even need to reload the page after
				|                 making most changes. Within seconds of saving changes to files, your Vue.js app will be rebuilt and
				|                 a new instance injected is into the page.
			li
				strong Code splitting and lazy loading
				| . Vue.js components may optionally be bundled individually and
				|                 loaded on demand. For example, the code and template for 'Counter' is not loaded until you navigate to
				|                 it..
			li
				strong Efficient production builds
				| . In production mode, development-time features are disabled,
				|                 and the
				code webpack
				|  build tool produces minified static CSS and JavaScript files.
</template>

<script>
export default {
    data() {
        return {
        }
    },
}
</script>

<style>
</style>
