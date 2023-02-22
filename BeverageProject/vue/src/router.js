import Vue from "vue";
import VueRouter from "vue-router";
import Products from "./components/Products/Products.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/Products/VueTable",
    component: Products,
  },
];

export default new VueRouter({ mode: 'history', routes });
