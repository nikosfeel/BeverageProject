<template>
  <div>
    <div class="row">
      <div class="col-md-3">
        <div class="panel panel-default">
          <div class="panel-heading">Order #{{ order.OrderId }}</div>
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
      <div class="col-md-9 pull-right">
        <VueGoodTable
          styleClass="vgt-table table-hover table-bordered"
          :columns="columns"
          :rows="rows"
          :search-options="{
            enabled: true,
            trigger: 'keyup',
          }"
        >
          <template slot="table-row" slot-scope="props">
            <div v-if="props.column.field == 'Product.Price'">
              <strong>{{ props.row.Product.Price.toFixed(2) }} €</strong>
            </div>
            <div v-if="props.column.field == 'Product.PhotoUrl'">
              <img width="100px" :src="props.row.Product.PhotoUrl" alt="" />
            </div>
            <span
              v-if="
                !(
                  props.column.field == 'Product.PhotoUrl' ||
                  props.column.field == 'Product.Price'
                )
              "
            >
              {{ props.formattedRow[props.column.field] }}
            </span>
          </template>
        </VueGoodTable>
        <div class="vgt-wrap__footer vgt-clearfix">
          <h3>
            <strong>Total</strong>
            <span class="pull-right">{{ order.Total.toFixed(2) }} €</span>
          </h3>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import mainService from "../../services/mainService.js";
import { VueGoodTable } from "vue-good-table";

export default {
  components: {
    VueGoodTable,
  },
  data() {
    return {
      order: {},
      columns: [
        {
          label: "PhotoUrl",
          field: "Product.PhotoUrl",
          width: "10px",
          sortable: false,
        },
        {
          label: "Name",
          field: "Product.Name",
        },
        {
          label: "Category",
          field: "Product.Category.Title",
        },
        {
          label: "Quantity",
          field: "Quantity",
          type: "number",
        },
        {
          label: "Price (€)",
          field: "Product.Price",
          width: "120px",
          type: "number",
        },
      ],
      rows: [],
    };
  },
  async mounted() {
    var result = await mainService.get("api/Orders/" + this.$route.query.id);
    this.rows = result.data.Products;
    this.order = result.data.Order;
    console.log(result);
  },
};
</script>
