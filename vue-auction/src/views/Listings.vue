<template>
  <div class="listings">
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
  mounted() {
    fetch(`${API_URL}/listings`)
      .then((response) => response.json())
      .then((result) => {
        this.listings = result;
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
</style>
