<template>
  <el-table :data="tableData" style="width: 100%" max-height="250">
    <el-table-column prop="Name" label="Name" width="120"> </el-table-column>
    <el-table-column prop="Email" label="Email" width="250"> </el-table-column>
    <el-table-column prop="Theme" label="Theme" width="300"> </el-table-column>
    <el-table-column label="Operations" width="120">
      <template slot-scope="scope">
        <el-button
          @click.native.prevent="seeDescription(scope.$index, tableData)"
          type="text"
          size="small"
        >
          See Description
        </el-button>
      </template>
    </el-table-column>
  </el-table>
</template>

  <script>
export default {
  props: ["tableData", "init"],
  async mounted() {
    await this.init();
  },
  methods: {
    seeDescription(index, rows) {
      rows.splice(index, 1);
    },
  },
};
</script>