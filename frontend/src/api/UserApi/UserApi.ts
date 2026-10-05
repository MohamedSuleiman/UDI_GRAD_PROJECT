import axios from "axios";
import type { CreateUserForm } from "../../Components/CreateUser/CreateUser";
import type { User } from "../../Types/User";
import type { UserLogin } from "../../Types/UserLogin";

const apiUrl = (
    import.meta.env.VITE_API_URL || "http://localhost:5065"
).replace(/\/$/, "");

const userApiUrl = `${apiUrl}/api/User`;


export async function GetUserById(id: number): Promise<User> {
    const response = await axios.get<User>(`${userApiUrl}/${id}`);
    const user = await response.data;
    return user;
}

export async function CreateUser(
    user: CreateUserForm
): Promise<User> {
    const response = await axios.post(`${userApiUrl}`, user, {
        headers: {
            "Content-Type": "application/json",
        },
    });

    return response.data;
}

export async function LoginUser(
    email: string,
    password: string
): Promise<UserLogin> {
    const response = await axios.post(`${userApiUrl}/login`, { email, password }, {
        headers: {
            "Content-Type": "application/json",
        },
    });

    return response.data;
}

export async function ChangeUserInformation(
    id: number,
    updatedUser: Partial<User>
): Promise<User> {
    const response = await axios.put(`${userApiUrl}/${id}`, updatedUser, {
        headers: {
            "Content-Type": "application/json",
        },
    });

    return response.data;
}