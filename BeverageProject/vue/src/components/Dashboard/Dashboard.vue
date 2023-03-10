<template>
    <div class="row">
        <div class="col-md-12">
            <el-tabs type="border-card">
                <el-tab-pane label="Messages">
                    <div class="row">
                        <div class="col-md-6">
                            <MessagesTable />
                        </div>
                        <div class="col-md-6">
                            
                        </div>
                    </div>
                </el-tab-pane>
                <el-tab-pane label="???">Not yet implemented, give me ideas</el-tab-pane>
            </el-tabs>
        </div>
    </div>
</template>
<script>
import Products from '../Products/Products.vue';
import Orders from '../Orders/Orders.vue';
import MessagesTable from '../Messages/Admin/MessagesTable.vue';
export default {
    components: {
        Products,
        Orders,
        MessagesTable
    },
    name: 'Dashboard',

}
</script>