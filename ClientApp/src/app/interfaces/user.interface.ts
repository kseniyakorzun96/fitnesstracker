export interface User {
    id: string,
    username: string,
    name: string,
    surname: string,
    email: string,
    password: string,
    userRole: UserRole
}

export interface LoginForm {
    username: string,
    password: string,
}

export enum UserRole {
    User = 2,
    Curator = 1
}

export interface RegisteredUser {
    username: string,
    email: string,
    password: string
}