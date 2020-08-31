<template>
  <div class="listing card" v-on:click="route(id)">
    <div class="image-container">
      <img
        alt="Placeholder image"
        :src="getImage(image)"
        class="listing-image"
      />
    </div>
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
    price: Number,
    description: String,
    image: String,
  },
  methods: {
    route: function(listing_id) {
      const router = this.$router;
      router.push({ path: "/listing", query: { id: listing_id } });
    },
    getImage: function(image) {
      return image ? image : DefaultImage;
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.listing {
  margin: 0.5rem;
  max-width: 35%;
  min-width: 35%;
  max-height: 5%;
  display: flex;
  justify-content: flex-start;
  flex-flow: row nowrap;
  align-items: center;
}
.listing-image {
  max-height: 100%;
  max-width: 100%;
  width: auto;
  height: auto;
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  margin: auto;
}
.image-container {
  background-color: #eee;
  position: relative;
  min-height: 8rem;
  min-width: 8rem;
  max-width: 8rem;
  margin: 1rem;
}
.listing-text {
  width: 50%;
  white-space: nowrap;
  text-overflow: ellipsis;
  overflow: hidden;
  display: flex;
  justify-content: space-around;
  flex-flow: column nowrap;
  align-items: flex-start;
  margin: 0.5rem;
}
.listing-price {
  text-align: center;
  width: 20%;
}
</style>
