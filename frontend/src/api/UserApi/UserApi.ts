import type { CreateUserForm } from "../../Components/CreateUser/CreateUser";
import type { User } from "../../Types/User";
import type { UserLogin } from "../../Types/UserLogin";

const apiUrl = (
    import.meta.env.VITE_API_URL || "http://localhost:5065"
).replace(/\/$/, "");

const userApiUrl = `${apiUrl}/api/User`;

async function checkResponse(response: Response): Promise<void> {
    if (!response.ok) {
        const message = await response.text();

        throw new Error(
            message || `Request failed. Status: ${response.status}`
        );
    }
}

export async function GetUserById(id: number): Promise<User> {
    const response = await fetch(`${userApiUrl}/${id}`);

    await checkResponse(response);

    return await response.json();
}

export async function CreateUser(
    user: CreateUserForm
): Promise<User> {
    const response = await fetch(userApiUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(user),
    });

    await checkResponse(response);

    return await response.json();
}

export async function LoginUser(
    email: string,
    password: string
): Promise<UserLogin> {
    const response = await fetch(`${userApiUrl}/Login`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, password }),
    });

    await checkResponse(response);

    return await response.json();
}