import { createContext, useContext, useState } from "react";
import type { ReactNode } from "react";


interface LogedInUser {
    id: number;
}

interface AuthContextValue {
    user: LogedInUser | null;
    loginUser: (user: LogedInUser) => void;
    logoutUser: () => void;
}

const AuthContext = createContext<AuthContextValue | undefined>(undefined);


export function AuthProvider({ children }: { children: ReactNode }) {
    const [user, setUser] = useState<LogedInUser | null>(null);

    function loginUser(user: LogedInUser) {
        setUser(user);
    }

    function logoutUser() {
        setUser(null);
    }

    return (
        <AuthContext.Provider value={{ user, loginUser, logoutUser }}>
            {children}
        </AuthContext.Provider>
    );

}

export function useAuth() {
    const context = useContext(AuthContext);

    if (context === undefined) {
        throw new Error("useAuth must be used inside AuthProvider");
    }

    return context;
}
