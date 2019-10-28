import Vue from "vue"
import VueRouter from "vue-router";
import App from "./components/App/App.vue"

import "./root.css"
import MainPage from "./pages/Main/MainPage.vue";
import AboutPage from "./pages/About/AboutPage.vue";
import LoginPage from "./pages/Login/LoginPage.vue";
import AdminPanelPage from "./pages/AdminPanel/AdminPanelPage.vue";
import NewsEditorPage from "./pages/NewsEditor/NewsEditorPage.vue";

Vue.use(VueRouter);
document.execCommand("defaultParagraphSeparator", false, "p");

const routes = [
  {
    path: "/",
    redirect: "/home"
  }, {
    path: "/home",
    component: MainPage
  }, {
    path: "/about",
    component: AboutPage
  }, {
    path: "/login",
    component: LoginPage
  }, {
    path: "/admin-panel",
    component: AdminPanelPage
  }, {
    path: "/add-news",
    component: NewsEditorPage
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

