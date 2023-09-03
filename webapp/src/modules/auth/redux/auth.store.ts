import { createSlice } from "@reduxjs/toolkit";

import { login } from "./auth.requestOld";

type login = {
    email: string;
    password: string;
};

const initialState = {
    Email: 1,
    Password: "ttt",
};

export const slice = createSlice({
    name: "auth",
    initialState: initialState,
    reducers: {
        /*setCredentials: (
            state,
            {
                payload: { user, token },
            }: PayloadAction<{ user: User; token: string }>,
        ) => {
            state.user = user;
            state.token = token;
        },*/
        loginAuth(state, { payload }: any) {
            login(payload);
        },
        setAuth(state, { payload }) {
            return {
                ...state,
                ...payload,
            };
        },
        resetAuth() {
            return initialState;
        },
        /*deleteProjeto(state, { payload }) {
            deletar(payload);
        },*/
    },
});

export const { setAuth, resetAuth, loginAuth } = slice.actions;

export const selectAuth = (state: any) => state.auth;

export default slice.reducer;
/*
export async function asyncLogin({ email, password }: login) {
    async function teste() {
        const { data } = await api.login({ email, password });
        console.log(data);
        resetAuth();
    }
    teste();
}*/
/*
export const login = async ({ email, password }: login) => {
    console.log("password: ", password);
    console.log("email: ", email);
    const { data } = await api.login({ email, password });

    if (data)
        axios.defaults.headers.common[
            "Authorization"
        ] = `Bearer ${data?.token}`;
};
*/
