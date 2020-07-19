import Vue from "vue";
import App from "./App.vue";
import "@mdi/font/css/materialdesignicons.css";
import Home from "./views/Home";
import Listings from "./views/Listings";
import ListingsCategory from "./views/ListingsCategory";
import ListingsSearch from "./views/ListingsSearch";
import MyListings from "./views/MyListings";
import Listing from "./views/Listing";
import Signup from "./views/Signup";
import Login from "./views/Login";
import CreateListing from "./views/CreateListing";
import VueRouter from "vue-router";
import Buefy from "buefy";
import "buefy/dist/buefy.css";
import store from "./store/store";

Vue.use(VueRouter);

Vue.use(Buefy);

Vue.config.productionTip = false;

const notLoggedInRedirect = (_0, _1, next) => {
  if (localStorage.token) {
    next();
  } else {
    next("/login");
  }
};

const loggedInRedirect = (_0, _1, next) => {
  if (localStorage.token) {
    next("/");
  } else {
    next();
  }
};

const routes = [
  { path: "/", component: Home },
  { path: "/listings/search", component: ListingsSearch },
  { path: "/listings/:category", component: ListingsCategory },
  { path: "/listings", component: Listings },
  { path: "/listing", component: Listing, name: "listing" },
  { path: "/my-listings", component: MyListings, name: "myListing" },
  {
    path: "/create-listing",
    component: CreateListing,
    name: "create-listing",
    beforeEnter: notLoggedInRedirect,
  },
  {
    path: "/signup",
    component: Signup,
    name: "signup",
    beforeEnter: loggedInRedirect,
  },
  {
    path: "/login",
    component: Login,
    name: "login",
    beforeEnter: loggedInRedirect,
  },
];

const router = new VueRouter({
  routes,
});

new Vue({
  router,
  store,
  beforeCreate() {
    this.$store.commit("initialiseStore");
  },
  render: (h) => h(App),
}).$mount("#app");
