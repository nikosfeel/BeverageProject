<template>
  <div>
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
          <p>{{ props.row.Product.Price.toFixed(2) }} €</p>
        </div>
        <div v-if="props.column.field == 'Product.fullPrice'">
          <strong>{{ props.row.Product.fullPrice.toFixed(2) }} €</strong>
        </div>
        <div v-if="props.column.field == 'Product.PhotoUrl'">
          <img width="100px" :src="props.row.Product.PhotoUrl" alt="" />
        </div>
        <span
          v-if="
            !(
              props.column.field == 'Product.PhotoUrl' ||
              props.column.field == 'Product.fullPrice' ||
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
        <span class="pull-right">{{ parseFloat(order.Total).toFixed(2) }} €</span>
      </h3>
    </div>
  </div>
</template>
<script>
import { VueGoodTable } from "vue-good-table";

export default {
  components: {
    VueGoodTable,
  },
  props: ["rows", "order"],
  data() {
    return {
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
          width: "120px",
          field: "Product.Category.Title",
        },
        {
          label: "Quantity",
          field: "Quantity",
          width: "120px",
          type: "number",
        },
        {
          label: "Unit Price",
          field: "Product.Price",
          width: "140px",
          type: "number",
        },
        {
          label: "Total Price",
          field: "Product.fullPrice",
          width: "140px",
          type: "number",
        },
      ],
    };
  },
};
</script>
