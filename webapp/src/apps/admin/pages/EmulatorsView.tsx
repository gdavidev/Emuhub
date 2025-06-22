import { IonIcon } from '@ionic/react';
import { reloadOutline } from 'ionicons/icons';
import TableDisplay from '@apps/admin/components/TableDisplay';
import { IconButton } from '@mui/material';
import Emulator from '@models/Emulator';
import useStatefulArray from '@/hooks/useStatefulArray';
import useEmulators from '@/hooks/api/useEmulators.ts';
import useCurrentUser from '@/hooks/useCurrentUser';
import useRequestErrorHandler from '@/hooks/useRequestErrorHandler.ts';
import { AxiosError } from 'axios';
import useNotification from '@/hooks/feedback/useNotification.tsx';
import {ReactElement} from "react";

export default function EmulatorsView() {
	const { notifyError } = useNotification();
	const { forceLogin } = useCurrentUser();
	const emulators = useStatefulArray<Emulator>([], {
		compare: (emu1: Emulator, emu2: Emulator) => emu1.id === emu2.id,
	});

	const { refetch: reload } = useEmulators({
		onSuccess: (list: Emulator[]) => emulators.set(list.sort((prev, curr) => prev.id - curr.id)),
		onError: (err: AxiosError | Error) => handleRequestError(err),
	});

	// ---- API Calls Error Handling ----
	const { handleRequestError } = useRequestErrorHandler({
		mappings: [
			{ status: 401, onError: () => forceLogin('Seu login expirou, por favor entre novamente') },
			{ status: 'default', userMessage: "Por favor tente novamente mais tarde." }
		],
		onError: (message: string) => notifyError(message)
	});

	const templateHeader: { colName: string; colWidth: string }[] = [
		{ colName: '#', colWidth: '30px' },
		{ colName: 'Nome', colWidth: '100%' },
		{ colName: 'Abreviação', colWidth: '160px' },
	];

	return (
		<div className='flex flex-col'>
			<div className='mx-5 flex items-center justify-between text-white'>
				<h2 className='font-rubik font-bold'>Lista de Emuladores</h2>
				<div className='flex gap-x-2'>
					<IconButton onClick={() => reload()}>
						<IonIcon icon={reloadOutline} />
					</IconButton>
				</div>
			</div>
			<TableDisplay
				headerTemplate={templateHeader}
				tableStyleObject={{
					width: '100%',
					borderSpacing: '0 3px',
				}}
				tableHeaderClassName='text-white font-rubik font-bold'
			>
				{emulators.all.map((emulator: Emulator, index: number) => {
					return (
						<EmulatorDataTableRow
							key={index}
							emulator={emulator}
							rowClassName='bg-primary-light text-white'
							cellClassName='first:rounded-s-md last:rounded-e-md'
						/>
					);
				})}
			</TableDisplay>
		</div>
	);
}

type EmulatorDataTableRowProps = {
	rowClassName?: string;
	cellClassName?: string;
	emulator: Emulator;
};
function EmulatorDataTableRow(props: EmulatorDataTableRowProps): ReactElement {
	return (
		<tr className={props.rowClassName}>
			<td className={props.cellClassName}>{props.emulator.id}</td>
			<td className={props.cellClassName}>{props.emulator.name}</td>
			<td className={props.cellClassName}>{props.emulator.abbreviation}</td>
		</tr>
	);
}
