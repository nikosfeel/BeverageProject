<template>
  <div>
    <VueGoodTable
      styleClass="vgt-table table-hover table-bordered"
      :columns="columns"
      :rows="rows"
      :search-options="{
          enabled: true,
          trigger: 'keyup'
      }"
      :pagination-options="{
          enabled: true,
          mode: 'records',
          perPage: 10,
      }" >
      <template slot="table-row" slot-scope="props">
        <div v-if="props.column.field == 'PhotoUrl'">
          <img width="50px" :src="props.row.PhotoUrl" alt="">
        </div>
        <span v-else>
          {{props.formattedRow[props.column.field]}}
        </span>
        <div class="text-center" v-if="props.column.field == 'Actions'">
          <button class="btn btn-primary" @click="onDetails(props.row.ProductId)"><i class="fa fa-eye"></i></button>
          <button class="btn btn-warning" @click="onEdit(props.row.ProductId)"><i class="fa fa-edit"></i></button>
          <button class="btn btn-danger" @click="onDelete(props.row.ProductId)"><i class="fa fa-trash"></i></button>
        </div>
      </template>
    </VueGoodTable>
    <ProductEdit v-if="triggerProductEdit"/>
  </div>
</template>

<script>
import {VueGoodTable} from 'vue-good-table';
import mainService from '../../services/mainService.js';
import ProductEdit from './ProductEdit.vue';

export default {
  name: "ProductsTable",
  components:{
    VueGoodTable,
    ProductEdit
  },
  async mounted(){
    var result = await mainService.get('/api/allProducts');
    this.rows = result.data;
  },
  data(){
    return {
      triggerProductEdit: true,
      columns: [
        {
          label: 'ID',
          field: 'ProductId',
          type: 'number'
        },
        {
          label: 'Category',
          field: 'Category',
        },
        {
          label: 'PhotoUrl',
          field: 'PhotoUrl',
          sortable: false
        },
        {
          label: 'Name',
          field: 'Name',
        },
        {
          label: 'Price (€)',
          field: 'Price',
          width: '120px',
          type: 'number'
        },
        {
          label: 'Description',
          field: 'Description',
          sortable: false
        },
        {
          label: 'Actions',
          field: 'Actions',
          width: '200px',
          sortable: false
        },
      ],
      rows: [],
    };
  },
  methods:{
    async onDelete(id){
      this.rows = this.rows.filter(x=>x.ProductId != id)
      var result = await mainService.delete('api/AllProducts?id=' + id);
      if(result.status == 200){
        this.$snotify.success(`You deleted a ${result.data.Name}`,'Success!');
      }
      else{
        this.$snotify.error(`For some reason you cant delete ${result.data.Name}`,'Error!');
      }
    },
    onDetails(id){
      this.$router.replace('/ClientProducts/Details/' + id);
      location.reload();
    },
    onEdit(id){
      this.triggerProductEdit = !this.triggerProductEdit
    }
  }
};
</script>
<style scoped>
</style>
