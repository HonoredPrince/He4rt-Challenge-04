import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:44300',
    //Local: baseURL: 'https://localhost:5001',
})

export default api;
