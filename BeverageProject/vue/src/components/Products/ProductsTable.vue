<template>
    <div>
        <VueGoodTable styleClass="vgt-table table-hover table-bordered" :columns="columns" :rows="rows" :search-options="{
            enabled: true,
            trigger: 'keyup'
        }" :pagination-options="{
                enabled: true,
                mode: 'records',
                perPage: 10,
            }">
            <template slot="table-row" slot-scope="props">
                <div v-if="props.column.field == 'PhotoUrl'">
                    <img width="50px" :src="props.row.PhotoUrl" alt="">
                </div>
                <span v-else>
                    {{ props.formattedRow[props.column.field] }}
                </span>
                <div class="text-center" v-if="props.column.field == 'Actions'">
                    <el-row>
                        <el-button type="info" class="fa fa-eye" circle @click="onDetails(props.row.ProductId)"></el-button>
                        <el-button type="primary" class="fa fa-edit" circle
                            @click="onEdit(props.row.ProductId)"></el-button>
                        <el-button type="danger" class="fa fa-trash" circle
                            @click="onDelete(props.row.ProductId)"></el-button>
                    </el-row>
                </div>
            </template>
        </VueGoodTable>
        <ProductEdit v-if="editData.showDrawer" :editData="editData" :init="init" />
    </div>
</template>

<script>
import { VueGoodTable } from 'vue-good-table';
import mainService from '../../services/mainService.js';
import ProductEdit from './ProductEdit.vue';

export default {
    name: "ProductsTable",
    components: {
        VueGoodTable,
        ProductEdit
    },
    async mounted() {
        await this.init();
    },
    data() {
        return {

            editData: {
                showDrawer: false,
                id: 0
            },
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
    methods: {
        async init() {
            var result = await mainService.get('/api/allProducts');
            if (result.status == 200)
                this.rows = result.data;
            else
                this.$snotify.error(`Something went Wrong`, 'Error!');
        },
        async onDelete(id) {
            this.$confirm('This will permanently delete the file. Continue?', 'Warning', {
                confirmButtonText: 'OK',
                cancelButtonText: 'Cancel',
                type: 'warning'
            }).then(async () => {
                this.rows = this.rows.filter(x => x.ProductId != id)
                var result = await mainService.delete('api/AllProducts?id=' + id);
                if (result.status == 200) {
                    this.$snotify.success(`You deleted a ${result.data.Name}`, 'Success!');
                }
                else {
                    this.$snotify.error(`For some reason you cant delete ${result.data.Name}`, 'Error!');
                }
            });

        },
        onDetails(id) {
            this.$router.replace('/ClientProducts/Details/' + id);
            location.reload();
        },
        onEdit(id) {
            this.editData.id = id;
            this.editData.showDrawer = !this.editData.showDrawer;
        },
        onDetails(id) {
            this.$router.replace(`/ClientProducts/Details/${id}`);
            this.$router.go();
        }
    }
};
</script>
<style scoped></style>
