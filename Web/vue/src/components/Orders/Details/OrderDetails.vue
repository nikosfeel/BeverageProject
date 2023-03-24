<template>
  <div class="row">
    <div class="col-md-4">
      <OrderPanel :order="order" :init="init" />
    </div>
    <div class="col-md-8 pull-right">
      <OrderDetailsProducts :rows="rows" :order="order" />
    </div>
  </div>
</template>
<script>
import mainService from "../../../services/mainService.js";
import OrderDetailsProducts from "./OrderDetailsProducts.vue";
import OrderPanel from "./OrderPanel.vue";

export default {
  components: {
    OrderDetailsProducts,
    OrderPanel,
  },
  data() {
    return {
      order: {},
      rows: [],
    };
  },
  async mounted() {
    await this.init();
  },
  methods: {
    async init() {
      var result = await mainService.get("api/Orders/" + this.$route.query.id);
      this.rows = result.data.Products.map((x) => {
        x.Product.fullPrice = x.Product.Price * x.Quantity;
        return x;
      });
      this.order = result.data.Order;
    },
  },
};
</script>
