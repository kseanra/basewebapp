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
    <SidebarProvider>
      <style>{`
        :root {
          --primary-charcoal: #1a1a1a;
          --warm-white: #fafafa;
          --sage-green: #9ca986;
          --terracotta: #d4704a;
          --soft-gray: #f5f5f5;
          --medium-gray: #8a8a8a;
        }
      `}</style>
      
      <div className="min-h-screen flex w-full bg-gradient-to-br from-gray-50 to-white">
        <Sidebar className="border-r border-gray-100 bg-white/80 backdrop-blur-sm">
          <SidebarHeader className="border-b border-gray-100 p-6">
            <div className="flex items-center gap-3">
              <div className="w-10 h-10 bg-gradient-to-br from-sage-green to-terracotta rounded-2xl flex items-center justify-center shadow-sm">
                <Sparkles className="w-5 h-5 text-white" />
              </div>
              <div>
                <h2 className="font-bold text-xl text-gray-900 tracking-tight">DesignAI</h2>
                <p className="text-xs text-gray-500 font-medium">Interior Design Studio</p>
              </div>
            </div>
          </SidebarHeader>
          
          <SidebarContent className="p-4">
            <SidebarGroup>
              <SidebarGroupLabel className="text-xs font-semibold text-gray-400 uppercase tracking-wider px-2 py-3">
                Workspace
              </SidebarGroupLabel>
              <SidebarGroupContent>
                <SidebarMenu className="space-y-2">
                  {navigationItems.map((item) => (
                    <SidebarMenuItem key={item.title}>
                      <SidebarMenuButton 
                        asChild 
                        className={`hover:bg-gray-50 hover:text-gray-900 transition-all duration-200 rounded-xl px-4 py-3 ${
                          location.pathname === item.url 
                            ? 'bg-gradient-to-r from-sage-green/10 to-terracotta/10 text-gray-900 shadow-sm border border-sage-green/20' 
                            : 'text-gray-600'
                        }`}
                      >
                        <Link to={item.url} className="flex items-center gap-4">
                          <item.icon className="w-5 h-5" />
                          <div className="flex flex-col items-start">
                            <span className="font-semibold text-sm">{item.title}</span>
                            <span className="text-xs text-gray-400">{item.description}</span>
                          </div>
                        </Link>
                      </SidebarMenuButton>
                    </SidebarMenuItem>
                  ))}
                </SidebarMenu>
              </SidebarGroupContent>
            </SidebarGroup>
          </SidebarContent>
        </Sidebar>

        <main className="flex-1 flex flex-col overflow-hidden">
          <header className="bg-white/90 backdrop-blur-sm border-b border-gray-100 px-6 py-4 md:hidden">
            <div className="flex items-center gap-4">
              <SidebarTrigger className="hover:bg-gray-100 p-2 rounded-xl transition-colors duration-200" />
              <div className="flex items-center gap-2">
                <Sparkles className="w-5 h-5 text-sage-green" />
                <h1 className="text-xl font-bold text-gray-900">DesignAI</h1>
              </div>
            </div>
          </header>

          <div className="flex-1 overflow-auto">
            <Outlet />
          </div>
        </main>
      </div>
      </SidebarProvider>
     );
}