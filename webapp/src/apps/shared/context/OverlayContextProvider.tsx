import Notification, {NotificationProps} from '@shared/components/Notification.tsx';
import MessageBox, {MessageBoxProps} from '@shared/components/MessageBox.tsx';
import {createContext, PropsWithChildren, useEffect, useState} from 'react';

export type OverlayContextProps = {
    setNotificationProps: (snackbarProps: NotificationProps) => void,
    setMessageBoxProps: (messageBoxProps: MessageBoxProps) => void,
};

const defaultMainContextProps: OverlayContextProps = {
    setNotificationProps: () => null,
    setMessageBoxProps: () => null,
};
export const OverlayContext =
    createContext<OverlayContextProps>(defaultMainContextProps);

export default function OverlayContextProvider({children}: PropsWithChildren) {
    const [notificationProps, setNotificationProps] = useState<NotificationProps | null>(null);
    const [isNotificationOpen, setIsNotificationOpen] = useState<boolean>(false);
    const [messageBoxProps, setMessageBoxProps] = useState<MessageBoxProps | null>(null);
    const [isMessageBoxOpen, setIsMessageBoxOpen] = useState<boolean>(false);

    useEffect(() => {
        if (notificationProps)
            setIsNotificationOpen(true);
    }, [notificationProps]);

    useEffect(() => {
        if (messageBoxProps)
            setIsMessageBoxOpen(true);
    }, [messageBoxProps]);

    return (
        <OverlayContext.Provider
            value={{
                setNotificationProps: setNotificationProps,
                setMessageBoxProps: setMessageBoxProps,
            }}>
            {children}
            {
                notificationProps &&
                <Notification
                    {...notificationProps}
                    open={isNotificationOpen}
                    onClose={() => setIsNotificationOpen(false)}
                />
            }
            {
                messageBoxProps &&
                <MessageBox
                    {...messageBoxProps}
                    isOpen={isMessageBoxOpen}
                    onCloseRequest={() => setIsMessageBoxOpen(false)}
                />
            }
        </OverlayContext.Provider>
    )
}