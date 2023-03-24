<template>
  <div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4>
          Order #{{ order.OrderId }}
          <button class="btn btn-primary ship-status" @click="markAsShipped">
            {{ order.HasBeenShipped ? "Unship" : "Ship" }}
          </button>
          <button
            @click="$router.replace('/Customers/Orders')"
            class="btn back-to-list"
          >
            Back to Orders
          </button>
        </h4>
      </div>
      <div class="panel-body">
        <h5>
          <p><strong>Name:</strong> {{ order.FullName }}</p>
          <p><strong>Address:</strong> {{ order.Address }}</p>
          <p><strong>City:</strong> {{ order.City }}</p>
          <p><strong>Postal Code:</strong> {{ order.PostalCode }}</p>
          <p><strong>E-Mail:</strong> {{ order.Email }}</p>
          <p><strong>Phone:</strong> {{ order.Phone }}</p>
        </h5>
      </div>
    </div>
  </div>
</template>
<script>
import mainService from "../../../services/mainService.js";

export default {
  name: "OrderPanel",
  props: ["order", "init"],
  methods: {
    async markAsShipped() {
      var result = await mainService.put("api/Orders/" + this.$route.query.id);
      if (result.status == 200) {
        await this.init();
      }
    },
  },
};
</script>
<style scoped>
.panel-heading h4 .ship-status {
  position: absolute;
  top: 15px;
  right: 160px;
}
.back-to-list {
  background: #8b8b8b;
  color: white;
  position: absolute;
  top: 15px;
  right: 28px;
}
.back-to-list:hover {
  background: #4e4e4e;
  color: white;
}
</style>