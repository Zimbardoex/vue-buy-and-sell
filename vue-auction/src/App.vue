<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <!-- <HelloWorld msg="Welcome to Your Vue.js App"/> -->
    <Listing name="Lenovo T480" description="It's very good" price="450" />
  </div>
</template>

<script>
// import HelloWorld from './components/HelloWorld.vue'
import Listing from './components/Listing.vue'

export default {
  name: 'App',
  components: {
    // HelloWorld,
    Listing,
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
