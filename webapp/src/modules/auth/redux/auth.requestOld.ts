import axios from "axios";

import api from "../service/auth.api";

/*export const criar = () => {
''
};

export const atualizar = () => {
''
};*/
type login = {
    email: string;
    password: string;
};
/*


export function asyncLogin(): AppThunk {
    return async function (dispatch: AppDispatch) {};
}
*/
export const login = async (payload: any) => {
    console.log("password: ", payload);
    const { data } = await api.login({
        email: payload.email,
        password: payload.password,
    });
    console.log("data: ", data);

    if (data)
        axios.defaults.headers.common[
            "Authorization"
        ] = `Bearer ${data?.token}`;
};
/*
export const deletar = async ({ id, reloadGrid }: any) => {
    try {
        await api.delete(id).then(async (response) => {
            if (response.status === 204) {
                reloadGrid();
            } else {
                console.log("erro aqui");
            }
        });
    } catch (error: any) {
        console.error(error.message);
    }
};*/
