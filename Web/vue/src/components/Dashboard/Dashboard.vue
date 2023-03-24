<template>
    <div class="row">
        <div class="col-md-12">
            <el-tabs type="border-card">
                <el-tab-pane label="Messages">
                    <div class="row">
                        <div class="col-md-6">
                            <MessagesTable :tableData="tableData" :init="init"/>
                        </div>
                        <div class="col-md-6">
                            <MessageDetailsVue />
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
import MessageDetailsVue from '../Messages/Admin/MessageDetails.vue';
import mainService from "../../services/mainService.js";

export default {
    components: {
        Products,
        Orders,
        MessagesTable,
        MessageDetailsVue
    },
    name: 'Dashboard',
    data(){
        return {
            tableData: [],
        }
    },
    
    methods:{
        async init() {
            var response = await mainService.get("/api/Message");
            this.tableData = response.data;
        },
    }

}
</script>