import CurrentUser from "@models/CurrentUser";
import * as DTO from '@models/data/CurrentUserTypes.ts';
import ApiService from './ApiService';

export default class UserApiService {
  private static readonly endpoints = {
    login: 'api/Auth/Login/',
    register: 'api/Auth/Register/',
    forgotPassword: 'api/Auth/ForgotPassword/',
    resetPassword: 'api/Auth/ResetPassword/',
    put: 'api/Auth/Update/',
    delete: 'api/Auth/Delete/',
  }

  public static async register(dto: DTO.CurrentUserRegisterRequest): Promise<string> {
    const response =
        await ApiService.post(
          UserApiService.endpoints.register,
          dto,
          { headers: { 'Content-Type': 'multipart/form-data' } }
        );
    return response.data;
  }
    
  public static async login(dto: DTO.CurrentUserLoginRequest): Promise<CurrentUser> {
    const response = await ApiService.post(UserApiService.endpoints.login, dto);
    return CurrentUser.fromLoginResponseDTO(response.data);
  }

  public static async forgotPassword(dto: DTO.CurrentUserForgotPassword): Promise<void> {
    await ApiService.post(UserApiService.endpoints.forgotPassword, dto);
  }

  public static async resetPassword(dto: DTO.CurrentUserResetPassword, token: string) {
    await ApiService.post(
      UserApiService.endpoints.resetPassword,
      { password: dto.newPassword },
      { headers:  { 'Authorization': 'Bearer ' + token }
    })
  }

  public static async delete(dto: DTO.CurrentUserDelete, token: string) {
    await ApiService.delete(
        UserApiService.endpoints.delete, {
          data: { user_id: dto.user_id },
          headers:  { 'Authorization': 'Bearer ' + token }
        });
  }

  public static async update(dto: DTO.CurrentUserUpdate, token: string): Promise<void> {
    await ApiService.put(
      UserApiService.endpoints.put,
      dto,
      { headers: {
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'multipart/form-data'
      }});
  }
}