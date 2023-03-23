import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import axios from 'axios';
import Cart from './components/Cart/Cart.vue'

createApp(App).use(router).mount("#app-new");
createApp(Cart).mount("#app-cart");

