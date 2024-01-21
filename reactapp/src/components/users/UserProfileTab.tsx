import { Button, Label, Radio, TextInput } from 'flowbite-react'
import React, { useEffect } from 'react'
import { Controller, SubmitHandler, useForm } from 'react-hook-form'
import api from '../../services/api/api'
import PhoneInput, { isValidPhoneNumber } from 'react-phone-number-input/input'
import Input from 'react-phone-number-input/input'
import { showNotification } from '../../utils/notificationManager'
import { format, parseISO } from 'date-fns'
import UserForm from './UserForm'

type Props = {}



const UserProfileTab = (props: Props) => {
    return (
        <div className='mx-24'>
            <h1 className='text-xl font-semibold'>Настройки профиля</h1>
            <p>Укажите свои данные, чтобы при бронировании они заполнялись автоматически.</p>
            <UserForm role="user"/>
        </div>
    )
}

export default UserProfileTab