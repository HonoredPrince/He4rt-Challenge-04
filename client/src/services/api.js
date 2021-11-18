import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:44300',
    //baseURL: 'https://localhost:5001', //Local URL
})

export default api;
