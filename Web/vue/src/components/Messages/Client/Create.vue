<template>
    <div class="contact-form">
        <div class="row">
            <div class="form-group col-md-12 col-sm-12 col-xs-12 paira-margin-top-1 margin-bottom-0">
                <input type="text" class="form-control" name="contact[name]" disabled v-model="message.Name">
                <span class="center-block"><label>Name</label></span>
            </div>
            <div class="form-group col-md-12 col-sm-12 col-xs-12 paira-margin-top-1 margin-bottom-0">
                <input type="email" class="form-control" name="contact[email]" disabled v-model="message.Email">
                <span class="center-block"><label>Email</label></span>
            </div>
            <div class="form-group col-md-12 col-sm-12 col-xs-12 paira-margin-top-1 margin-bottom-0">
                <input type="text" class="form-control" name="contact[phone]" v-model="message.Phone">
                <span class="center-block"><label>Phone</label></span>
            </div>
            <div class="form-group col-md-12 col-sm-12 col-xs-12 paira-margin-top-1 margin-bottom-0">
                <input type="text" class="form-control" name="contact[phone]" v-model="message.Theme">
                <span class="center-block"><label>Theme</label></span>
            </div>
            <div class="form-group col-md-12 col-sm-12 col-xs-12 paira-margin-top-1 margin-bottom-0">
                <textarea rows="8" name="contact[body]" class="form-control" v-model="message.Description"></textarea>
            </div>
        </div>
        <button
        @click="sendMessage"
            class="btn btn-default btn-lg color-scheme-2 pull-right text-uppercase paira-margin-top-1 raleway-light">Send
            Message</button>
    </div>
</template>
<script>
import mainService from '../../../services/mainService.js';

export default {
    name:'ClientMessageCreate',
    async mounted(){
        await this.buildMessage();
    },
    data(){
        return {
            message:{
                Name: '',
                Email: '',
                Phone: '',
                Theme: '',
                Description: '',
            }
        }
    },
    methods:{
        async getUser(){
            var response = await mainService.get('/api/Users');
            this.message.Name = response.data.UserName;
            this.message.Email = response.data.Email;
            return response.data;
        },
        async buildMessage(){
            var user = await this.getUser();
            this.message.Phone = user.PhoneNumber;
            this.message.Theme = ''
            this.message.Description = ''
        },
        async sendMessage(){
            if(this.hasValidationErrors()){
                this.$snotify.error(`You must enter all the fields`,'Error!!');
                return;
            }
            this.getUser();
            var response = await mainService.post('api/Message', this.message);
            if (response.status == 200){
                this.$snotify.success(`Thank you for your message!`,'Success!');
                this.$router.replace('/Home');
                this.$router.go();
            }
        },
        hasValidationErrors(){
            return this.message.Email == '' ||
                    this.message.Theme == '' ||
                    this.message.Description == '' ||
                    this.message.PhoneNumber == '' ||
                    this.message.UserName == ''
        }
    }
}
</script>