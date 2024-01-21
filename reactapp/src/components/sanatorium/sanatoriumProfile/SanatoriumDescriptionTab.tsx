import { Button, Label } from 'flowbite-react'
import React, { useEffect } from 'react'
import { Controller, SubmitHandler, useForm } from 'react-hook-form'
import Editor from '../../ui/Editor'
import useSanatoriumInfo from '../../../hooks/useSanatoriumInfo'
import api from '../../../services/api/api'
import { showNotification } from '../../../utils/notificationManager'

type Props = {}

interface IFormFields {
    sanatoriumId: string,
    description: string
}

const SanatoriumDescriptionTab = (props: Props) => {
    const { sanatoriumInfo } = useSanatoriumInfo();
    const {
        setValue,
        handleSubmit,
        control,
        formState: { errors }
    } = useForm<IFormFields>()

    useEffect(() => {
        const fetchData = async () => {
            if(sanatoriumInfo?.id) {
                setValue("sanatoriumId", sanatoriumInfo.id)
                try {
                    var response = await api.get(`/sanatorium/description/${sanatoriumInfo.id}`)
                    setValue("description", response.data)
                } catch (error) {
                    
                }
            }
        }

        fetchData();
    }, [sanatoriumInfo?.id])

    const onSubmit: SubmitHandler<IFormFields> = async (data: any) => {
        try {
            await api.post("sanatorium/save-description", data);
            showNotification("success", "Информация сохранена");
        } catch (error) {
            
        }
    }
    
    return (
        <div className='mx-24'>
            <form className='space-y-6' onSubmit={handleSubmit(onSubmit)}>
                <div className='sanatorium-description'>
                    <Controller
                        control={control}
                        name="description"
                        rules={{
                            required: "Поле обязательно для заполнения"
                        }}
                        render={({
                            field: { onChange, value },
                        }) => (
                            <Editor value={value} onChange={onChange} />
                        )}
                    />
                    <p className='text-red-500'>{errors?.description?.message}</p>
                </div>
                <div>

                </div>
                <div className='flex justify-center'>
                    <Button type="submit">Сохранить</Button>
                </div>
            </form>
           
        </div>
    )
}

export default SanatoriumDescriptionTab