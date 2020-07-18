import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    user: null,
    randomListings: null,
  },
  mutations: {
    initialiseStore(state) {
      state.user = JSON.parse(localStorage.user);
    },
    setUser: (state, user) => {
      localStorage.user = JSON.stringify(user);
      state.user = user;
    },
    removeUser: (state) => {
      localStorage.removeItem("user");
      state.user = null;
    },
    setRandomListings: (state, randomListings) => {
      state.randomListings = randomListings;
    },
  },
});
