import React, { useState } from 'react';
import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router-dom';
import DataTable from '../components/DataTable';

// Vaqtincha test ma'lumotlari
const MOCK_MY_INVENTORIES = [
  { id: 'inv-1', title: 'Office Equipment', category: 'Equipment', itemCount: 45, createdAt: '2026-05-10' },
  { id: 'inv-2', title: 'IT Library', category: 'Book', itemCount: 120, createdAt: '2026-05-12' }
];

const MOCK_SHARED_INVENTORIES = [
  { id: 'inv-3', title: 'HR Documents', category: 'Other', owner: 'admin@test.com', role: 'Editor' }
];

const Dashboard = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const [activeTab, setActiveTab] = useState('my'); // 'my' or 'shared'

  const columnsMy = [
    { key: 'title', title: 'Title' },
    { key: 'category', title: 'Category' },
    { key: 'itemCount', title: 'Items' },
    { key: 'createdAt', title: 'Created' }
  ];

  const columnsShared = [
    { key: 'title', title: 'Title' },
    { key: 'category', title: 'Category' },
    { key: 'owner', title: 'Owner' },
    { key: 'role', title: 'My Role' }
  ];

  const handleCreate = () => navigate('/inventory/new/settings');
  const handleEdit = (id) => navigate(`/inventory/${id}/settings`);
  const handleDelete = (ids) => {
    if (window.confirm(`Are you sure you want to delete ${ids.length} inventories?`)) {
      console.log('Deleting', ids);
    }
  };

  return (
    <div className="py-4">
      <div className="d-flex justify-content-between align-items-center mb-4">
        <h1 className="h3 fw-bold mb-0">{t('dashboard')}</h1>
      </div>

      {/* Tabs */}
      <ul className="nav nav-tabs mb-4 border-bottom-0 gap-2">
        <li className="nav-item">
          <button 
            className={`nav-link rounded-pill ${activeTab === 'my' ? 'active bg-primary text-white border-primary' : 'text-muted border-0'}`}
            onClick={() => setActiveTab('my')}
          >
            My Inventories
          </button>
        </li>
        <li className="nav-item">
          <button 
            className={`nav-link rounded-pill ${activeTab === 'shared' ? 'active bg-primary text-white border-primary' : 'text-muted border-0'}`}
            onClick={() => setActiveTab('shared')}
          >
            Shared With Me
          </button>
        </li>
      </ul>

      {/* Tables */}
      <div className="premium-card p-4">
        {activeTab === 'my' ? (
          <DataTable 
            columns={columnsMy} 
            data={MOCK_MY_INVENTORIES} 
            onCreate={handleCreate}
            onEdit={handleEdit}
            onDelete={handleDelete}
          />
        ) : (
          <DataTable 
            columns={columnsShared} 
            data={MOCK_SHARED_INVENTORIES} 
            // Shared inventories usually cannot be deleted by the guest, only edited/viewed
            onCreate={() => alert('Cannot create shared inventory directly.')}
            onEdit={(id) => navigate(`/inventory/${id}`)}
            onDelete={() => alert('Cannot delete shared inventory.')}
          />
        )}
      </div>
    </div>
  );
};

export default Dashboard;
