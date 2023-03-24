import axios from 'axios';
import router from '../router'


const instance = axios.create({
    baseURL: `${location.origin}/`
});

export default instance;