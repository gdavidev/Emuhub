import React, { PropsWithoutRef, useContext, useCallback, useEffect } from 'react';
import SignUpLayout from "@apps/main/pages/auth/SignUpLayout.tsx";
import LogInLayout from "@/apps/main/pages/auth/LogInLayout";
import logo from '/icons/logo.png'
import CurrentUser from "@/models/CurrentUser";
import { MainContext, MainContextProps } from "@/apps/shared/context/MainContextProvider";
import { useNavigate, useSearchParams } from 'react-router-dom';
import PasswordResetLayout from "./PasswordResetLayout";
import useAlert from '@/hooks/feedback/useAlert.tsx';
import useNotification from '@/hooks/feedback/useNotification.tsx';

export enum AuthPageMode {
  LOGIN,
  SIGNUP,
  RESET_PASSWORD,
}
export type AuthPageProps = {
  mode: AuthPageMode
}

export default function AuthPage(props: PropsWithoutRef<AuthPageProps>): React.ReactElement {
  const navigate = useNavigate();
  const [ params ] = useSearchParams();
  const mainContext: MainContextProps = useContext(MainContext);
  const { notifySuccess } = useNotification()
  const { alertElement, info, error, clear: clearAlert } = useAlert()

  useEffect(() => {
    clearAlert()
  }, []);

  const loginSuccess = useCallback((user: CurrentUser) => {
    notifySuccess("Logado com sucesso!")
    mainContext.setCurrentUser?.(user)
    if (params.get('redirected') === 'true')
      return navigate(-1);
    navigate("/");
  }, []);
  const registeredSuccess = useCallback(() => {
    clearAlert();
    notifySuccess("Registrado com sucesso! Você pode fazer seu login agora.");
    navigate("/log-in");
  }, []);
  const passwordResetSuccess = useCallback(() => {
    notifySuccess("Senha alterada com sucesso!")
  }, []);

  return(
    <div className="flex flex-col gap-y-4 w-1/2 mx-auto mt-0 justify-center items-center">
      <img src={ logo } alt="logo" className="w-96" />    
      <div className='w-full'>
        { alertElement }
      </div>
      {
        {
          [AuthPageMode.LOGIN]:
            <LogInLayout onError={ error } onSuccess={ loginSuccess } onStateChanged={ info } />,
          [AuthPageMode.SIGNUP]:
            <SignUpLayout onError={ error } onSuccess={ registeredSuccess } onStateChanged={ info } />,
          [AuthPageMode.RESET_PASSWORD]:
            <PasswordResetLayout onError={ error } onSuccess={ passwordResetSuccess } onStateChanged={ info } />,
        }[props.mode]
      }
    </div>
  );
}