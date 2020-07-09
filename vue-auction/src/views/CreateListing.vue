<template>
  <form @submit.prevent="createListing" @keydown.prevent.enter>
    <label for="name">Title</label>
    <input v-model="listing.name" type="text" name="name" />
    <br />
    <label for="description">Description</label>
    <textarea
      v-model="listing.description"
      type="textarea"
      name="description"
    />
    <br />
    <label for="price">Price</label>
    <input v-model.number="listing.price" type="number" step="0.01" name="price" />
    <br />
    <select v-model="listing.category">
      <option disabled value="">Please select one</option>
      <option>Books</option>
      <option>Cars</option>
      <option>Computers</option>
    </select>
    <br />
    <button type="submit">Submit</button>
  </form>
</template>

<script>
const API_URL = "http://localhost:5000/api";

export default {
  name: "CreateListing",
  data: () => ({
    listing: {
      name: "",
      description: "",
      price: 0.0,
      category: "",
    },
  }),
  methods: {
    createListing() {
      console.log('"submit"', this.listing);
      fetch(`${API_URL}/listings`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(this.listing),
      })
        .then((response) => response.json())
        .then((result) => {
          console.log("result", result);
        });
    },
  },
};
</script>

<style scoped></style>
