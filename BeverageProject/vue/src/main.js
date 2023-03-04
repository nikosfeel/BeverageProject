import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import VueGoodTablePlugin from 'vue-good-table';
import axios from 'axios';
import Snotify from 'vue-snotify';
import 'vue-snotify/styles/material.css';
import 'vue-good-table/dist/vue-good-table.css';
import Cart from './components/Cart/Cart.vue';
import VueModal from '@kouts/vue-modal'
import '@kouts/vue-modal/dist/vue-modal.css'

Vue.component('Modal', VueModal)
Vue.use(VueGoodTablePlugin);
Vue.use(Snotify,{
  toast:{
    timeout: 1000,
    position: "centerTop"
  },
});
Vue.config.productionTip = false;

new Vue({
  el: '#app',
  router: router,
  store,
  render: h => h(App)
});
new Vue({
  el: '#app-cart',
  render: h => h(Cart)
});