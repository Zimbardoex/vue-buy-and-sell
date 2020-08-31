<template>
  <section class="search">
    <b-field position="is-centered">
      <b-input
        placeholder="Search listings..."
        type="search"
        icon="magnify"
        class="search-bar"
        v-model="query"
        v-on:keyup.enter.native="search"
      />
      <p class="control">
        <button class="button is-primary" @click="search">Search</button>
      </p>
    </b-field>
  </section>
</template>

<script>
export default {
  data() {
    return {
      query: "",
    };
  },
  methods: {
    search: function() {
      this.$router.push({
        path: "listings/search",
        query: { query: this.query },
      });
    },
  },
};
</script>

<style>
.search {
  margin: 0 auto;
  margin-top: 1rem;
  width: 60%;
}
.search-bar {
  width: 100%;
}
</style>
