import baseApi from "shared/api";

const base = "/auth";

export default {
    login(data: any) {
        return baseApi.post(`${base}/login`, data, { withCredentials: true });
    },
};
