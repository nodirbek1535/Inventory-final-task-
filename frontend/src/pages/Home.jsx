import React from 'react';
import { useTranslation } from 'react-i18next';

const Home = () => {
  const { t } = useTranslation();
  return (
    <div className="text-center py-5">
      <h1 className="display-4 fw-bold mb-4">{t('welcome')}</h1>
      <p className="lead mb-5 text-muted">Manage your custom inventories with ease.</p>
      
      <div className="row g-4 text-start">
        {/* Placeholder for Latest Inventories */}
        <div className="col-md-6">
          <div className="premium-card p-4">
            <h3 className="h5 mb-3">Latest Inventories</h3>
            <p className="text-muted small">Table will appear here soon...</p>
          </div>
        </div>
        <div className="col-md-6">
          <div className="premium-card p-4">
            <h3 className="h5 mb-3">Most Popular</h3>
            <p className="text-muted small">Table will appear here soon...</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Home;
