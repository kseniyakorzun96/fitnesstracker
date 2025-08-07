import { createAction, props } from '@ngrx/store';
import { LoginForm, RegisteredUser, User } from '../interfaces/user.interface';

export const login = createAction('[Auth] Login', props<{ login: LoginForm }>());
export const loginSuccess = createAction('[Auth] Login Success', props<{ user: User }>());
export const loginFailure = createAction('[Auth] Login Failure', props<{ error: string }>());

export const register = createAction('[Auth] Register', props<{ user: RegisteredUser }>());
export const registerSuccess = createAction('[Auth] Register Success', props<{ user: User }>());
export const registerFailure = createAction('[Auth] Register Failure', props<{ error: string }>());

export const logout = createAction('[Auth] Logout');