import Vue from "vue";
import VueRouter from "vue-router";
import Products from "./components/Products/Products.vue";
import Orders from './components/Orders/Orders.vue';
import OrderDetails from './components/Orders/OrderDetails.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: "/Products/VueTable",
    component: Products,
  },
  {
    path: "/Customers/Orders",
    component: Orders,
  },
  {
    path: "/Customers/OrderDetails",
    component: OrderDetails,
  },
];

export default new VueRouter({ mode: 'history', routes });
