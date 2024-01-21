import { Button } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import { FaPlus, FaMinus } from "react-icons/fa6";

type CounterProps = {
	onCountChange: (count: number) => void;
	value: number
}

const Counter = ({ onCountChange, value }: CounterProps) => {
	const [count, setCount] = useState(value);
	const [disabled, setDisabled] = useState(value === 0);

	const checkForDisabled = (value: number) => {
		if (value === 0) {
			setDisabled(true);
		} else {
			setDisabled(false);
		}
	}

	useEffect(() => {
		checkForDisabled(count);
		onCountChange(count);
	}, [count])

	const increment = () => {
		setCount(count + 1);
	};

	const decrement = () => {
		setCount(count -1 );
	};

	return (
		<div className='flex border rounded-md items-center'>
			<Button color="grey" disabled={disabled} onClick={decrement}><FaMinus /></Button>
			<span>{count}</span>
			<Button color="grey" onClick={increment}><FaPlus /></Button>
		</div>
	);
}

export default Counter