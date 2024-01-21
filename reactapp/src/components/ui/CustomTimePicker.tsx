// Button.tsx
import React, { useEffect, useState } from 'react';
import TimePicker from 'react-time-picker'
import 'react-time-picker/dist/TimePicker.css';
import 'react-clock/dist/Clock.css';
import { FieldValues, UseFormRegister, UseFormSetValue } from 'react-hook-form';

interface CustomTimePickerProps {
	value?: string,
	onChange?: (value: any) => void,
}

const CustomTimePicker: React.FC<CustomTimePickerProps> = ({ value, onChange }) => {
	const handleTimeChange = (value: any) => {
		onChange?.(value);
	}

	return (
		<TimePicker value={value} onChange={handleTimeChange} clearIcon={null}/>
	);
};

export default CustomTimePicker;
