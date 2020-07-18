<template>
  <div class="listings">
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
import { mapState } from "vuex";
import Listing from "../components/Listing";

export default {
  name: "MyListings",
  components: {
    Listing,
  },
  data: () => ({
    listings: [],
  }),
  computed: mapState({
    user: (state) => state.user,
  }),
  mounted() {
    fetch(`${API_URL}/listings/my-listings`, {
      method: "POST",
      headers: {
        Authorization: `Bearer ${localStorage.token}`,
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ value: localStorage.token }),
    })
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
</style>
