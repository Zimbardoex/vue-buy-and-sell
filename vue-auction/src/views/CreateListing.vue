<template>
  <div class="card">
    <form @submit.prevent="createListing" @keydown.prevent.enter class="form">
      <div class="formElement">
        <b-field label="Title" message="">
          <b-input v-model="listing.name"></b-input>
        </b-field>
      </div>

      <div class="formElement">
        <b-field label="Description">
          <b-input type="textarea" v-model="listing.description"></b-input>
        </b-field>
      </div>

      <div class="formElement">
        <b-field label="Price ($)">
          <b-numberinput step="0.01" v-model="listing.price" />
        </b-field>
      </div>

      <div class="formElement">
        <b-field label="Category">
          <b-select
            placeholder="Select a category"
            icon="shape"
            v-model="listing.category"
          >
            <optgroup label="Computers">
              <option value="laptop">Laptops</option>
              <option value="desktops">Desktops</option>
            </optgroup>

            <optgroup label="Motors">
              <option value="cars">Cars</option>
              <option value="boats">Boats</option>
              <option value="motorbikes">Motorbikes</option>
            </optgroup>
          </b-select>
        </b-field>
      </div>
      <div class="formElement">
        <img v-if="listing.image" :src="listing.image" />
        <b-upload v-model="images" expanded drag-drop>
          <a class="button is-primary">
            <b-icon icon="upload"></b-icon>
            <span>Upload an image</span>
          </a>
        </b-upload>
      </div>
      <div class="formElement">
        <b-button type="is-primary" native-type="submit">Create listing</b-button>
      </div>
      <div class="formElement">
        <p v-if="errors">
          <b>Please correct the following error(s):</b>
          <ul>
            <li v-for="errorList in errors" :key="errorList[0]">{{ errorList[0] }}</li>
          </ul>
        </p>
      </div>
    </form>
  </div>
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
      image: null,
    },
    images: [],
    errors: null,
  }),
  watch: {
    images: function(uploadedFile) {
      const reader = new FileReader()
      reader.onload = e => {
          this.listing.image = e.target.result
      }
      reader.readAsDataURL(uploadedFile);
    },
  },
  methods: {
    createListing() {
      fetch(`${API_URL}/listings`, {
        method: "POST",
        headers: {
          Authorization: `Bearer ${localStorage.token}`,
          "Content-Type": "application/json",
        },
        body: JSON.stringify(this.listing),
      })
        .then((response) => response.json())
        .then((result) => {
          if (result.errors) {
            this.errors = result.errors;
          } else {
            this.$router.push({ path: "listings" });
          }
        });
    },
  },
};
</script>

<style scoped>
.form {
  display: flex;
  /* align-items: flex-start; */
  justify-content: center;
  flex-direction: column;
  padding: 1rem;
}
.card {
  max-width: 35vw;
  min-width: 350px;
  margin: 0 auto;
  margin-top: 1rem;
}
.formElement {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  text-align: start;
  margin: 0.5rem;
}
</style>
