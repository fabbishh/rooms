import { format } from 'date-fns'
import { ru } from 'date-fns/locale'
import { TextInput } from 'flowbite-react'
import React, { useState } from 'react'
import { DateRange } from 'react-date-range'
import { FaCalendarWeek } from "react-icons/fa6";

import 'react-date-range/dist/styles.css';
import 'react-date-range/dist/theme/default.css';

type DateRangePickerProps = {
	value: any,
	onChange: (item: any) => void,
	disabledDates: Date[]
}

const CustomDateRangePicker = ({ value, onChange, disabledDates }: DateRangePickerProps) => {
	const [open, setOpen] = useState(false)

	return (
		<div className="calendarWrap">
			<TextInput
				icon={FaCalendarWeek}
				value={`с ${format(value[0].startDate, "d MMMM yyyy", { locale: ru })} по ${format(value[0].endDate, "d MMMM yyyy", { locale: ru })}`}
				readOnly
				className="inputBox"
				onClick={ () => setOpen(open => !open) }
			/>
			{open && <DateRange
				ranges={value}
				onChange={onChange}
				locale={ru}
				disabledDates={disabledDates}
				minDate={new Date}
				className="calendarElement"
			/>}
		</div>

	)
}

export default CustomDateRangePicker