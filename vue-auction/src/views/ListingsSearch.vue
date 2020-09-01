<template>
  <div class="listings">
    <SearchBar />
    <h1 class="title">
      Search results for "{{ this.$route.query.query }}" - ({{
        this.listings.length
      }})
    </h1>
    <Listing
      v-for="listing in paginatedListings"
      v-bind:key="listing.id"
      v-bind:id="listing.id"
      v-bind:name="listing.name"
      v-bind:description="listing.description"
      v-bind:price="listing.price"
      v-bind:image="listing.image"
    />
    <b-pagination
      :total="total"
      :current.sync="current"
      range-before="3"
      range-after="3"
      :per-page="perPage"
      order="is-centered"
      aria-next-label="Next page"
      aria-previous-label="Previous page"
      aria-page-label="Page"
      aria-current-label="Current page"
      v-if="listings"
    >
    </b-pagination>
  </div>
</template>

<script>
import Listing from "../components/Listing";
import SearchBar from "../components/SearchBar";

const API_URL = "http://localhost:5000/api";

export default {
  name: "ListingsSearch",
  components: {
    Listing,
    SearchBar,
  },
  data: () => ({
    listings: [],
    perPage: 10,
    current: 1,
  }),
  watch: {
    $route() {
      this.search()
    },
  },
  computed: {
    total() {
      return this.listings.length;
    },
    paginatedListings() {
      let pageNumber = this.current - 1;

      return this.listings.slice(
        pageNumber * this.perPage,
        (pageNumber + 1) * this.perPage
      );
    },
  },
  mounted() {
    this.search()
  },
  methods: {
    search: function() {
      document.title = this.$route.query.query;
      fetch(`${API_URL}/listings/search?query=${this.$route.query.query}`)
        .then((response) => response.json())
        .then((result) => {
          this.listings = result.reverse();
        });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.listings {
  display: flex;
  justify-content: center;
  flex-flow: column wrap;
  align-items: center;
}
.title {
  margin-top: 2rem;
}
</style>
