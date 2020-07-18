<template>
  <div>
    <section class="search">
      <b-field position="is-centered">
        <b-input
          placeholder="Search listings..."
          type="search"
          icon="magnify"
          class="search-bar"
        >
        </b-input>
        <p class="control">
          <button class="button is-primary">Search</button>
        </p>
      </b-field>
    </section>
    <hr />
    <div class="panel is-primary">
      <p class="panel-heading">
        Categories
      </p>
      <div class="panel-block">
        <div
          class="category"
          v-for="category in categories"
          :key="category"
        >
          <router-link class="category-link" tag="a" :to="{ path: `/listings/${category}` }">
            {{ category }}
          </router-link>
        </div>
      </div>
    </div>
    <hr />
  <div class="carousel-container">
    <h1 class="subtitle">Check out these listings!</h1>
    <ListingsCarousel />
  </div>
  </div>
</template>

<script>
import ListingsCarousel from '../components/ListingsCarousel';

export default {
  name: "Home",
  components:{ListingsCarousel},
  data: () => ({
    categories: [
      "books",
      "clothing",
      "computers",
      "gaming",
      "mobile phones",
      "motors",
      "instruments",
      "pets",
      "sports",
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
.category-link {
  color: black;
  text-transform:capitalize;
}
.search {
  margin: 0 auto;
  margin-top: 1rem;
  width: 60%;
}
.search-bar {
  width: 100%;
}
.carousel-container {
  width: 60vw;
  margin: 0 auto;
  margin-top: 2rem;
}
</style>
