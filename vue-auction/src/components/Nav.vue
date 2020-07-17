<template>
  <b-navbar class="is-light">
    <template slot="brand">
      <b-navbar-item tag="router-link" :to="{ path: '/' }">
        <img
          src="../assets/newLogo.png"
          alt="Site logo showing Vue, Buy Sell"
          class="logo"
        />
      </b-navbar-item>
    </template>
    <template slot="start">
      <b-navbar-item tag="router-link" :to="{ path: '/' }">
        Home
      </b-navbar-item>
      <b-navbar-item tag="router-link" :to="{ path: '/create-listing' }">
        Create a listing
      </b-navbar-item>
      <b-navbar-item tag="router-link" :to="{ path: '/listings' }">
        All Listings
      </b-navbar-item>
      <b-navbar-dropdown v-if="user" label="My Stuff">
        <label><strong>Buying</strong></label>
        <b-navbar-item href="#">
          Watchlist
        </b-navbar-item>
        <b-navbar-item href="#">
          Won
        </b-navbar-item>
        <b-navbar-item href="#">
          Lost
        </b-navbar-item>
        <label><strong>Selling</strong></label>
        <b-navbar-item href="#">
          My Listings
        </b-navbar-item>
        <b-navbar-item href="#">
          Sold
        </b-navbar-item>
        <b-navbar-item href="#">
          Unsold
        </b-navbar-item>
      </b-navbar-dropdown>
    </template>

    <template slot="end">
      <b-navbar-item tag="div">
        <div v-if="!user" class="buttons">
          <router-link class="button is-primary" tag="a" to="signup">
            <strong>Sign up</strong>
          </router-link>
          <router-link to="login">Login</router-link>
        </div>
        <div v-if="user" class="buttons">
          <p class="greeting">{{ `Hi, ${user.name}` }}</p>
          <a @click="logout" class="button is-primary">
            <strong>Logout</strong>
          </a>
        </div>
      </b-navbar-item>
    </template>
  </b-navbar>
</template>

<script>
import { mapState } from "vuex";

export default {
  name: "Nav",
  computed: mapState({
    user: (state) => state.user,
  }),
  methods: {
    logout() {
      localStorage.removeItem("token");
      this.$store.commit("removeUser");
      this.$router.push("/login");
    },
  },
};
</script>

<style scoped>
.logo {
  min-width: 5rem;
  min-height: 5rem;
}
.greeting {
  margin-right: 1rem;
}
</style>
