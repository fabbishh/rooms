// TourFilters.tsx
import { Button, Checkbox, Label, Select, TextInput } from 'flowbite-react';
import React, { useEffect, useState } from 'react';
import DatePicker from '../ui/DatePicker';
import { FaRegCircleXmark } from 'react-icons/fa6';
import TourTypeSelect from './TourTypeSelect';
import { seasonsData } from '../../data/Seasons';

interface TourFiltersProps {
	onFilterChange: (filters: any) => void;
}

interface TourFilter {
	daysFrom?: string;
	daysTo?: string;
	priceFrom?: string;
	priceTo?: string;
	touristsFrom?: string;
	touristsTo?: string;
	startDate?: string;
	endDate?: string;
	tourType?: string;
}

const TourFilters: React.FC<TourFiltersProps> = ({ onFilterChange }) => {

	const [filter, setFilter] = useState<any>({});
	const [seasons, setSeasons] = useState<any[]>([]);

	useEffect(() => {
		setSeasons(seasonsData);
	}, [])

	useEffect(() => {
		setFilter({
			...filter,
			seasons: seasons.filter(s => s.checked).map(s => s.key)
		});
	}, [seasons])

	function handleChange(e: any) {
		const value = e.target.value;
		setFilter({
			...filter,
			[e.target.name]: value
		});
	}

	const handleDateChange = (name: string, value: any) => {
		setFilter({
			...filter,
			[name]: value
		});
	}

	const handleTypeChange = (type: any) => {
		setFilter({
			...filter,
			tourType: type ? type.value : ""
		});
	}

	// Обработчик применения фильтров
	const applyFilters = () => {
		onFilterChange(replaceEmptyStringWithNull(filter));
	};

	const handleFilterClear = () => {
		const clearedFilter = {
			daysFrom: "",
			daysTo: "",
			priceFrom: "",
			priceTo: "",
			touristsFrom: "",
			touristsTo: "",
			startDate: "",
			endDate: "",
			tourType: null,
			seasons: []
		};
		setFilter(clearedFilter);
		onFilterChange(replaceEmptyStringWithNull(clearedFilter));
	}

	const handleCheckboxChange = (clickedKey: number) => {
        var newSeasons = []
        if(clickedKey === 4) {
            const checked = seasons.find(s => s.key === 4)?.checked
            newSeasons = seasons.map((item) => {
                return { ...item, checked: !checked };
            });
        } else {
            newSeasons = seasons.map((item) => {
                if (item.key === clickedKey) {
                    return { ...item, checked: !item.checked };
                }
    
                return item;
            });
        }
        if(newSeasons[0].checked && newSeasons[1].checked && newSeasons[2].checked && newSeasons[3].checked) {
            newSeasons[4].checked = true;
        } else {
            newSeasons[4].checked = false;
        }
        setSeasons(newSeasons);
    };


	const replaceEmptyStringWithNull = (obj: any) => {
		const result: Record<string, string | null> = {};

		for (const key in obj) {
			if (Object.prototype.hasOwnProperty.call(obj, key)) {
				result[key] = obj[key] === "" ? null : obj[key];
			}
		}

		return result;
	};

	return (
		<div className="bg-gray-50 p-4 rounded-md shadow">
			<h2 className="text-xl font-semibold mb-4">Подборка туров и экскурсий</h2>
			<div className='mb-4'>
				<span className="text-gray-700">Продолжительность:</span>
				<div className='flex gap-2'>
					<TextInput name="daysFrom" type="number" sizing="md" placeholder='от' value={filter.daysFrom} onChange={handleChange} />
					<TextInput name="daysTo" type="number" sizing="md" placeholder='до' value={filter.daysTo} onChange={handleChange} />
				</div>
			</div>
			<div className='mb-4'>
				<span className="text-gray-700">Туристов в группе:</span>
				<div className='flex gap-2'>
					<TextInput name="touristsFrom" type="number" sizing="md" placeholder='от' value={filter.touristsFrom} onChange={handleChange} />
					<TextInput name="touristsTo" type="number" sizing="md" placeholder='до' value={filter.touristsTo} onChange={handleChange} />
				</div>
			</div>
			<div className='mb-4'>
				<span className="text-gray-700">Сезон:</span>
				<div className='gap-2'>
					{seasons.map((item: any) => (
						<div key={item.key} className='flex items-center gap-2'>
							<Checkbox
								checked={item.checked}
								disabled={item.disabled}
								onChange={() => handleCheckboxChange(item.key)} />
							<Label >
								{item.name}
							</Label>
						</div>
					))}

				</div>
			</div>

			<div className="mb-4">
				<span className="text-gray-700">Вид тура:</span>
				<TourTypeSelect value={filter.tourType} onChange={handleTypeChange} />
			</div>

			<div className='mb-4'>
				<span className="text-gray-700">Стоимость:</span>
				<div className='flex gap-2'>
					<TextInput name="priceFrom" type="number" sizing="md" placeholder='от' value={filter.priceFrom} onChange={handleChange} />
					<TextInput name="priceTo" type="number" sizing="md" placeholder='до' value={filter.priceTo} onChange={handleChange} />
				</div>
			</div>

			<div className='mb-4'>
				<span className="text-gray-700">Ближайшая дата начала в период:</span>
				<div>
					<div className='flex items-center mb-2'>
						<div className='w-[50px]'>
							<span className="text-gray-700">c:</span>
						</div>
						<DatePicker onDateChange={(value: any) => handleDateChange("startDate", value)} value={filter.startDate} />
					</div>
					<div className='flex items-center'>
						<div className='w-[50px]'>
							<span className="text-gray-700">по:</span>
						</div>
						<DatePicker onDateChange={(value: any) => handleDateChange("endDate", value)} value={filter.endDate} />
					</div>
				</div>
			</div>
			<div className="flex justify-center gap-5">
				<Button onClick={applyFilters}>Применить</Button>
				<Button color="light" onClick={handleFilterClear}>
					Сбросить
				</Button>
			</div>
		</div>
	);
};

export default TourFilters;
