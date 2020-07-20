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

const DEFAULT_TITLE = "Vue, Buy and Sell";

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
  {
    path: "/",
    component: Home,
    meta: {
      title: DEFAULT_TITLE,
    },
  },
  {
    path: "/listings/search",
    component: ListingsSearch,
    meta: {
      title: "Search Listings",
    },
  },
  {
    path: "/listings/:category",
    component: ListingsCategory,
    meta: {
      title: "Category",
    },
  },
  {
    path: "/listings",
    component: Listings,
    meta: {
      title: "All Listings",
    },
  },
  {
    path: "/listing",
    component: Listing,
    name: "listing",
    meta: {
      title: "Listing",
    },
  },
  {
    path: "/my-listings",
    component: MyListings,
    name: "myListing",
    meta: {
      title: "My listings",
    },
  },
  {
    path: "/create-listing",
    component: CreateListing,
    name: "create-listing",
    meta: {
      title: "Create a listing",
    },
    beforeEnter: notLoggedInRedirect,
  },
  {
    path: "/signup",
    component: Signup,
    name: "signup",
    meta: {
      title: "Signup",
    },
    beforeEnter: loggedInRedirect,
  },
  {
    path: "/login",
    component: Login,
    name: "login",
    meta: {
      title: "Login",
    },
    beforeEnter: loggedInRedirect,
  },
];

const router = new VueRouter({
  routes,
});

router.beforeEach((to, from, next) => {
  document.title = to.meta.title
  next()
})

new Vue({
  router,
  store,
  beforeCreate() {
    this.$store.commit("initialiseStore");
    document.title = DEFAULT_TITLE;
  },
  render: (h) => h(App),
}).$mount("#app");
