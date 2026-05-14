import i18n from 'i18next';
import { initReactI18next } from 'react-i18next';

const resources = {
  en: {
    translation: {
      "welcome": "Welcome to InvenTrack",
      "login": "Login",
      "register": "Register",
      "logout": "Logout",
      "home": "Home",
      "dashboard": "Dashboard",
      "search": "Search inventories and items...",
      "create_inventory": "Create New Inventory",
      "no_buttons_warning": "Select items to see actions in the toolbar",
      "theme_toggle": "Toggle Theme",
      "language": "Language"
    }
  },
  uz: {
    translation: {
      "welcome": "InvenTrack-ga xush kelibsiz",
      "login": "Kirish",
      "register": "Ro'yxatdan o'tish",
      "logout": "Chiqish",
      "home": "Asosiy",
      "dashboard": "Boshqaruv paneli",
      "search": "Kolleksiya va buyumlarni qidirish...",
      "create_inventory": "Yangi kolleksiya yaratish",
      "no_buttons_warning": "Amallarni ko'rish uchun buyumlarni tanlang",
      "theme_toggle": "Mavzuni o'zgartirish",
      "language": "Til"
    }
  }
};

i18n
  .use(initReactI18next)
  .init({
    resources,
    lng: localStorage.getItem('lang') || 'en',
    interpolation: {
      escapeValue: false
    }
  });

export default i18n;
