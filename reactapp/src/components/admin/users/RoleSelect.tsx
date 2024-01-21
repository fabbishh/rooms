import { Select } from 'flowbite-react'
import React from 'react'

type Props = {
    value: any,
    onChange: any
}

const RoleSelect = ({value, onChange}: Props) => {
  return (
    <Select onChange={onChange} value={value}>
        <option value="0">Администратор</option>
        <option value="1">Администратор санатория</option>
        <option value="2">Администратор турагенства</option>
        <option value="3">Пользователь</option>
    </Select>
  )
}

export default RoleSelect