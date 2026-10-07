import { useState } from "react";
import type { CreateUserForm as FormValues } from "../../Components/CreateUser/CreateUser";
import { CreateUser } from "../../api/UserApi/UserApi";
import { useNavigate } from "react-router-dom";
import CreateUserForm from "../../Components/CreateUser/CreateUser";

export default function CreateUserPage() {
    const [error, setError] = useState("");
    const [success, setSuccess] = useState("");
    const navigate = useNavigate();

    async function handleCreateUser(values: FormValues): Promise<void> {
        setError("");
        setSuccess("");

        try {
            console.log("Calling CreateUser API");

            await CreateUser(values);

            setSuccess("User created successfully!");
            navigate("/Login");
        } catch (error) {
            setError(
                error instanceof Error
                    ? error.message
                    : "Failed to create user"
            );
        }
    }

    return (
        <>
            <CreateUserForm onCreated={handleCreateUser} />

            {error && <p role="alert">{error}</p>}
            {success && <p role="status">{success}</p>}
        </>
    );
}