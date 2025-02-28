import { UserGetResponse } from '@models/data/UserTypes.ts';

/* REGISTER */
export type CurrentUserRegisterRequest = {
  username: string,
  email: string,
  password: string,
  imagem_perfil?: File | undefined,
}
export type CurrentUserRegisterResponse = {}

/* LOGIN */
export type CurrentUserLoginRequest = {
  email: string,
  password: string,
}
export type CurrentUserLoginResponse = {
  token: string
  user: UserGetResponse
}

/* RESET PASSWORD */
export type CurrentUserResetPassword = {
  newPassword: string
}
export type CurrentUserResetPasswordResponse = {}

/* FORGOT PASSWORD */
export type CurrentUserForgotPassword = {
  email: string
}
export type CurrentUserForgotPasswordResponse = {}

/* DELETE */
export type CurrentUserDelete = {
  user_id: number
}
export type CurrentUserDeleteResponse = {}

/* UPDATE */
export type CurrentUserUpdate = {
  username?: string,
  email?: string,
  password?: string,
  imagem_perfil?: File | undefined,
}
export type CurrentUserUpdateResponse = {
  username: string,
  email: string,
  password: string,
}