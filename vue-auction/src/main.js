import Vue from "vue";
import App from "./App.vue";
import Home from "./views/Home";
import Listings from "./views/Listings";
import VueRouter from "vue-router";

Vue.use(VueRouter);

Vue.config.productionTip = false;

const routes = [
  { path: "/", component: Home },
  { path: "/listings", component: Listings },
];

const router = new VueRouter({
  routes,
});

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
