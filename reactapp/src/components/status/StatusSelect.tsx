import { Select } from 'flowbite-react'
import React from 'react'
import { Status } from '../../shared/app.enums'
import { ConvertReservationStatusToRuLocale } from '../../utils/enumUtils'

type Props = {
    value: any,
    onChange: () => void 
}

const StatusSelect = ({ value, onChange }: Props) => {
    return (
        <Select
            onChange={onChange}
            value={value}
        >
            <option value={Status.Confirmed}>{ConvertReservationStatusToRuLocale(Status.Confirmed)}</option>
            <option value={Status.Declined}>{ConvertReservationStatusToRuLocale(Status.Declined)}</option>
            <option value={Status.Pending}>{ConvertReservationStatusToRuLocale(Status.Pending)}</option>
        </Select>
    )
}

export default StatusSelect