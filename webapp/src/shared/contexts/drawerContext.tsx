import { createContext, useContext, useState, useCallback } from "react";

interface IDrowerContextData {
    isDrawerOpen: boolean;
    toogleDrawerOpen: () => void;
    drawerOptions: any[];
    setDrawerOptions: (newDrawerOptions: any[]) => void;
}

type DrawerProviderProps = {
    children: any;
};

const DrawerContext = createContext({} as IDrowerContextData);

export const useDrawerContext = () => {
    return useContext(DrawerContext);
};

export const AppDrawerProvider: any = (props: DrawerProviderProps) => {
    const [drawerOptions, setDrawerOptions] = useState<any[]>([]);

    const [isDrawerOpen, setIsDrawerOpen] = useState(false);

    const toogleDrawerOpen = useCallback(() => {
        setIsDrawerOpen((oldDrawerOpen) => !oldDrawerOpen);
    }, []);

    const handleSetDrawerOptions = useCallback((newDrawerOptions: any[]) => {
        setDrawerOptions(newDrawerOptions);
    }, []);

    return (
        <DrawerContext.Provider
            value={{
                isDrawerOpen,
                drawerOptions,
                toogleDrawerOpen,
                setDrawerOptions: handleSetDrawerOptions,
            }}
        >
            {props.children}
        </DrawerContext.Provider>
    );
};
