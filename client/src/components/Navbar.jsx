import React, { useState } from "react";

import { isLoggedIn, logout } from "../auth";


export default function Navbar ({onAuthChange}){
    const loggedIn = isLoggedIn();
    const [open, setOpen] = React.useState(false)

    function handleLogout(){
        logout();
        onAuthChange();
    }
    return(
         <nav className="flex items-center justify-between px-6 md:px-16 lg:px-24 xl:px-32 py-4 border-b border-gray-300 bg-white relative transition-all">
                <img src="/assets/logo.png" alt="logo" className="h-7 sm:h-8 md:h-16 w-auto"></img>

            <div className="hidden sm:flex items-center gap-8">
                <a href="#">Explore</a>
                 <div className="hidden lg:flex items-center text-sm gap-2 border border-gray-300 px-3 rounded-full">
                    <input className="py-1.5 w-full bg-transparent outline-none placeholder-gray-500" type="text" placeholder="Search products" />
                    <svg width="16" height="16" viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                        <path d="M10.836 10.615 15 14.695" stroke="#7A7B7D" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" />
                        <path clip-rule="evenodd" d="M9.141 11.738c2.729-1.136 4.001-4.224 2.841-6.898S7.67.921 4.942 2.057C2.211 3.193.94 6.281 2.1 8.955s4.312 3.92 7.041 2.783" stroke="#7A7B7D" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" />
                    </svg>
                </div>
                {!loggedIn && (
                    <>
                    <button className="cursor-pointer px-8 py-2 bg-[#4C5C8C] hover:bg-[#465a97] transition text-white rounded-full">
                    Login
                    </button>
                    <button className="cursor-pointer px-8 py-2 border-2 border-[#4C5C8C] rounded-full">
                    Register
                    </button>
                   
                    </>
                )}
                 {loggedIn && (
                    <>
                    <a href="#">My Clubs</a>

                    <button
            onClick={handleLogout}
            className="cursor-pointer px-8 py-2 bg-indigo-500 hover:bg-indigo-600 transition text-white rounded-full"
          >
            Logout
          </button>
                    </>
          
        )}
      </div>

      <button
        onClick={() => setOpen((v) => !v)}
        aria-label="Menu"
        className="sm:hidden"
      >
        <svg width="21" height="15" viewBox="0 0 21 15" fill="none">
          <rect width="21" height="1.5" rx=".75" fill="#426287" />
          <rect x="8" y="6" width="13" height="1.5" rx=".75" fill="#426287" />
          <rect x="6" y="13" width="15" height="1.5" rx=".75" fill="#426287" />
        </svg>
      </button>

      <div
        className={`${
          open ? "flex" : "hidden"
        } absolute top-[60px] left-0 w-full bg-white shadow-md py-4 flex-col items-center gap-2 px-5 text-sm md:hidden`}
      >
        <a href="#" className="block">Explore</a>
        {!loggedIn && (
            <>
                <a href="/login" className="cursor-pointer py-2 px-8 border-1 bg-[#4C5C8C] hover:bg-[#465a97] transition text-white rounded-full">Login</a>
                <a href="/register" className="cursor-pointer px-6 py-2 border-1 border-[#4C5C8C] rounded-full">Register</a>
            </>
        )}

        {loggedIn && (
            <>
            <a href="#">My Clubs</a>
             <button onClick={handleLogout} className="py-2 text-left">
            Logout
        </button>
            </>
       
        )}
            </div>  
        </nav>
    );
  
}


