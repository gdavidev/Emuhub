import { useContext } from "react"
import { Link } from "react-router-dom"

import { MainContext, MainContextProps } from "../../../shared/context/MainContextProvider"
import { IonIcon } from '@ionic/react'
import { home, exit } from 'ionicons/icons';

export default function SideMenu() {
  const context: MainContextProps = useContext(MainContext)
  
  return (
    <aside className="flex flex-col h-screen w-1/5 py-5 bg-primary-dark font-rubik">
      <div className="w-full px-3 text-white text-center mb-3">        
        <h1 className="text-start border-s-4 border-s-white ps-1 font-black">CRUD</h1>
        <h2 className="font-bold">{ context.currentUser?.userName || "User" }</h2>
        <span className="text-sm">Admin</span>
      </div>
      <div className="flex flex-col h-full justify-between items-center gap-y-3 px-3">
        <div className="w-full">          
          <Link to="/admin/view-games" 
              className="btn-r-md flex justify-start bg-primary hover:bg-primary-light gap-x-2 w-full">
            <IonIcon icon={ home } /> Games
          </Link>                 
        </div>
        <Link to="/app/" 
            className="btn-r-md flex justify-start bg-primary hover:bg-primary-light gap-x-2 w-full">
          <IonIcon icon={ exit } /> Sair
        </Link>        
      </div>
    </aside>
  )
}

