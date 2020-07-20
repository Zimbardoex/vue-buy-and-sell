<template>
  <div class="container card">
    <h1>{{ listing.name }}</h1>
    <h3>Listing caption will be here</h3>
    <div class="image-container">
      <img
        alt="Place holder image"
        :src="checkImage(listing.image)"
        class="image"
      />
    </div>
    <div class="purchasing">
      <p>{{ `$${listing.price}` }}</p>
      <button>Buy Now</button>
      <button>Place Bid</button>
    </div>
    <div class="description">
      <h3>Description</h3>
      {{ listing.description }}
    </div>
  </div>
</template>

<script>
import DefaultImage from "../assets/placeholder.jpg";

const API_URL = "http://localhost:5000/api";

export default {
  name: "Listing",
  data: () => ({
    listing: {},
  }),
  mounted() {
    const listing_id = this.$route.query.id;
    fetch(`${API_URL}/listings/${listing_id}`)
      .then((response) => response.json())
      .then((result) => {
        this.listing = result;
        document.title = this.listing.name;
      });
  },
  methods: {
    checkImage: function(image) {
      return image ? image : DefaultImage;
    },
  },
};
</script>

<style scoped>
.container {
  margin: 0 auto;
  margin-top: 1rem;
  max-width: 50%;
  padding: 4rem;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}
.description {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
}
.image-container {
  width: 100%;
}
.image {
  width: 80%;
  margin:  0 auto;
}
.purchasing {
  width: 100%;
}
</style>
