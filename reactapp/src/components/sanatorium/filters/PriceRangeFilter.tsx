import React from 'react';
import ReactSlider from 'react-slider'

interface PriceRangeFilterProps {
  selectedRange: number[];
  onRangeChange: (selectedRange: number[]) => void;
}

const PriceRangeFilter: React.FC<PriceRangeFilterProps> = ({ selectedRange, onRangeChange}) => {
  const handleRangeChange = (value: number[], index: number) => {
    onRangeChange(value);
  };

  return (
    <div className="border p-4 rounded-md shadow-md mb-4">
      <h2 className="text-lg font-semibold mb-2">Цена</h2>
      <div className="flex items-center space-x-4">
      <ReactSlider
          className="horizontal-slider"
          thumbClassName="example-thumb"
          trackClassName="example-track"
          defaultValue={selectedRange}
          ariaLabel={['Lower thumb', 'Upper thumb']}
          ariaValuetext={state => `Thumb value ${state.valueNow}`}
          renderThumb={(props, state) => <div {...props}>{state.valueNow}</div>}
          //pearling
          max={selectedRange[1]}
          min={selectedRange[0]}
          minDistance={10}
          step={10}
          onAfterChange={handleRangeChange}
      />
      </div>
    </div>
  );
};

export default PriceRangeFilter;
