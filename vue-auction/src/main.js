import Vue from "vue";
import App from "./App.vue";
import Home from "./views/Home";
import Listings from "./views/Listings";
import Listing from "./views/Listing";
import CreateListing from "./views/CreateListing";
import VueRouter from "vue-router";
import Buefy from 'buefy';
import 'buefy/dist/buefy.css';

Vue.use(VueRouter);

Vue.use(Buefy)

Vue.config.productionTip = false;

const routes = [
  { path: "/", component: Home },
  { path: "/listings", component: Listings },
  { path: "/listing", component: Listing, name: "listing" },
  { path: "/create-listing", component: CreateListing, name: "create-listing" },
];

const router = new VueRouter({
  routes,
});

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
