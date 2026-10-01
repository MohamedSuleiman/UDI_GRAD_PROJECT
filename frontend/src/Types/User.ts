export interface User {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    nationality: string;
    userUsage: string;
}
export interface CreateUserRequest {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    nationality: string;
    userUsage: string;
}