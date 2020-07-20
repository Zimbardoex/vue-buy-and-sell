<template>
  <div class="listings">
    <h1 class="title">
      {{
        $route.params.category.replace(/(^\w|\s\w)/g, (fc) => fc.toUpperCase())
      }}
    </h1>
    <Listing
      v-for="listing in listings"
      v-bind:key="listing.id"
      v-bind:id="listing.id"
      v-bind:name="listing.name"
      v-bind:description="listing.description"
      v-bind:price="listing.price"
      v-bind:image="listing.image"
    />
  </div>
</template>

<script>
const API_URL = "http://localhost:5000/api";
import Listing from "../components/Listing";

export default {
  name: "Listings",
  components: {
    Listing,
  },
  data: () => ({
    listings: [],
  }),
  beforeCreate() {
    document.title = this.$route.params.category.replace(/(^\w|\s\w)/g, (fc) => fc.toUpperCase());
  },
  mounted() {
    fetch(`${API_URL}/listings/${this.$route.params.category}`)
      .then((response) => response.json())
      .then((result) => {
        this.listings = result.reverse();
      });
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.listings {
  display: flex;
  justify-content: center;
  flex-flow: column wrap;
  align-items: center;
}
.title {
  margin-top: 1rem;
}
</style>
