export interface User {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    nationality: number;
    userUsage: number;
}
export interface CreateUserRequest {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    nationality: number;
    userUsage: number;
}