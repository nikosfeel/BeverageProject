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
      :pagination-options="{
        enabled: true,
        mode: 'records',
        perPage: 10,
      }"
      :sort-options="{
        enabled: true,
        initialSortBy: { field: 'OrderId', type: 'desc' },
      }"
      >
      <template slot="table-row" slot-scope="props">
        <div class="text-center" v-if="props.column.field == 'Actions'">
          <button
            class="btn btn-primary"
            @click="$router.replace(`/Customers/OrderDetails?id=${props.row.OrderId}`)"
          >
            <i class="fa fa-eye"></i>
          </button>
        </div>
      </template>
    </VueGoodTable>
  </div>
</template>
<script>
import { VueGoodTable } from "vue-good-table";
import mainService from "../../services/mainService.js";

export default {
  components: {
    VueGoodTable,
  },
  data() {
    return {
      columns: [
        {
          label: "ID",
          field: "OrderId",
          type: "number",
        },
        {
          label: "FullName",
          field: "FullName",
        },
        {
          label: "Email",
          field: "Email",
          sortable: false,
        },
        {
          label: "OrderDate",
          field: "OrderDate",
        },
        {
          label: "Status",
          field: "HasBeenShipped",
        },
        {
          label: "Total",
          field: "Total",
          width: "120px",
          type: "number",
        },
        {
          label: "Actions",
          field: "Actions",
          width: "100px",
          sortable: false,
        },
      ],
      rows: [],
    };
  },
  async mounted() {
    var result = await mainService.get("api/Orders");
    if (result.status == 200)
      this.rows = result.data.map((x) => {
        x.HasBeenShipped = x.HasBeenShipped ? 'Shipped' : 'Not Shipped'
        x.OrderDate = `${new Date(x.OrderDate).toLocaleDateString()} ${new Date(
          x.OrderDate
        ).toLocaleTimeString()}`;
        return x;
      });
    else this.$snotify.error(`Something went Wrong`, "Error!");
  },
};
</script>
