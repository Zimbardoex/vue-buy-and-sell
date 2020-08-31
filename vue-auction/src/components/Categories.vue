<template>
  <div class="panel is-primary">
    <p class="panel-heading">
      Categories
    </p>
    <div class="panel-block">
      <div class="category" v-for="category in categories" :key="category">
        <router-link
          class="category-link"
          tag="a"
          :to="{ path: `/listings/${category}` }"
        >
          {{ category }}
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
const API_URL = "http://localhost:5000/api";

export default {
  data: () => ({
    categories: [],
  }),
  mounted() {
    fetch(`${API_URL}/categories`)
      .then((response) => response.json())
      .then((result) => {
        this.categories = result.map((category) => category.name);
      });
  },
};
</script>

<style scoped>
.panel {
  max-width: 35vw;
  margin: 0 auto;
  margin-top: 2rem;
  padding-bottom: 1rem;
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
.category-link {
  color: black;
  text-transform: capitalize;
}
</style>
