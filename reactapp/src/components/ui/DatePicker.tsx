import { Datepicker } from 'flowbite-react'
import React from 'react'

type Props = {
    onDateChange: (value: any) => void;
    value?: string
}



const DatePicker = ({ onDateChange, value }: Props) => {

    const handleDateChange = (date: any) => {
        onDateChange(date);
    }

    return (
        <Datepicker
            minDate={new Date()}
            weekStart={2}
            language='ru'
            labelTodayButton="Сегодня"
            labelClearButton="Очистить"
            onSelectedDateChanged={handleDateChange}
        />
    )
}

export default DatePicker