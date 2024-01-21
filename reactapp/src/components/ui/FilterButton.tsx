// FilterButton.tsx
import React from 'react';

interface FilterButtonProps {
  onClick: () => void;
}

const FilterButton: React.FC<FilterButtonProps> = ({ onClick }) => {
  return (
    <button className="bg-gray-400 text-white px-4 py-2 rounded" onClick={onClick}>
      Фильтр
    </button>
  );
};

export default FilterButton;
