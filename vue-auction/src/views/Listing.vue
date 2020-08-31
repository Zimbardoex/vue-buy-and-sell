<template>
  <div class="container card">
    <h1 class="title is-2">{{ listing.name }}</h1>
    <h3 class="title is-6">Listing caption will be here</h3>
    <div class="image-container">
      <img
        alt="Place holder image"
        :src="checkImage(listing.image)"
        class="image"
      />
    </div>
    <h1 class="price title is-4">{{ `$${listing.price}` }}</h1>
    <div class="purchasing">
      <b-button type="is-primary">Buy Now</b-button>
      <b-button type="is-rounded">Place Bid</b-button>
    </div>
    <div class="description">
      <h3 class="title is-5">Description</h3>
      {{ listing.description }}
    </div>
    <div class="seller" v-if="seller">
      <h3 class="title is-5">Seller Info</h3>
      <div class="card">
        <div class="card-content">
          <div class="media">
            <div class="media-left">
              <figure class="image is-48x48">
                <img
                  :src=checkImage(seller.image)
                  alt="Placeholder image"
                />
              </figure>
            </div>
            <div class="media-content">
              <p class="title is-4">{{ seller.name }}</p>
              <p class="subtitle is-6">{{ seller.email }}</p>
            </div>
          </div>
          <div class="content">
              {{ seller.id }}
            <br />
            Member since: <time datetime="2020-1-1">11:09 PM - 1 Jan 2020</time>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import DefaultImage from "../assets/placeholder.jpg";

const API_URL = "http://localhost:5000/api";

export default {
  name: "Listing",
  data: () => ({
    listing: null,
    seller: null,
  }),
  mounted() {
    const listing_id = this.$route.query.id;
    fetch(`${API_URL}/listings/${listing_id}`)
      .then((response) => response.json())
      .then((result) => {
        this.listing = result;
        document.title = this.listing.name;

        if ("userId" in result) {
          fetch(`${API_URL}/users/${result.userId}`)
            .then((response) => response.json())
            .then((result) => {
              this.seller = result;
            });
        }
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
  margin-top: 1rem;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
}
.seller {
  margin-top: 1rem;
}
.image-container {
  width: 100%;
  background-color: #eee;
}
.image {
  max-height: 22rem;
  max-width: 80%;
  margin: 0 auto;
}
.purchasing {
  width: 100%;
  margin-top: 1rem;
  display: flex;
  justify-content: center;
}
.purchasing > * {
  margin: 0 0.5rem;
}
.price {
  color: black;
  margin: 1rem auto;
}
</style>
