<template>
  <div class="card">
    <form @submit.prevent="signup" @keydown.prevent.enter class="form">
      <div class="formElement">
        <b-field label="Name">
          <b-input v-model="user.name"></b-input>
        </b-field>
      </div>
      <div class="formElement">
        <b-field label="Email">
          <b-input v-model="user.email"></b-input>
        </b-field>
      </div>
      <div class="formElement">
        <b-field label="Password">
          <b-input v-model="user.password" type="password"></b-input>
        </b-field>
      </div>
      <div class="formElement">
        <b-field label="Confirm Password">
          <b-input v-model="user.confirmPassword" type="password"></b-input>
        </b-field>
      </div>
      <div class="formElement">
        <b-button type="is-primary" native-type="submit">Signup</b-button>
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
  name: "Signup",
  data: () => ({
    user: {
      name: "",
      email: "",
      password: "",
      confirmPassword: "",
    },
    errors: null,
  }),
  methods: {
    signup() {
      fetch(`${API_URL}/users`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(this.user),
      })
        .then((response) => response.json())
        .then((result) => {
          if (result.errors) {
            this.errors = result.errors;
          } else {
            if (result.token) {
              localStorage.setItem("token", result.token);
              this.$store.commit("setUser", result.user);
              this.$router.push({ path: "listings" });
            }
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
  max-width: 25vw;
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
