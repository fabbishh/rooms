import React from 'react'
import { Status } from '../../shared/app.enums'
import { ConvertReservationStatusToRuLocale } from '../../utils/enumUtils'

type Props = {
	status: Status
}

const StatusComp = ({ status }: Props) => {

	const bgColor = status === Status.Confirmed
		? 'bg-green-500'
		: status === Status.Declined
			? 'bg-red-500'
			: status === Status.Pending
				? 'bg-yellow-400'
				: 'bg-grey-500';

	return (
		<div className={`text-white p-2 rounded-md ${bgColor} max-w-[110px]`}>
			{ConvertReservationStatusToRuLocale(status)}
		</div>
	)
}

export default StatusComp