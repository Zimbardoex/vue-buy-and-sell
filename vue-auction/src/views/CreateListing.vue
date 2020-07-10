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
    <p v-if="errors">
      <b>Please correct the following error(s):</b>
      <ul>
        <li v-for="errorList in errors" :key="errorList[0]">{{ errorList[0] }}</li>
      </ul>
    </p>
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
    errors: null,
  }),
  methods: {
    createListing() {
      fetch(`${API_URL}/listings`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(this.listing),
      })
        .then((response) => response.json())
        .then((result) => {
          console.log('result', result)
          console.log('errors', result.errors)
          if (result.errors) this.errors = result.errors
        });
    },
  },
};
</script>

<style scoped></style>
