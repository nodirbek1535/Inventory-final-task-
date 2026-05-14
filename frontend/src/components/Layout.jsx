import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { useTheme } from '../context/ThemeContext';
import { useAuth } from '../context/AuthContext';
import { Sun, Moon, Languages, LogOut, Search, User, Home } from 'lucide-react';

const Layout = ({ children }) => {
  const { t, i18n } = useTranslation();
  const { isDarkMode, toggleTheme } = useTheme();
  const { token, logout } = useAuth();
  const navigate = useNavigate();

  const changeLanguage = (lng) => {
    i18n.changeLanguage(lng);
    localStorage.setItem('lang', lng);
  };

  return (
    <div>
      {/* Navbar */}
      <nav className={`navbar navbar-expand-lg sticky-top ${isDarkMode ? 'navbar-dark bg-dark' : 'navbar-light bg-white border-bottom'}`}>
        <div className="container">
          <Link className="navbar-brand fw-bold d-flex align-items-center gap-2" to="/">
            <div className="bg-primary rounded-pill p-1">
              <Home size={20} className="text-white" />
            </div>
            InvenTrack
          </Link>

          {/* Search Bar - Requirement: On every page header */}
          <div className="d-none d-md-flex mx-auto" style={{ width: '40%' }}>
            <div className="input-group">
              <span className={`input-group-text border-end-0 ${isDarkMode ? 'bg-secondary border-dark text-light' : 'bg-light'}`}>
                <Search size={18} />
              </span>
              <input
                type="text"
                className={`form-control border-start-0 ${isDarkMode ? 'bg-secondary border-dark text-light' : 'bg-light'}`}
                placeholder={t('search')}
              />
            </div>
          </div>

          <div className="d-flex align-items-center gap-3">
            {/* Language Toggle */}
            <div className="dropdown">
              <button className={`btn btn-link p-0 ${isDarkMode ? 'text-light' : 'text-dark'}`} data-bs-toggle="dropdown">
                <Languages size={22} />
              </button>
              <ul className={`dropdown-menu dropdown-menu-end ${isDarkMode ? 'dropdown-menu-dark' : ''}`}>
                <li><button className="dropdown-item" onClick={() => changeLanguage('en')}>English</button></li>
                <li><button className="dropdown-item" onClick={() => changeLanguage('uz')}>O'zbekcha</button></li>
              </ul>
            </div>

            {/* Theme Toggle */}
            <button className={`btn btn-link p-0 ${isDarkMode ? 'text-warning' : 'text-primary'}`} onClick={toggleTheme}>
              {isDarkMode ? <Sun size={22} /> : <Moon size={22} />}
            </button>

            {/* Auth Actions */}
            {token ? (
              <div className="dropdown">
                <button className={`btn btn-link p-0 ${isDarkMode ? 'text-light' : 'text-dark'}`} data-bs-toggle="dropdown">
                  <User size={22} />
                </button>
                <ul className={`dropdown-menu dropdown-menu-end ${isDarkMode ? 'dropdown-menu-dark' : ''}`}>
                  <li><Link className="dropdown-item" to="/dashboard">{t('dashboard')}</Link></li>
                  <li><hr className="dropdown-divider" /></li>
                  <li><button className="dropdown-item text-danger" onClick={() => { logout(); navigate('/'); }}>{t('logout')}</button></li>
                </ul>
              </div>
            ) : (
              <div className="d-flex gap-2">
                <Link to="/login" className="btn btn-sm btn-outline-primary rounded-pill px-3">{t('login')}</Link>
                <Link to="/register" className="btn btn-sm btn-primary rounded-pill px-3">{t('register')}</Link>
              </div>
            )}
          </div>
        </div>
      </nav>

      {/* Main Content */}
      <main className="container py-4 animate-fade-in">
        {children}
      </main>

      {/* Footer or extra floating items if needed */}
    </div>
  );
};

export default Layout;
