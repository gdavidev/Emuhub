import { useContext, useEffect, useLayoutEffect, useState } from "react"
import { Link } from "react-router-dom"
import { MainContext, MainContextProps } from "@shared/context/MainContextProvider"
import { IonIcon } from '@ionic/react'
import { home, exit, person, gameController } from 'ionicons/icons';
import CurrentUser from "@/models/User";

export default function SideMenu() {
  const [ user, setCurrentUser ] = useState<CurrentUser | undefined>(undefined);
  const context: MainContextProps = useContext(MainContext)

  useLayoutEffect(() => {    
    context.onUserAuth.subscribe(setCurrentUser);
  });
  useEffect(() => {
    setCurrentUser(context.currentUser);
    return context.onUserAuth.remove(setCurrentUser) // Cleanup code
  })
  
  return (
    <>
      <div id="aside-spacing" className="min-w-[200px]" />
      <aside className="box-border flex flex-col h-screen min-w-[200px] py-5 bg-primary-dark font-rubik fixed">
        <div className="w-full px-3 text-white text-center mb-3">        
          <h1 className="text-start border-s-4 border-s-white ps-1 font-black">CRUD</h1>
          <h2 className="font-bold">{ user ? user.userName : "User..." }</h2>
          <span className="text-sm">Admin</span>
        </div>
        <div className="flex flex-col h-full justify-between items-center px-3 text-white">
          <div className="w-full flex flex-col gap-y-2">        
            <Link to="/admin/view-games" 
                className="btn-r-md flex justify-start bg-primary hover:bg-primary-light gap-x-2 w-full">
              <IonIcon icon={ home } /> Games
            </Link>
            <Link to="/admin/view-emulators" 
                className="btn-r-md flex justify-start bg-primary hover:bg-primary-light gap-x-2 w-full">
              <IonIcon icon={ gameController } /> Emulators
            </Link>   
            <Link to="/admin/view-users" 
                className="btn-r-md flex justify-start bg-primary hover:bg-primary-light gap-x-2 w-full">
              <IonIcon icon={ person } /> Users
            </Link>
          </div>
          <Link to="/" 
              className="btn-r-md flex justify-start bg-primary hover:bg-primary-light gap-x-2 w-full">
            <IonIcon icon={ exit } /> Sair
          </Link>        
        </div>
      </aside>
    </>
  )
}

