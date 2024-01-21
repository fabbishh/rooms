// Input.tsx
import React, { ChangeEvent } from 'react';

interface InputProps {
  label: string;
  value: string;
  className: string;
  onChange: (value: string) => void;
}

const TextInput: React.FC<InputProps> = ({ label, value, className, onChange }) => {
  const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
    onChange(event.target.value);
  };

  return (
    <div className="mb-4">
      <label className="block text-sm font-medium text-gray-600">{label}</label>
      <input
        type="text"
        value={value}
        onChange={handleChange}
        className={className}
      />
    </div>
  );
};

export default TextInput;
