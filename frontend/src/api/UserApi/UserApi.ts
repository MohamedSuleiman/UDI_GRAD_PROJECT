import type { User, CreateUserRequest } from "../../Types/User";
import axios from "axios";

export async function GetUserById(id: number): Promise<User> {
    const response = await axios.get(`http://localhost:5065/api/User/${id}`);
    if (!response.data) {
        throw new Error(`Failed to fetch user with ID ${id}`);
    }
    const user: User = response.data;
    return user;
}

export async function CreateUser(user: CreateUserRequest): Promise<User> {
    const response = await axios.post(`http://localhost:5065/api/User`, user, { headers: { "Content-Type": "application/json" } });
    if (!response.data) {
        throw new Error("Failed to create user");
    }
    const createdUser: User = response.data;
    return createdUser;
}

export async function LoginUser(email: string, password: string): Promise<User> {
    const response = await axios.post(`http://localhost:5065/api/User/Login`, { email, password }, { headers: { "Content-Type": "application/json" } });
    if (!response.data) {
        throw new Error("Failed to login user");
    }
    
    const user: User = response.data;
    return user;
}
