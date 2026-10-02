import type { CreateUserForm } from "../../Components/CreateUser/CreateUser";
import type { User } from "../../Types/User";
import type { UserLogin } from "../../Types/UserLogin";

const userApiUrl = "http://localhost:5065/api/User";

export async function GetUserById(id: number): Promise<User> {
    const response = await fetch(`${userApiUrl}/${id}`);

    if (!response.ok) {
        throw new Error(
            `Failed to fetch user with ID ${id}. Status: ${response.status}`
        );
    }

    const user: User = await response.json();
    return user;
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

    if (!response.ok) {
        const errorMessage = await response.text();

        throw new Error(
            errorMessage ||
            `Failed to create user. Status: ${response.status}`
        );
    }

    const createdUser: User = await response.json();
    return createdUser;
}

export async function LoginUser(email: string, password: string): Promise<UserLogin> {
    const response = await fetch(`${userApiUrl}/login`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, password }),
    });

    if (!response.ok) {
        const errorMessage = await response.text();
        throw new Error(
            errorMessage ||
            `Failed to login user. Status: ${response.status}`
        );
    }

    const userLogin: UserLogin = await response.json();
    return userLogin;
}

