// Select.tsx
import React, { ChangeEvent } from 'react';

interface SelectProps {
  label: string;
  options: { value: string; label: string }[];
  onChange: (selectedValue: string) => void;
}

const Select: React.FC<SelectProps> = ({ label, options, onChange }) => {
  const handleSelectChange = (e: ChangeEvent<HTMLSelectElement>) => {
    onChange(e.target.value);
  };

  return (
    <div className="m-4">
      <label htmlFor="select" className="block text-sm font-medium text-gray-700">
        {label}
      </label>
      <select
        id="select"
        name="select"
        onChange={handleSelectChange}
        className="mt-1 block w-full py-2 px-3 border border-gray-300 bg-white rounded-md shadow-sm focus:outline-none focus:border-blue-500 focus:ring focus:ring-blue-200 transition duration-150 ease-in-out"
      >
        {options.map((option) => (
          <option key={option.value} value={option.value}>
            {option.label}
          </option>
        ))}
      </select>
    </div>
  );
};

export default Select;
