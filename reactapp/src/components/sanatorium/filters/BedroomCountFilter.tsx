// BedroomCountFilter.tsx
import React, { useState } from 'react';

interface BedroomCountFilterProps {
  selectedCounts: number[];
  onCountChange: (selectedCounts: number[]) => void;
}

const BedroomCountFilter: React.FC<BedroomCountFilterProps> = ({ selectedCounts, onCountChange }) => {
  const bedroomCounts = [1, 2, 3, 4, 5];

  const handleCountChange = (count: number) => {
    const updatedCounts = selectedCounts.includes(count)
      ? selectedCounts.filter(c => c !== count)
      : [...selectedCounts, count];

    onCountChange(updatedCounts);
  };

  return (
    <div className="border p-4 rounded-md shadow-md mb-4">
      <h2 className="text-lg font-semibold mb-2">Количество спален</h2>
      <div className='flex'>
        {bedroomCounts.map(count => (
          <label key={count} className="flex items-center mb-2 mr-3">
            <input
              type="checkbox"
              checked={selectedCounts.includes(count)}
              onChange={() => handleCountChange(count)}
              className="mr-2"
            />
            {count}
          </label>
        ))}
      </div>

    </div>
  );
};

export default BedroomCountFilter;
