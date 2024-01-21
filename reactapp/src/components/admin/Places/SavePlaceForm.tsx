import React, { useEffect, useState } from 'react'
import { Controller, SubmitHandler, useForm } from 'react-hook-form';
import ImageUploader from '../../image/ImageUploader';
import { Button, Label, TextInput } from 'flowbite-react';
import Editor from '../../ui/Editor';
import RegionSelect from '../../region/RegionSelect';
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';

type Props = {
    onSave?: () => void;
    placeId?: string;
}

interface IFormFields {
    id: string,
    name: string,
    description: string,
    subjectId: string,
    photos: File[]
}

const SavePlaceForm = ({ onSave, placeId }: Props) => {

    const [initialPhotos, setInitialPhotos] = useState<any[]>([]);
    const [deletedPhotos, setDeletedPhotos] = useState<any[]>([]);

    const {
        register,
        handleSubmit,
        setValue,
        reset,
        control,
        formState: { errors }
    } = useForm<IFormFields>();

    useEffect(() => {
        if (placeId) {
            const fetchFormData = async () => {
                try {
                    const response = await api.get(`/place/${placeId}`)
                    const { photos, ...data } = response.data;
                    reset(data);
                    setInitialPhotos(response.data.photos.map((item: any) => ({ 'data_url': item.url, id: item.id })))
                } catch (error: any) {
                    showNotification("error", error.message)
                }
            }

            fetchFormData();
        }

    }, [placeId])

    const handleImagesChange = (imageList: any) => {
        setValue("photos", imageList.map((image: any) => image.file));
    }

    const handleImageDelete = (item: any) => {
        if (item.hasOwnProperty("id")) {
            setDeletedPhotos([...deletedPhotos, item.id])
        }
    }

    const onSubmit: SubmitHandler<IFormFields> = async (data: any) => {
        try {
            var formData = new FormData();

            for (var key in data) {
                if (key === "photos") {
                    data[key].forEach((photo: File) => {
                        formData.append("photos", photo);
                    })
                    continue;
                }
                formData.append(key, data[key]);
            }

            if (data.id) {
                deletedPhotos.forEach((photoId: string) => {
                    formData.append("deletedPhotos", photoId);
                })
            }

            await api.post("/place/save", formData);
            reset();
            onSave?.()
            showNotification("success", placeId ? "Место успешно обновлено!" : "Место успешно добавлено!")
        }
        catch(error: any) {
        }
    }

    return (
        <form onSubmit={handleSubmit(onSubmit)} className="space-y-6">
            <div>
                <div className="mb-2 block">
                    <Label htmlFor="name" value="Название" />
                </div>

                <Controller
                    control={control}
                    name="name"
                    rules={{
                        required: "Поле обязательно для заполнения"
                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <TextInput
                            value={value}
                            onChange={onChange}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.name?.message}</p>
            </div>
            <div>
                <div className="mb-2 block">
                    <Label htmlFor="subject" value="Субъект" />
                </div>
                <Controller
                    control={control}
                    name="subjectId"
                    rules={{
                        required: "Поле обязательно для заполнения"
                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <RegionSelect
                            value={value}
                            onChange={(item: any) => setValue("subjectId", item?.value)}
                            isClearable={true}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.subjectId?.message}</p>
            </div>
            <div className=''>
                <ImageUploader multiple={true} maxNumber={10} onChange={handleImagesChange} onDelete={handleImageDelete} initialImages={initialPhotos} />
            </div>
            <div>
                <div className="mb-2 block">
                    <Label htmlFor="description" value="Описание" />
                </div>
                <Controller
                    control={control}
                    name="description"
                    rules={{
                        required: "Поле обязательно для заполнения"
                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <Editor value={value} onChange={onChange} />
                    )}
                />
                <p className='text-red-500'>{errors?.description?.message}</p>
            </div>
            <div className="flex justify-center">
                <Button type="submit">
                    Сохранить
                </Button>
            </div>
        </form>
    )
}

export default SavePlaceForm