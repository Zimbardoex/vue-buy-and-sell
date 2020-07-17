<template>
  <div>
    <p>Welcome home</p>
    <b-button v-if="token" type="is-primary" outlined @click="logout">
      Logout
    </b-button>
  </div>
</template>

<script>
export default {
  name: "Home",
  data: () => ({
    token: localStorage.token,
  }),
};
</script>
