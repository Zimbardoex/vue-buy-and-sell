<template>
  <div>
    <section class="search">
      <b-field position="is-centered">
        <b-input
          placeholder="Search listings..."
          type="search"
          icon="magnify"
          class="search-bar"
          v-model="query"
          v-on:keyup.enter.native="search"
        />
        <p class="control">
          <button class="button is-primary" @click="search">Search</button>
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
    <ListingsCarousel :listings="randomListings"/>
  </div>
  </div>
</template>

<script>
import ListingsCarousel from '../components/ListingsCarousel';
import { mapState } from "vuex";

const API_URL = "http://localhost:5000/api";

export default {
  name: "Home",
  components:{ListingsCarousel},
  data: () => ({
    categories: [],
    query:""
  }),
  computed: mapState({
    randomListings: (state) => state.randomListings,
  }),
  methods: {
    search: function (){
      this.$router.push({ path: "listings/search", query:{ query: this.query} });
    }
  },
  mounted() {
    if (!this.$store.state.randomListings){
      fetch(`${API_URL}/listings/random/?number=7`)
        .then((response) => response.json())
        .then((result) => {
          this.$store.commit("setRandomListings", result);
        });
    }
    fetch(`${API_URL}/categories`)
        .then((response) => response.json())
        .then((result) => {
          this.categories = result.map(category => category.name);
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
