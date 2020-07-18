<template>
  <div>
    <div class="panel is-primary">
      <p class="panel-heading">
        Categories
      </p>
      <div class="panel-block">
        <div class="category" v-for="category in categories" :key="category">
          {{ category }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Home",
  data: () => ({
    categories: [
      "Books",
      "Clothing",
      "Computers",
      "Gaming",
      "Mobile Phones",
      "Motors",
      "Instruments",
      "Pets",
      "Sports",
    ],
  }),
};
</script>

<style scoped>
.panel {
  max-width: 35vw;
  margin: 0 auto;
  margin-top: 1rem;
}
.panel-heading {
  background-color: #714dd2;
  color: white;
}
.panel-block {
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  max-height: 100px;
}
.category {
  text-align: left;
}
</style>
