<template>
  <div>
    <div v-for="(product, index) in products" :key="index">
      <div class="column full-width overflow paira-margin-bottom-4">
        <div class="row-1">
          <img
            :src="product.Product.PhotoUrl"
            alt=""
            class="img-responsive center-block"
          />
        </div>
        <div class="row-2 text-white">
          <p>
            <a href="#">{{ product.Product.Name }}</a>
          </p>
        </div>
        <div class="row-3">
          <p>{{ product.Product.Price }} €</p>
        </div>

        <div class="row-4">
          <div class="quantity">
            <div class="quantity-fix display-inline-b">
              <button
                class="btn btn-default"
                data-direction="down"
                @click="buttonDown(product.Product.ProductId)"
              >
                <i class="fa fa-angle-down"></i>
              </button>
              <input
                type="text"
                disabled='disabled'
                :value="product.Quantity"
                class="text-center product_quantity_text"
              />
              <button
                class="btn btn-success"
                data-direction="down"
                @click="buttonUp(product.Product.ProductId)"
              >
                <i class="fa fa-angle-up"></i>
              </button>
            </div>
          </div>
        </div>
        <div class="row-5">
          <p @click="buttonDelete(product.Product.ProductId)" class="delete-p">
            <i class="fa fa-trash fa-2x"></i>
          </p>
        </div>
      </div>
    </div>
    <div class="col-md-12 col-sm-12 col-xs-12 pull-right text-right">
        <h3 class="text-color-1">Total : <span><b>{{ total }} €</b></span></h3>
        <a href="/Cart/Index" class="btn btn-success updat btn-lg margin-top-20 margin-left-20">Continue Shopping</a>
        <a href="/Checkout/CreateOrder" class="btn btn-success btn-lg checkout margin-top-20 margin-left-20">Checkout</a>
      </div>
  </div>
</template>
<script>
import mainService from "../../services/mainService.js";

export default {
  data() {
    return {
      products: [],
    };
  },
  async mounted() {
    this.getItems();
  },
  methods: {
    async getItems() {
      var result = await mainService.get("Cart/GetCartItems");
      this.products = result.data;
    },
    async buttonUp(id) {
      await mainService.post("/Cart/ButtonUp?id=" + id);
      this.getItems();
    },
    async buttonDown(id) {
      await mainService.post("/Cart/ButtonDown?id=" + id);
      this.getItems();
    },
    async buttonDelete(id) {
      await mainService.post("/Cart/Remove?id=" + id);
      this.getItems();
    },
  },
  computed: {
    total() {
      var array = this.products.map((x) => x.Product.Price * x.Quantity);
      let sum = 0;
      let i = -1;
      while (++i < array.length) {
        sum += array[i];
      }

      return sum.toFixed(2);
    },
  },
};
</script>
<style scoped>
.delete-p {
  color: white;
  cursor: pointer;
}
.row-1{
    height: 69px;
}
.row-2{
    height: 69px;
}
.row-3{
    height: 69px;
}
.row-4{
    height: 69px;
}
.row-5{
    height: 69px;
    transition: 1s;
    text-align: center;
    
}
.row-5:hover{
  background-color: rgba(240, 248, 255, 0.154) ;
}
</style>