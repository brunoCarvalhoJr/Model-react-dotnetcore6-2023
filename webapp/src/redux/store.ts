import { Action, ThunkAction, configureStore } from "@reduxjs/toolkit";

//importa todos os arquivos Slices
import { useDispatch } from "react-redux";

import { slices } from "../shared/imports";

const makeSlice = () => {
    const refactReducers: any = [];
    //retira todos os slices dos componentes importados
    slices.keys().forEach((Name: string) => {
        const module = slices(Name);
        const reducer = slices(Name).default;
        refactReducers.push({
            name: module.slice.name,
            reducer,
        });
    });

    //Remonta o objeto com todos os Slices(reducers) para store
    const keys = Object.keys(refactReducers);
    const newReducers: any = {};

    for (let i = 0; i < keys.length; i++) {
        const key = keys[i];
        const nameReducer = refactReducers[key].name;
        const prop = refactReducers[key];
        newReducers[nameReducer] = prop.reducer;
    }

    console.log("newReducers: ", newReducers);
    return newReducers;
};
export const store = configureStore({
    reducer: makeSlice(),
});

export type RootState = ReturnType<typeof store.getState>;

export type AppDispatch = typeof store.dispatch;

export type AppThunk = ThunkAction<void, RootState, null, Action<string>>;

export const useAppDispatch = () => useDispatch<AppDispatch>();

export default store;
