<template>
  <div>
    <SearchBar />
    <hr />
    <Categories />
    <hr />
  <div class="carousel-container">
    <h1 class="subtitle">Check out these listings!</h1>
    <ListingsCarousel :listings="randomListings"/>
  </div>
  </div>
</template>

<script>
import { mapState } from "vuex";


import SearchBar from '../components/SearchBar';
import Categories from '../components/Categories';
import ListingsCarousel from '../components/ListingsCarousel';


const API_URL = "http://localhost:5000/api";

export default {
  name: "Home",
  components:{ListingsCarousel, SearchBar, Categories},
  computed: mapState({
    randomListings: (state) => state.randomListings,
  }),
  mounted() {
    if (!this.$store.state.randomListings){
      fetch(`${API_URL}/listings/random/?number=7`)
        .then((response) => response.json())
        .then((result) => {
          this.$store.commit("setRandomListings", result);
        });
    }
  },
};
</script>

<style scoped>
.carousel-container {
  width: 60vw;
  margin: 0 auto;
  margin-top: 2rem;
}
</style>
