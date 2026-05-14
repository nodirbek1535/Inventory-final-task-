import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { ThemeProvider } from './context/ThemeContext';
import { AuthProvider } from './context/AuthContext';
import Layout from './components/Layout';
import Home from './pages/Home';
import Login from './pages/Login';
import Dashboard from './pages/Dashboard';
import InventoryView from './pages/InventoryView';
import './i18n/config';

// Import bootstrap JS
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

function App() {
  return (
    <ThemeProvider>
      <AuthProvider>
        <Router>
          <Layout>
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/login" element={<Login />} />
              <Route path="/register" element={<div className="pt-5 text-center">Register Page (Coming Soon)</div>} />
              <Route path="/dashboard" element={<Dashboard />} />
              <Route path="/inventory/:id" element={<InventoryView />} />
              <Route path="/inventory/:id/settings" element={<InventoryView />} />
            </Routes>
          </Layout>
        </Router>
      </AuthProvider>
    </ThemeProvider>
  );
}

export default App;
