import { useState } from "react";
import { useNavigate } from "react-router-dom";
import LoginForm from "./LoginForm";
import type { LoginFormValues } from "./LoginForm";
import { LoginUser } from "../../api/UserApi/UserApi";

export default function LoginPage() {
    const navigate = useNavigate();
    const [error, setError] = useState("");

    async function handleLogin(
        values: LoginFormValues
    ): Promise<void> {
        setError("");

        try {
            const user = await LoginUser(
                values.email,
                values.password
            );

            // Makes the returned user available to the Chat page.
            navigate("/Chat", {
                state: { user },
            });
        } catch (error) {
            setError(
                error instanceof Error
                    ? error.message
                    : "Failed to log in"
            );
        }
    }

    return (
        <>
            <LoginForm onLoginSubmit={handleLogin} />

            {error && <p role="alert">{error}</p>}
        </>
    );
}