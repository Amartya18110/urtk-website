import Vue from "vue"
import VueRouter from "vue-router";
import App from "./components/App/App.vue"

import "./root.css"
import MainPage from "./pages/Main/MainPage.vue";
import AboutPage from "./pages/About/AboutPage.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    redirect: "/home"
  },
  {
    path: "/home",
    component: MainPage
  },
  {
    path: "/about",
    component: AboutPage
  }
];

const router = new VueRouter({
  routes
});

new Vue({
  router,
  el: "#app-container",
  render: h => h(App)
});

