import Vue from "vue"
import VueRouter from "vue-router";
import App from "./components/App/App.vue"

Vue.use(VueRouter);

const routes = [];

const router = new VueRouter({
  routes
});

new Vue({
  router,
  el: "#app-container",
  render: h => h(App)
});

