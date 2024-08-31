import Axios from 'axios';

const createAxios = Axios.create({
    baseURL: "https://localhost:7044"
});

export default createAxios;