<template>
 <Modal
      v-model="editData.showDrawer"
      title="Edit"
      wrapper-class="animate__animated"
      modal-class="drawer"
      in-class="animate__fadeInRight"
      out-class="animate__fadeOutRight"
    >
      <form novalidate>
        <div class="form-group">
          <label for="inputEmail4">Name</label>
          <input id="inputEmail4" type="text" class="form-control" placeholder="Name" v-model="product.Name"/>
        </div>
        <div class="form-group">
          <label for="inputAddress">Price €</label>
          <input id="inputAddress" type="text" class="form-control" placeholder="12.90" v-model="product.Price" />
        </div>
        <div class="form-group">
          <label for="inputAddress2">Description</label>
          <textarea class="form-control" cols="30" rows="10" placeholder="Description" v-model="product.Description"></textarea>
        </div>
          <div class="form-group ">
            <label for="inputCity" >PhotoUrl</label>
            <input id="inputCity" type="text" class="form-control" v-model="product.PhotoUrl" />
          </div>
        <div class="row modal-footer">
          <div class="col-sm-12">
            <div class="float-right">
              <button class="btn btn-success" type="button" @click="onSubmit()">Submit</button>
              <button class="btn btn-secondary ml-2" type="button" @click="editData.showDrawer = false">Cancel</button>
            </div>
          </div>
        </div>
      </form>
    </Modal>
</template>
<script>
import mainService from '../../services/mainService.js';

export default {
    props:['editData','init'],
    async mounted(){
        var result = await mainService.get('/api/allProducts/' + this.editData.id);
        this.product = result.data;
    },
    data(){
        return{
            product:{},
        }
    },
    methods:{
        async onSubmit(){
            var result = await mainService.put('/api/allProducts/', this.product);

            if(result.status == 200)
                this.$snotify.success(`You edited ${result.data.Name}`,'Success!');
            else
                this.$snotify.error(`For some reason you cant delete ${result.data.Name}`,'Error!');

            await this.init();

            this.editData.showDrawer = false
        }
    }
};
</script>
<style>
@import 'animate.css/animate.css';
.vm.drawer {
  top: 0px;
  margin: 0px 0px 0px auto;
  height: 100%;
  width: 100%;
  max-width: 750px;
}
.vm-content {
  background: #fff;
}
.modal-footer {
  padding: 15px 0px 0px 0px;
  border-top: 1px solid #e5e5e5;
  margin-left: -14px;
  margin-right: -14px;
}
</style>