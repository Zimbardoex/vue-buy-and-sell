<template>
  <div class="listing">
    <img
      alt="Placeholder image"
      src="../assets/placeholder.jpg"
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
export default {
  name: "Listing",
  props: {
    name: String,
    price: String,
    description: String,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.listing {
  margin: 2rem;
  max-width: 40%;
  max-height: 5%;
  display: flex;
  justify-content: space-around;
  flex-flow: row nowrap;
  align-items: center;
  /* box-shadow: 2px 2px 2px #BBB, 1px 1px 1px #BBB; */
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.listing-image {
  max-height: 8rem;
  width: auto;
}
.listing-text {
  display: flex;
  justify-content: space-around;
  flex-flow: column nowrap;
  align-items: flex-start;
  margin: 0.5rem;
}
</style>
