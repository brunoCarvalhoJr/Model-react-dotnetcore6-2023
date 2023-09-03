import { LoginPage } from "modules/auth/components/loginPage";
import { useAuth } from "modules/auth/hooks/useAuthHook";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Outlet } from "react-router-dom";

import { Router } from "./routes/index.route";
import { MenuLateral } from "./shared/components";
import { AppDrawerProvider, AppThemeProvider } from "./shared/contexts";

export const App = () => {
    const auth = useAuth();
    return (
        <AppThemeProvider>
            <BrowserRouter>
                <Routes>
                    <Route path="/login" element={<LoginPage />} />
                </Routes>
                {auth.user ? (
                    <AppDrawerProvider>
                        <MenuLateral>
                            <Router />
                        </MenuLateral>
                    </AppDrawerProvider>
                ) : (
                    <Outlet />
                )}
            </BrowserRouter>
        </AppThemeProvider>
    );
};
