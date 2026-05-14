import React, { useState } from 'react';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';
import { GripVertical, X, Plus, Info } from 'lucide-react';
import { useTheme } from '../context/ThemeContext';

const ELEMENT_TYPES = [
  { id: 'text', label: 'Fixed Text', default: 'INV-' },
  { id: 'random20', label: '20-bit Random' },
  { id: 'random32', label: '32-bit Random' },
  { id: 'random6', label: '6-digit Random' },
  { id: 'random9', label: '9-digit Random' },
  { id: 'guid', label: 'GUID' },
  { id: 'datetime', label: 'Date/Time' },
  { id: 'sequence', label: 'Sequence' },
];

const IdBuilder = () => {
  const { isDarkMode } = useTheme();
  const [elements, setElements] = useState([
    { id: 'el-1', type: 'text', value: 'EQUIP-' },
    { id: 'el-2', type: 'sequence', value: '' }
  ]);

  const onDragEnd = (result) => {
    if (!result.destination) return;
    const items = Array.from(elements);
    const [reorderedItem] = items.splice(result.source.index, 1);
    items.splice(result.destination.index, 0, reorderedItem);
    setElements(items);
  };

  const addElement = (type) => {
    const newElement = {
      id: `el-${Date.now()}`,
      type: type.id,
      value: type.default || ''
    };
    setElements([...elements, newElement]);
  };

  const removeElement = (id) => {
    setElements(elements.filter(el => el.id !== id));
  };

  const updateTextValue = (id, val) => {
    setElements(elements.map(el => el.id === id ? { ...el, value: val } : el));
  };

  // Preview generator
  const generatePreview = () => {
    return elements.map(el => {
      if (el.type === 'text') return el.value;
      if (el.type === 'sequence') return '001';
      if (el.type === 'random6') return '482910';
      if (el.type === 'guid') return 'f47ac10b...';
      if (el.type === 'datetime') return new Date().toISOString().split('T')[0];
      return `[${el.type}]`;
    }).join('');
  };

  return (
    <div className="premium-card p-4">
      <div className="d-flex justify-content-between align-items-center mb-4">
        <h3 className="h5 fw-bold mb-0">Custom ID Builder</h3>
        <div className="badge bg-primary rounded-pill px-3 py-2">
          Preview: {generatePreview()}
        </div>
      </div>

      <div className="row g-4">
        {/* Element Library */}
        <div className="col-md-4">
          <p className="small text-muted fw-bold mb-3 uppercase">Elements</p>
          <div className="d-flex flex-wrap gap-2">
            {ELEMENT_TYPES.map(type => (
              <button
                key={type.id}
                className={`btn btn-sm ${isDarkMode ? 'btn-outline-light' : 'btn-outline-dark'} rounded-pill d-flex align-items-center gap-1`}
                onClick={() => addElement(type)}
              >
                <Plus size={14} />
                {type.label}
              </button>
            ))}
          </div>
        </div>

        {/* Builder Area */}
        <div className="col-md-8">
          <p className="small text-muted fw-bold mb-3 uppercase">Your Format (Drag to reorder)</p>
          <DragDropContext onDragEnd={onDragEnd}>
            <Droppable droppableId="id-elements">
              {(provided) => (
                <div {...provided.droppableProps} ref={provided.innerRef} className="d-flex flex-column gap-2">
                  {elements.map((el, index) => (
                    <Draggable key={el.id} draggableId={el.id} index={index}>
                      {(provided, snapshot) => (
                        <div
                          ref={provided.innerRef}
                          {...provided.draggableProps}
                          className={`d-flex align-items-center gap-3 p-3 rounded-3 border ${
                            snapshot.isDragging ? 'bg-primary text-white border-primary' : (isDarkMode ? 'bg-secondary border-dark text-light' : 'bg-light border-light')
                          }`}
                        >
                          <div {...provided.dragHandleProps}>
                            <GripVertical size={18} className="opacity-50" />
                          </div>
                          <div className="flex-grow-1">
                            <span className="small fw-bold d-block opacity-75">
                              {ELEMENT_TYPES.find(t => t.id === el.type)?.label}
                            </span>
                            {el.type === 'text' ? (
                              <input
                                type="text"
                                className="form-control form-control-sm mt-1 bg-transparent border-0 border-bottom text-inherit p-0"
                                value={el.value}
                                onChange={(e) => updateTextValue(el.id, e.target.value)}
                              />
                            ) : (
                              <span className="small italic text-muted">Auto-generated</span>
                            )}
                          </div>
                          <button className="btn btn-link btn-sm p-0 text-danger" onClick={() => removeElement(el.id)}>
                            <X size={18} />
                          </button>
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

      <div className="mt-4 p-3 rounded-3 bg-primary bg-opacity-10 border border-primary border-opacity-20 d-flex gap-2">
        <Info size={20} className="text-primary flex-shrink-0" />
        <p className="small mb-0 text-primary">
          Custom IDs are unique within this inventory. Existing items will keep their old IDs even if you change this format.
        </p>
      </div>
    </div>
  );
};

export default IdBuilder;
