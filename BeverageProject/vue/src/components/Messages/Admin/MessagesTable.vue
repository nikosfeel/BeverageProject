<template>
    <el-table
      :data="tableData"
      style="width: 100%"
      max-height="250">
      <el-table-column
        prop="Name"
        label="Name"
        width="120">
      </el-table-column>
      <el-table-column
        prop="Email"
        label="Email"
        width="250">
      </el-table-column>
      <el-table-column
        prop="Theme"
        label="Theme"
        width="300">
      </el-table-column>
      <el-table-column
        label="Operations"
        width="120">
        <template slot-scope="scope">
          <el-button
            @click.native.prevent="deleteRow(scope.$index, tableData)"
            type="text"
            size="small">
            See Details
          </el-button>
        </template>
      </el-table-column>
    </el-table>
  </template>

  <script>
  import mainService from '../../../services/mainService.js'
    export default {
      data() {
        return {
          tableData: [{
            name: 'Tom',
            email: 'admin@gmail.com',
            title: 'Los Angeles',
          }]
        }
      },
      async mounted(){
        await this.init();
      },
      methods:{
        deleteRow(index, rows) {
          rows.splice(index, 1);
        },
        async init(){
            var response = await mainService.get('/api/Message');
            console.log(response.data);
            this.tableData = response.data;
        }
      }
    }
  </script>