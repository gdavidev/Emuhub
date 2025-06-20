/* REGISTER */
export type CurrentUserRegisterRequest = {
  userName: string,
  email: string,
  password: string,
  profileImage?: File | undefined,
}

/* LOGIN */
export type CurrentUserLoginRequest = {
  email: string,
  password: string,
}
export type CurrentUserLoginResponse = {
  id: string,
  name: string,
  email: string,
  role: string,
  profileImageBase64: string,
  userTokens: {
    accessToken: string,
    refreshToken: string
  }
}

/* RESET PASSWORD */
export type CurrentUserResetPassword = {
  newPassword: string
}

/* FORGOT PASSWORD */
export type CurrentUserForgotPassword = {
  email: string
}

/* DELETE */
export type CurrentUserDelete = {
  userId: string
}

/* UPDATE */
export type CurrentUserUpdate = {
  userName?: string,
  email?: string,
  password?: string,
  profileImage?: File,
}