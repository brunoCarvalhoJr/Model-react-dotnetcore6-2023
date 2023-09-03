import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { Environment } from "shared/environment";

import { RootState } from "../../../redux/store";

export interface IUser {
    first_name: string;
    last_name: string;
}

export interface IUserResponse {
    user: IUser;
    token: string;
}

export interface ILoginRequest {
    email: string;
    password: string;
}

export const api = createApi({
    baseQuery: fetchBaseQuery({
        baseUrl: `${Environment.URL_BASE}/`,
        prepareHeaders: (headers, { getState }) => {
            // Por padrão, se tivermos um token na store, vamos usá-lo para solicitações autenticadas
            const token = (getState() as RootState).auth.token;
            if (token) {
                headers.set("authorization", `Bearer ${token}`);
            }
            return headers;
        },
    }),
    endpoints: (builder) => ({
        login: builder.mutation<IUserResponse, ILoginRequest>({
            query: (credentials) => ({
                url: "auth/login",
                method: "POST",
                body: credentials,
            }),
        }),
        protected: builder.mutation<{ message: string }, void>({
            query: () => "protected",
        }),
    }),
});

export const { useLoginMutation, useProtectedMutation } = api;
