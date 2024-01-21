// DropdownFilter.tsx
import React, { useState, useEffect, useRef } from 'react';

interface DropdownFilterProps {
  fetchOptions: (filter: string) => Promise<string[]>;
  onSelect: (selectedOption: string) => void;
}

const DropdownFilter: React.FC<DropdownFilterProps> = ({ fetchOptions, onSelect }) => {
  const [filteredOptions, setFilteredOptions] = useState<string[]>([]);
  const [inputValue, setInputValue] = useState('');
  const [isDropdownOpen, setIsDropdownOpen] = useState(false);
  const dropdownRef = useRef<HTMLDivElement | null>(null);

  useEffect(() => {
    const handleClickOutside = (event: Event) => {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target as Node)) {
        setIsDropdownOpen(false);
      }
    };

    document.addEventListener('mousedown', handleClickOutside);

    return () => {
      document.removeEventListener('mousedown', handleClickOutside);
    };
  }, []);

  const handleInputChange = async (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;
    setInputValue(value);

    try {
      const filtered = await fetchOptions(value);
      setFilteredOptions(filtered);
      setIsDropdownOpen(true);
    } catch (error) {
      console.error('Error fetching options:', error);
    }
  };

  const handleOptionSelect = (option: string) => {
    onSelect(option);
    setInputValue('');
    setIsDropdownOpen(false);
  };

  return (
    <div ref={dropdownRef} className="relative">
      <input
        type="text"
        value={inputValue}
        onChange={handleInputChange}
        placeholder="Выберите опцию..."
        className="border px-2 py-1 rounded"
        onFocus={() => setIsDropdownOpen(true)}
      />

      {isDropdownOpen && (
        <div className="absolute top-8 bg-white border rounded w-full">
          {filteredOptions.map((option, index) => (
            <div
              key={index}
              onClick={() => handleOptionSelect(option)}
              className="p-2 cursor-pointer hover:bg-gray-200"
            >
              {option}
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default DropdownFilter;
