import React, { useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { Settings, List, MessageCircle, Key, FileText, Shield, BarChart2 } from 'lucide-react';
import DataTable from '../components/DataTable';
import IdBuilder from '../components/IdBuilder';
import CustomFieldsBuilder from '../components/CustomFieldsBuilder';

const MOCK_ITEMS = [
  { id: 'item-1', customId: 'EQUIP-001', title: 'Laptop X1', year: 2024 },
  { id: 'item-2', customId: 'EQUIP-002', title: 'Ergo Chair', year: 2023 }
];

const InventoryView = () => {
  const { id } = useParams();
  const { t } = useTranslation();
  const navigate = useNavigate();
  const [activeTab, setActiveTab] = useState('items');

  // Asosiy ma'lumotlar o'zgarishi bilanoq Auto-save ishlashi kerak (Kelajakda hook orqali)
  const [generalData, setGeneralData] = useState({
    title: 'Office Equipment',
    description: 'All IT and office items',
    category: 'Equipment',
    isPublic: false
  });

  const TABS = [
    { id: 'items', label: 'Items', icon: <List size={16} /> },
    { id: 'discussion', label: 'Discussion', icon: <MessageCircle size={16} /> },
    { id: 'general', label: 'General', icon: <Settings size={16} /> },
    { id: 'custom-id', label: 'Custom ID Format', icon: <Key size={16} /> },
    { id: 'custom-fields', label: 'Custom Fields', icon: <FileText size={16} /> },
    { id: 'access', label: 'Access Control', icon: <Shield size={16} /> },
    { id: 'stats', label: 'Statistics', icon: <BarChart2 size={16} /> }
  ];

  return (
    <div className="py-2">
      {/* Header */}
      <div className="d-flex justify-content-between align-items-center mb-4">
        <div>
          <span className="badge bg-secondary mb-2 uppercase tracking-wider">{generalData.category}</span>
          <h1 className="h3 fw-bold mb-1">{id === 'new' ? 'Create Inventory' : generalData.title}</h1>
          <p className="text-muted small mb-0">{generalData.description}</p>
        </div>
      </div>

      {/* Tabs */}
      <div className="d-flex overflow-auto mb-4 border-bottom pb-2 gap-2 hide-scrollbar">
        {TABS.map(tab => (
          <button
            key={tab.id}
            className={`btn btn-sm d-flex align-items-center gap-2 rounded-pill px-3 whitespace-nowrap ${
              activeTab === tab.id ? 'btn-primary text-white' : 'btn-light text-muted'
            }`}
            onClick={() => setActiveTab(tab.id)}
          >
            {tab.icon}
            {tab.label}
          </button>
        ))}
      </div>

      {/* Content Area */}
      <div className="tab-content animate-fade-in">
        {activeTab === 'items' && (
          <div className="premium-card p-4">
            <DataTable 
              columns={[
                { key: 'customId', title: 'ID' },
                { key: 'title', title: 'Name' },
                { key: 'year', title: 'Year' }
              ]} 
              data={MOCK_ITEMS} 
              onCreate={() => alert('Opening item form modal...')}
              onEdit={(itemId) => alert(`Editing item ${itemId}`)}
              onDelete={(ids) => console.log('Deleting items', ids)}
            />
          </div>
        )}

        {activeTab === 'discussion' && (
          <div className="premium-card p-4 text-center text-muted">
            <MessageCircle size={48} className="opacity-25 mb-3 mx-auto" />
            <h5>Real-time Discussion</h5>
            <p className="small">SignalR connection will be established here.</p>
          </div>
        )}

        {activeTab === 'general' && (
          <div className="row justify-content-center">
            <div className="col-lg-8">
              <div className="premium-card p-4">
                <div className="mb-3">
                  <label className="form-label fw-bold small">Inventory Title</label>
                  <input 
                    type="text" 
                    className="form-control" 
                    value={generalData.title}
                    onChange={(e) => setGeneralData({...generalData, title: e.target.value})}
                  />
                </div>
                <div className="mb-3">
                  <label className="form-label fw-bold small">Category</label>
                  <select className="form-select" value={generalData.category} onChange={(e) => setGeneralData({...generalData, category: e.target.value})}>
                    <option value="Equipment">Equipment</option>
                    <option value="Furniture">Furniture</option>
                    <option value="Book">Book</option>
                    <option value="Other">Other</option>
                  </select>
                </div>
                <div className="mb-3">
                  <label className="form-label fw-bold small d-flex justify-content-between">
                    Description
                    <span className="text-primary fw-normal">Markdown supported</span>
                  </label>
                  <textarea 
                    className="form-control" 
                    rows="4"
                    value={generalData.description}
                    onChange={(e) => setGeneralData({...generalData, description: e.target.value})}
                  />
                </div>
                <p className="small text-success italic mt-3 text-end">Auto-saved just now...</p>
              </div>
            </div>
          </div>
        )}

        {activeTab === 'custom-id' && (
          <div className="row justify-content-center">
            <div className="col-lg-10">
              <IdBuilder />
            </div>
          </div>
        )}

        {activeTab === 'custom-fields' && (
          <div className="row justify-content-center">
            <div className="col-lg-10">
              <CustomFieldsBuilder />
            </div>
          </div>
        )}

        {activeTab === 'access' && (
          <div className="row justify-content-center">
            <div className="col-lg-8">
              <div className="premium-card p-4">
                <h5 className="mb-4">Access Control</h5>
                <div className="form-check form-switch mb-4 pb-4 border-bottom">
                  <input 
                    className="form-check-input" 
                    type="checkbox" 
                    id="publicSwitch" 
                    checked={generalData.isPublic}
                    onChange={(e) => setGeneralData({...generalData, isPublic: e.target.checked})}
                  />
                  <label className="form-check-label ms-2" htmlFor="publicSwitch">
                    <span className="fw-bold d-block">Public Inventory</span>
                    <span className="small text-muted">Allow all authenticated users to add/edit items.</span>
                  </label>
                </div>
                
                {!generalData.isPublic && (
                  <div>
                    <label className="form-label fw-bold small">Add users with write access</label>
                    <div className="input-group mb-3">
                      <input type="text" className="form-control" placeholder="Search by name or email (autocomplete)..." />
                      <button className="btn btn-outline-primary">Add User</button>
                    </div>
                    {/* User list will be here */}
                    <p className="small text-muted">Currently only you have access.</p>
                  </div>
                )}
              </div>
            </div>
          </div>
        )}

        {activeTab === 'stats' && (
          <div className="premium-card p-4 text-center text-muted">
            <BarChart2 size={48} className="opacity-25 mb-3 mx-auto" />
            <h5>Inventory Aggregation & Statistics</h5>
            <p className="small">Calculations based on custom field types will appear here.</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default InventoryView;
