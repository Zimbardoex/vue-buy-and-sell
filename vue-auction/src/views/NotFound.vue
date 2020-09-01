<template>
  <div class="container">
    <img
      :src="require('../assets/sadFace.png')"
      DefaultImage
      alt="Image of a sad cartoon face."
      class="image"
    />
    <h1 class="title is-2">(404) Page not found</h1>
  </div>
</template>

<style scoped>
.container {
  width: 100%;
}
.title {
  text-align: center;
}
.image {
  margin: 0 auto;
  margin-top: 5rem;
  margin-bottom: 2rem;
  width: 20%;
}
</style>
