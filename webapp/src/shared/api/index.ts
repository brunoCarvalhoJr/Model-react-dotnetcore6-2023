import axios from "axios";

import { Environment } from "../environment";
import {
    responseInterceptor,
    errorInterceptor,
    requestInterceptor,
} from "./interceptors";

const Axios = axios.create({
    baseURL: Environment.URL_BASE,
});

Axios.interceptors.request.use(
    (config) => requestInterceptor(config),
    (error) => errorInterceptor(error),
);

Axios.interceptors.response.use(
    (response) => responseInterceptor(response),
    (error) => errorInterceptor(error),
);

export default Axios;
