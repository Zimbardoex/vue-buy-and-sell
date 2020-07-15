<template>
  <div class="listing" v-on:click="route(id)">
    <img
      alt="Placeholder image"
      :src="getImage(image)"
      class="listing-image"
    />
    <div class="listing-text">
      <h1>{{ name }}</h1>
      <h2>Caption will go here</h2>
    </div>
    <p class="listing-price">
      {{ `$${price}` }}
    </p>
  </div>
</template>

<script>
import DefaultImage from "../assets/placeholder.jpg";

export default {
  name: "Listing",
  props: {
    id: String,
    name: String,
    price: String,
    description: String,
    image: String,
  },
  methods: {
    route: function(listing_id) {
      const router = this.$router;
      router.push({ path: "listing", query: { id: listing_id } });
    },
    getImage: function(image){
      return image ? image : DefaultImage
    }
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.listing {
  margin: 1rem;
  max-width: 40%;
  min-width: 40%;
  max-height: 5%;
  display: flex;
  justify-content: flex-start;
  flex-flow: row nowrap;
  align-items: center;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.listing-image {
  max-height: 8rem;
  width: auto;
  margin: 1rem;
}
.listing-text {
  white-space: nowrap;
  display: flex;
  justify-content: space-around;
  flex-flow: column nowrap;
  align-items: flex-start;
  margin: 0.5rem;
}
.listing-price {
  margin-right: 0rem;
  width: 100%;
}
</style>
