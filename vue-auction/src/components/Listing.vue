<template>
  <div class="hello">
    <h1>{{ name }}</h1>
    <p>
        {{ description }}
    </p>
    <p>
     {{ `Price: $${price}` }}
    </p>
  </div>
</template>

<script>
export default {
  name: 'Listing',
  props: {
    name: String,
    price: String,
    description: String
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
