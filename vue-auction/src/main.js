import Vue from "vue";
import App from "./App.vue";
import Home from "./views/Home";
import Listings from "./views/Listings";
import Listing from "./views/Listing";
import Signup from "./views/Signup";
import Login from "./views/Login";
import CreateListing from "./views/CreateListing";
import VueRouter from "vue-router";
import Buefy from "buefy";
import "buefy/dist/buefy.css";

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
  { path: "/listings", component: Listings },
  { path: "/listing", component: Listing, name: "listing" },
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
  render: (h) => h(App),
}).$mount("#app");
