import ModalPopup, { ModalPopupProps } from '@shared/components/ModalPopup.tsx';
import TextArea from '@shared/components/formComponents/TextArea.tsx';
import { Controller, useForm } from 'react-hook-form';
import Report, { ReportContentType } from '@models/Report.ts';
import useSendReport from '@/hooks/useReport.ts';
import useCurrentUser from '@/hooks/useCurrentUser.tsx';
import useNotification from '@/hooks/feedback/useNotification.tsx';
import { useCallback } from 'react';

type ReportContentModalProps = {
	contentType: ReportContentType;
	contentId: number;
} & ModalPopupProps

type ReportContentModalFormData = {
	reportText: string
}

export default function ReportContentModal(props: ReportContentModalProps) {
	const { user, askToLogin } = useCurrentUser();
	const { notifySuccess, notifyError } = useNotification();
	const { handleSubmit, control } = useForm<ReportContentModalFormData>({
		defaultValues: {
			reportText: ''
		}
	});

	const { sendReport } = useSendReport(user?.token!, {
		onSuccess: () => {
			notifySuccess('Denúncia enviada com sucesso.')
			props.onCloseRequest?.()
		},
		onError: () => notifyError('Houve um erro, tente novamente mais tarde')
	});

	const submitForm = useCallback((data: ReportContentModalFormData) => {
		if (!user) {
			props.onCloseRequest?.();
			return askToLogin('Para criar denuncias é preciso esta logado.')
		}

		sendReport(new Report(
				props.contentId,
				props.contentType,
				user.id,
				data.reportText,
		));
	}, [user])

	return (
			<ModalPopup
					isOpen={ props.isOpen }
					title="Reportar Conteúdo"
					onCloseRequest={ props.onCloseRequest }
					className='bg-layout-background'>
				<form
						onSubmit={ handleSubmit(submitForm) }
						className='flex flex-col gap-4 justify-end'
				>
					<Controller
							name="reportText"
							control={control}
							render={({ field }) => (
									<TextArea
											{...field}
											name='reportText'
											labelClassName='hidden'
											className='min-h-48 w-96 bg-slate-200'
									/>
							)} />
					<button
							type='submit'
							className='btn-primary'
							onClick={ props.onCloseRequest }>
						Enviar
					</button>
				</form>
			</ModalPopup>
	)
}