import React, { useState } from 'react';
import { useTheme } from '../context/ThemeContext';
import { Trash2, Edit3, Plus, MoreHorizontal } from 'lucide-react';
import { motion, AnimatePresence } from 'framer-motion';

const DataTable = ({ columns, data, onEdit, onDelete, onCreate }) => {
  const { isDarkMode } = useTheme();
  const [selectedIds, setSelectedIds] = useState([]);

  const toggleSelectAll = () => {
    if (selectedIds.length === data.length) {
      setSelectedIds([]);
    } else {
      setSelectedIds(data.map(item => item.id));
    }
  };

  const toggleSelect = (id) => {
    if (selectedIds.includes(id)) {
      setSelectedIds(selectedIds.filter(i => i !== id));
    } else {
      setSelectedIds([...selectedIds, id]);
    }
  };

  return (
    <div className="position-relative">
      {/* Table Toolbar - Requirement: Use toolbars instead of row buttons */}
      <AnimatePresence>
        {selectedIds.length > 0 && (
          <motion.div
            initial={{ y: 50, x: '-50%', opacity: 0 }}
            animate={{ y: 0, x: '-50%', opacity: 1 }}
            exit={{ y: 50, x: '-50%', opacity: 0 }}
            className="floating-toolbar"
          >
            <span className="text-white me-3 border-end pe-3 small">
              {selectedIds.length} selected
            </span>
            <button className="btn btn-link text-white p-0" onClick={() => onEdit(selectedIds[0])}>
              <Edit3 size={20} />
            </button>
            <button className="btn btn-link text-white p-0" onClick={() => onDelete(selectedIds)}>
              <Trash2 size={20} />
            </button>
          </motion.div>
        )}
      </AnimatePresence>

      <div className="d-flex justify-content-between align-items-center mb-3">
        <h2 className="h5 fw-bold mb-0">Items</h2>
        <button className="btn btn-primary rounded-pill px-3 d-flex align-items-center gap-2" onClick={onCreate}>
          <Plus size={18} />
          Add Item
        </button>
      </div>

      <div className="table-responsive">
        <table className={`premium-table ${isDarkMode ? 'text-light' : 'text-dark'}`}>
          <thead>
            <tr>
              <th style={{ width: '40px' }}>
                <input
                  type="checkbox"
                  className="form-check-input"
                  checked={selectedIds.length === data.length && data.length > 0}
                  onChange={toggleSelectAll}
                />
              </th>
              {columns.map(col => (
                <th key={col.key} className="text-muted small text-uppercase fw-bold">
                  {col.title}
                </th>
              ))}
              <th style={{ width: '40px' }}></th>
            </tr>
          </thead>
          <tbody>
            {data.map(item => (
              <tr key={item.id} onClick={() => toggleSelect(item.id)}>
                <td>
                  <input
                    type="checkbox"
                    className="form-check-input"
                    checked={selectedIds.includes(item.id)}
                    readOnly
                  />
                </td>
                {columns.map(col => (
                  <td key={col.key}>{item[col.key]}</td>
                ))}
                <td>
                  <MoreHorizontal size={18} className="text-muted" />
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {data.length === 0 && (
        <div className="text-center py-5 opacity-50">
          <p>No items found.</p>
        </div>
      )}
    </div>
  );
};

export default DataTable;
