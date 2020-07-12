<template>
  <div id="app">
    <p>
      <router-link to="/listings">Go to Listings</router-link>
      <router-link to="/create-listing">Create a listing</router-link>
      <router-link to="/signup">Signup</router-link>
      <router-link to="login">Login</router-link>
    </p>
    <!-- component matched by the route will render here -->
    <router-view />
  </div>
</template>

<script>
export default {
  name: "App",
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
