<template>
<div>
    <OrdersTable />
</div>
</template>
<script>
import OrdersTable from './OrdersTable.vue';

export default {
    name:'Orders',
    components:{
        OrdersTable,
    }
}
</script>