import { useState } from 'react'
import { Routes, Route, useLocation } from "react-router-dom";
import LoginPage from './Pages/Login/LoginPage.jsx';
import './App.css'
import Navbar from "./components/Navbar.jsx"

function App() {
  const location = useLocation();
  const hideNavbar = location.pathname == "/login" || location.pathname == "/register";

  return (
    <>
    {!hideNavbar && <Navbar/>}

      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<LoginPage />} />
      </Routes>
    </>
  )
}

export default App
