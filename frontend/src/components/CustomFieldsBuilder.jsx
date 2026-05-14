import React, { useState } from 'react';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';
import { GripVertical, X, Plus, Eye, EyeOff } from 'lucide-react';
import { useTheme } from '../context/ThemeContext';

const FIELD_TYPES = [
  { id: 'string', label: 'Single-line Text', max: 3 },
  { id: 'multiline', label: 'Multi-line Text', max: 3 },
  { id: 'number', label: 'Numeric', max: 3 },
  { id: 'link', label: 'Image/Link', max: 3 },
  { id: 'boolean', label: 'Checkbox', max: 3 },
];

const CustomFieldsBuilder = () => {
  const { isDarkMode } = useTheme();
  const [fields, setFields] = useState([]);

  const onDragEnd = (result) => {
    if (!result.destination) return;
    const items = Array.from(fields);
    const [reorderedItem] = items.splice(result.source.index, 1);
    items.splice(result.destination.index, 0, reorderedItem);
    setFields(items);
  };

  const addField = (type) => {
    const count = fields.filter(f => f.type === type.id).length;
    if (count >= type.max) {
      alert(`You can only have up to ${type.max} ${type.label} fields.`);
      return;
    }

    const newField = {
      id: `field-${Date.now()}`,
      type: type.id,
      title: '',
      description: '',
      showInTable: true
    };
    setFields([...fields, newField]);
  };

  const removeField = (id) => {
    setFields(fields.filter(f => f.id !== id));
  };

  const updateField = (id, key, val) => {
    setFields(fields.map(f => f.id === id ? { ...f, [key]: val } : f));
  };

  return (
    <div className="premium-card p-4">
      <div className="mb-4">
        <h3 className="h5 fw-bold mb-1">Custom Fields</h3>
        <p className="small text-muted mb-0">Define additional properties for your items.</p>
      </div>

      <div className="row g-4">
        {/* Toolbar */}
        <div className="col-12 border-bottom pb-3">
          <div className="d-flex flex-wrap gap-2">
            {FIELD_TYPES.map(type => (
              <button
                key={type.id}
                className="btn btn-sm btn-outline-primary rounded-pill d-flex align-items-center gap-1"
                onClick={() => addField(type)}
              >
                <Plus size={14} />
                {type.label}
              </button>
            ))}
          </div>
        </div>

        {/* Builder Area */}
        <div className="col-12">
          <DragDropContext onDragEnd={onDragEnd}>
            <Droppable droppableId="custom-fields">
              {(provided) => (
                <div {...provided.droppableProps} ref={provided.innerRef} className="d-flex flex-column gap-3">
                  {fields.map((field, index) => (
                    <Draggable key={field.id} draggableId={field.id} index={index}>
                      {(provided, snapshot) => (
                        <div
                          ref={provided.innerRef}
                          {...provided.draggableProps}
                          className={`p-3 rounded-3 border ${
                            snapshot.isDragging ? 'bg-primary bg-opacity-10 border-primary' : (isDarkMode ? 'bg-secondary border-dark' : 'bg-light border-light')
                          }`}
                        >
                          <div className="d-flex align-items-start gap-3">
                            <div {...provided.dragHandleProps} className="mt-2">
                              <GripVertical size={18} className="opacity-50" />
                            </div>
                            
                            <div className="flex-grow-1 row g-3">
                              <div className="col-md-4">
                                <label className="small fw-bold opacity-75 d-block mb-1">Title</label>
                                <input
                                  type="text"
                                  className="form-control form-control-sm"
                                  placeholder="e.g. Serial Number"
                                  value={field.title}
                                  onChange={(e) => updateField(field.id, 'title', e.target.value)}
                                />
                              </div>
                              <div className="col-md-5">
                                <label className="small fw-bold opacity-75 d-block mb-1">Description (Hint)</label>
                                <input
                                  type="text"
                                  className="form-control form-control-sm"
                                  placeholder="Tooltip for users"
                                  value={field.description}
                                  onChange={(e) => updateField(field.id, 'description', e.target.value)}
                                />
                              </div>
                              <div className="col-md-3 d-flex align-items-center gap-3 pt-4">
                                <button
                                  className={`btn btn-sm p-0 ${field.showInTable ? 'text-primary' : 'text-muted'}`}
                                  onClick={() => updateField(field.id, 'showInTable', !field.showInTable)}
                                  title="Show in table"
                                >
                                  {field.showInTable ? <Eye size={18} /> : <EyeOff size={18} />}
                                </button>
                                <span className="badge bg-secondary text-capitalize small">
                                  {field.type}
                                </span>
                              </div>
                            </div>

                            <button className="btn btn-link btn-sm p-0 text-danger mt-2" onClick={() => removeField(field.id)}>
                              <X size={18} />
                            </button>
                          </div>
                        </div>
                      )}
                    </Draggable>
                  ))}
                  {provided.placeholder}
                </div>
              )}
            </Droppable>
          </DragDropContext>
        </div>
      </div>
      
      {fields.length === 0 && (
        <div className="text-center py-5 opacity-50 border-dashed rounded-3 mt-3">
          <p className="mb-0">No custom fields added yet. Choose a type from above to start.</p>
        </div>
      )}
    </div>
  );
};

export default CustomFieldsBuilder;
