import type { User, CreateUserRequest } from "../../Types/User";

export async function GetUserById(id: number): Promise<User> {
    const response = await fetch(`http://localhost:5065/api/User/${id}`);
    if (!response.ok) {
        throw new Error(`Failed to fetch user with ID ${id}`);
    }
    const user: User = await response.json();
    return user;
}

export async function CreateUser(user: CreateUserRequest): Promise<User> {
    const response = await fetch("http://localhost:5065/api/User", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(user),
    });
    if (!response.ok) {
        throw new Error("Failed to create user");
    }
    const createdUser: User = await response.json();
    return createdUser;
}