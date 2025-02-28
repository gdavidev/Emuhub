import UserApiService from '@api/CurrentUserApiService.ts';
import * as DTO from '@models/data/CurrentUserTypes.ts';
import { AxiosError } from 'axios';
import { useCallback, useEffect, useState } from 'react';
import { useMutation } from 'react-query';

type UseAuthEvents = {
  onSuccess: (data: any, variables: any) => void
  onError: (err: AxiosError | Error) => void
}

type UseAuthOptionsEvents = {
  onIsLoading?: () => void,
} & UseAuthEvents

type UseAuthOptions = {
  onLogin?: UseAuthEvents
  onRegister?: UseAuthEvents
  onForgotPassword?: UseAuthEvents
  onPasswordReset?: UseAuthEvents
  onUpdate?: UseAuthEvents
  onDelete?: UseAuthEvents
  onIsLoading?: () => void
}

type UseAuthResult = {
  login: (data: DTO.CurrentUserLoginRequest) => void
  register: (data: DTO.CurrentUserRegisterRequest) => void
  forgotPassword: (data: DTO.CurrentUserForgotPassword) => void
  passwordReset: (data: DTO.CurrentUserResetPassword & {token: string}) => void
  update: (data: DTO.CurrentUserUpdate & {token: string}) => void
  deleteAccount: (data: DTO.CurrentUserDelete & {token: string}) => void
  reset: () => void
  isLoading: boolean
}

export default function useAuth(options?: UseAuthOptions | UseAuthOptionsEvents): UseAuthResult {
  const [ isLoading, setIsLoading ] = useState<boolean>(false);
  const mutationFn: UseAuthOptionsEvents | undefined = isUseAuthOptionsEvents(options) ? {
    onSuccess: (data: any, dto: any) => options?.onSuccess?.(data, dto),      
    onError: (err: AxiosError | Error) => options?.onError?.(err)
  } : undefined;

  const loginMutation = useMutation('LOGIN_USER',
    async (dto: DTO.CurrentUserLoginRequest) => UserApiService.login(dto),
    mutationFn ?? (options as UseAuthOptions)?.onLogin
  );

  const forgotPasswordMutation = useMutation('FORGOT_PASS',
    async (data: DTO.CurrentUserForgotPassword) => UserApiService.forgotPassword(data),
    mutationFn ?? (options as UseAuthOptions)?.onForgotPassword
  );

  const registerMutation = useMutation('REGISTER_USER',
    async (dto: DTO.CurrentUserRegisterRequest) => UserApiService.register(dto),
    mutationFn ?? (options as UseAuthOptions)?.onRegister   
  );

  const passwordResetMutation = useMutation('RESET_USER_PASSWORD',
    async (dto: DTO.CurrentUserResetPassword & {token: string}) => UserApiService.resetPassword(dto, dto.token),
    mutationFn ?? (options as UseAuthOptions)?.onPasswordReset
  );

  const updateUserMutation = useMutation('UPDATE_USER', 
    async (dto: DTO.CurrentUserUpdate & { token: string }) => UserApiService.update(dto, dto.token),
    mutationFn ?? (options as UseAuthOptions)?.onUpdate
  );

  const deleteUserMutation = useMutation('DELETE_USER',
      async (dto: DTO.CurrentUserDelete & { token: string }) => UserApiService.delete(dto, dto.token),
      mutationFn ?? (options as UseAuthOptions)?.onDelete
  );

  useEffect(() => {
    const newState: boolean = (
      loginMutation.isLoading ||
      forgotPasswordMutation.isLoading ||
      registerMutation.isLoading ||
      passwordResetMutation.isLoading ||
      updateUserMutation.isLoading ||
      deleteUserMutation.isLoading
    );
    setIsLoading(newState);
    if (newState)
      options?.onIsLoading?.()
  }, [
    loginMutation.isLoading,
    forgotPasswordMutation.isLoading,
    registerMutation.isLoading,
    passwordResetMutation.isLoading,
    updateUserMutation.isLoading,
    deleteUserMutation.isLoading
  ]);

  const reset = useCallback((): void => {
    loginMutation.reset();
    forgotPasswordMutation.reset();
    registerMutation.reset();
    passwordResetMutation.reset();
    updateUserMutation.reset();
    deleteUserMutation.reset();
  }, []);

  return {
    login: loginMutation.mutate,
    register: registerMutation.mutate,
    forgotPassword: forgotPasswordMutation.mutate,
    passwordReset: passwordResetMutation.mutate,
    update: updateUserMutation.mutate,
    deleteAccount: deleteUserMutation.mutate,
    reset: reset,
    isLoading: isLoading
  }
}

// Type guard to check if an object implements UseAuthEvents
const isUseAuthOptionsEvents = (obj: any): obj is UseAuthEvents => (
  obj &&
  typeof obj.onIsLoading === 'function' &&
  typeof obj.onSuccess === 'function' &&
  typeof obj.onError === 'function'
);