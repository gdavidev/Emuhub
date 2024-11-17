import React, { useState } from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import { IonIcon } from '@ionic/react'
import { add, createOutline, trashOutline, reloadOutline } from 'ionicons/icons';
import TableDisplay from '@apps/admin/components/TableDisplay';
import { IconButton } from '@mui/material';
import Emulator from '@models/Emulator';
import EmulatorEditModal from '../components/modal/EmulatorEditModal';
import useStatefulArray from '@/hooks/useStatefulArray';
import useEmulators, { useDeleteEmulator } from '@/hooks/useEmulators';
import useCurrentUser from '@/hooks/useCurrentUser';

export default function EmulatorsView() {
  const [ emulatorModalData  , setEmulatorModalData   ] = useState<Emulator>(new Emulator());
  const [ isEmulatorModalOpen, setIsEmulatorModalOpen ] = useState<boolean>(false);
  const { user } = useCurrentUser();
  const emulators = useStatefulArray<Emulator>([], { 
    compare: (emu1: Emulator, emu2: Emulator) => emu1.id === emu2.id
  });

  const { refetch: reload } = useEmulators({
    onSuccess: (list: Emulator[]) => emulators.set(list.sort((prev, curr) => prev.id - curr.id)),
    onError: (err: any) => console.log("err: " + JSON.stringify(err))
  });
  const { mutate: deleteEmulator } = useDeleteEmulator(user?.token!, {
    onSuccess: (emulator: Emulator) => emulators.remove(emulator),
    onError: (err: any) => console.log("err: " + JSON.stringify(err))
  });

  function addEmulator() {
    setEmulatorModalData(new Emulator());
    setIsEmulatorModalOpen(true);
  }
  function editEmulator(emulator: Emulator) {
    setEmulatorModalData(emulator);
    setIsEmulatorModalOpen(true);
  }

  const templateHeader: {colName: string, colWidth: string}[] = [
    {colName: '#'          , colWidth: '30px'  },
    {colName: 'Console'    , colWidth: '100%'  },
    {colName: 'Empresa'    , colWidth: '120px' },
    {colName: 'Abreviação' , colWidth: '160px' }, 
    {colName: ''           , colWidth: '120px' }
  ];

  return (
    <>
      <div className="flex flex-col">
        <div className="flex justify-between items-center mx-5 text-white">
          <h2 className="font-rubik font-bold">Lista de Jogos</h2>
          <div className="flex gap-x-2 ">
            <IconButton variant="solid" color="neutral" onClick={ () => reload() } >
              <IonIcon icon={ reloadOutline } />
            </IconButton>
            <button className='btn-r-md bg-primary hover:bg-primary-dark text-white'
                onClick={ addEmulator }>
              <IonIcon icon={ add } /> Novo Jogo
            </button>
          </div>
        </div>
        <TableDisplay headerTemplateLabels={ templateHeader } 
            tableStyleObject={{width: '100%', borderSpacing: '0 3px'}}
            tableHeaderClassName='text-white font-rubik font-bold'>
          { 
            emulators.all.map((emulator: Emulator, index: number) => {
                return ( 
                  <EmulatorDataTableRow key={index} emulator={ emulator }
                    rowClassName="bg-primary-light text-white"
                    cellClassName='first:rounded-s-md last:rounded-e-md'
                    actions={{
                      edit: editEmulator, 
                      delete: deleteEmulator
                    }} />
                )
              })            
          }
        </TableDisplay>
      </div>
      <EmulatorEditModal emulator={ emulatorModalData }
          onCloseRequest={ () => { setIsEmulatorModalOpen(false) } } isOpen={ isEmulatorModalOpen } 
          onChange={ emulatorModalData.id === 0 ? 
            emulators.append :
            emulators.update } />
    </>
  );
}

type EmulatorDataTableRowProps = {
  rowClassName?: string,
  cellClassName?: string,
  emulator: Emulator,
  actions: { 
    edit: (emulator: Emulator) => void,
    delete: (emulator: Emulator) => void,
  }
}
function EmulatorDataTableRow(props: EmulatorDataTableRowProps): React.ReactElement {  
  return (
    <tr className={ props.rowClassName }>
      <td className={ props.cellClassName }>
        { props.emulator.id   }
      </td>
      <td className={ props.cellClassName }>
        { props.emulator.console }
      </td>
      <td className={ props.cellClassName }>
        { props.emulator.companyName }
      </td>
      <td className={ props.cellClassName }>
        { props.emulator.abbreviation }
      </td>
      <td className={ props.cellClassName }>
        <Box sx={{ display: 'flex', gap: 1 }}>
          <Button size="sm" variant="plain" 
              onClick={ () => { props.actions.edit(props.emulator) } } >
            <IonIcon style={{color: '#FFFFFF'}} icon={ createOutline } />
          </Button>
          <Button size="sm" variant="plain"
             onClick={ () => { props.actions.delete(props.emulator) } } >
            <IonIcon style={{color: '#FFFFFF'}} icon={ trashOutline } />
          </Button>
        </Box>
      </td>
    </tr>
  )
}

