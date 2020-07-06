<template>
  <div>
    <h1>{{ name }}</h1>
    <h2>Caption will go here</h2>
    <img alt="Placeholder image" src="../assets/placeholder.jpg" />
    <div>
      <p>
        {{ `Price: $${price}` }}
      </p>
      <button>
        Bid
      </button>
      <button>
        Buy now
      </button>
      <p>
        {{ description }}
      </p>
    </div>
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
<style scoped></style>
