import { Outlet } from "react-router-dom";
import { useLocation } from "react-router-dom";

export default function Layout() {
    return (  
      <div className="w-full h-screen grid grid-flow-col">
        <Outlet />
      </div>
     );
}