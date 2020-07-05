<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png" />
    <Listing
      v-for="listing in listings"
      v-bind:key="listing.id"
      v-bind:name="listing.name"
      v-bind:description="listing.description"
      v-bind:price="listing.price"
    />
  </div>
</template>

<script>
import Listing from "./components/Listing.vue";

const API_URL = "http://localhost:5000/api";

export default {
  name: "App",
  components: {
    Listing,
  },
  mounted() {
    fetch(`${API_URL}/listings`)
      .then((response) => response.json())
      .then((result) => {
        this.listings = result;
      });
  },
  data: () => ({
    listings: [],
  }),
};
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
