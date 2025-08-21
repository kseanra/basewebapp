import { useState } from "react";
import { Outlet, useNavigate } from "react-router-dom";
import { Palette, Upload, Image, Sparkles } from "lucide-react";
import { Link, useLocation } from "react-router-dom";
import {navigationItems} from "../nav";
import {
  Sidebar,
  SidebarContent,
  SidebarGroup,
  SidebarGroupContent,
  SidebarGroupLabel,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
  SidebarHeader,
  SidebarProvider,
  SidebarTrigger,
} from "@/components/ui/sidebar";

export default function Layout({ children }: { children: React.ReactNode }) {
    const location = useLocation();
    return (  
      <div className="w-full h-screen grid grid-flow-col items-center justify-items-center">
        <Outlet />
      </div>
     );
}