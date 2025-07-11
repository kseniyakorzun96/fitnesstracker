export interface User {
    id: string,
    username: string,
    name: string,
    surname: string,
    email: string,
    password: string,
}

export interface LoginForm {
    username: string,
    password: string,
}