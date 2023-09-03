import { useAuth } from "modules/auth/hooks/useAuthHook";
import { Navigate, Outlet, useLocation } from "react-router-dom";

export function PrivateOutlet() {
    const auth = useAuth();
    const location = useLocation();

    return auth.user ? (
        <Outlet />
    ) : (
        <Navigate to="/login" state={{ from: location }} />
    );
}
