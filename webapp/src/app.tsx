import { LoginPage } from "modules/auth/components/loginPage";
import { BrowserRouter, Route, Routes } from "react-router-dom";

import { Router } from "./routes/index.route";
import { MenuLateral } from "./shared/components";
import { AppDrawerProvider, AppThemeProvider } from "./shared/contexts";

export const App = () => {
    const pathname = window.location.pathname;
    const ehLogin = pathname.indexOf("/login") != -1;
    return (
        <AppThemeProvider>
            <BrowserRouter>
                <Routes>
                    <Route path="/login" element={<LoginPage />} />
                </Routes>
                {!ehLogin && (
                    <AppDrawerProvider>
                        <MenuLateral>
                            <Router />
                        </MenuLateral>
                    </AppDrawerProvider>
                )}
            </BrowserRouter>
        </AppThemeProvider>
    );
};
