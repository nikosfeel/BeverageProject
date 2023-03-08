import Vue from "vue";
import VueRouter from "vue-router";
import Products from "./components/Products/Products.vue";
import Orders from './components/Orders/Orders.vue';
import OrderDetails from './components/Orders/Details/OrderDetails.vue';
import Dashboard from './components/Dashboard/Dashboard.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: "/Products",
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
  {
    path:'/Dashboard',
    component: Dashboard,
  }
];

export default new VueRouter({ mode: 'history', routes });
