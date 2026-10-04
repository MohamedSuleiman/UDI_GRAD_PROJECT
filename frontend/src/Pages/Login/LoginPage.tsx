import { useState } from "react";
import { useNavigate } from "react-router-dom";
import LoginForm from "./LoginForm";
import type { LoginFormValues } from "./LoginForm";
import { LoginUser } from "../../api/UserApi/UserApi";
import { useAuth } from "../../Context/authContext/AuthContext";

export default function LoginPage() {
  const navigate = useNavigate();
  const [error, setError] = useState("");
  const { loginUser } = useAuth();

  async function handleLogin(values: LoginFormValues): Promise<void> {
    setError("");

    try {
      const user = await LoginUser(values.email, values.password);


      loginUser(user);
      navigate("/Chat");
    } catch (error) {
      setError(
        error instanceof Error ? error.message : "Failed to log in"
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
