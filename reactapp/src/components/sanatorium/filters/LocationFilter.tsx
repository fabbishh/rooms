// LocationFilter.tsx
import React, { useState, useEffect } from 'react';

interface LocationFilterProps {
  selectedRegion: string;
  onRegionChange: (selectedRegion: string) => void;
}

const LocationFilter: React.FC<LocationFilterProps> = ({ selectedRegion, onRegionChange }) => {
  const [locations, setLocations] = useState<string[]>([]);

  useEffect(() => {
    // Мы использовать fetch или axios, чтобы получить список населенных пунктов из API
    // Пример: fetch('/api/locations').then(response => response.json()).then(data => setLocations(data));
  }, []);

  const handleRegionChange = (region: string) => {
    onRegionChange(region);
  };

  return (
    <div className="border p-4 rounded-md shadow-md mb-4">
      <h2 className="text-lg font-semibold mb-2">Населенный пункт</h2>
      <select
        value={selectedRegion}
        onChange={(e) => handleRegionChange(e.target.value)}
        className="w-full py-2 px-3 border rounded focus:outline-none focus:ring focus:border-blue-300"
      >
        <option value="all" className="text-gray-500">Выберите населенный пункт</option>
        {locations.map(location => (
          <option key={location} value={location}>
            {location}
          </option>
        ))}
      </select>
    </div>
  );
};

export default LocationFilter;
