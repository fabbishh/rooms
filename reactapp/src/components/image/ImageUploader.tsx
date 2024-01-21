import { Button } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import { FaRegCircleXmark } from 'react-icons/fa6';
import ImageUploading, { ImageListType } from 'react-images-uploading';

type ImageUploaderProps = {
    multiple: boolean,
    maxNumber?: number, 
    initialImages?: any,
    onChange?: any,
    onDelete?: any
}

const ImageUploader = ({ multiple, maxNumber, initialImages, onChange, onDelete }: ImageUploaderProps) => {

    const [images, setImages] = useState(initialImages ? initialImages : []);

    useEffect(() => {
        setImages(initialImages)
    }, [initialImages])

    const handleChange = (imageList: any, addUpdateIndex: any) => {
        setImages(imageList);
        onChange?.(imageList);
    };

    return (
        <ImageUploading
            multiple = {multiple}
            value={images}
            onChange={handleChange}
            maxNumber={maxNumber}
            dataURLKey="data_url"
        >
            {({
                imageList,
                onImageUpload,
                onImageRemoveAll,
                onImageUpdate,
                onImageRemove,
                isDragging,
                dragProps,
            }) => {
                const handleUpdate = (event: React.MouseEvent<HTMLButtonElement>, index: number) => {
                    event.preventDefault();
                    onImageUpdate(index);
                }

                const handleDelete = (event: React.MouseEvent<HTMLButtonElement>, index: number) => {
                    event.preventDefault();
                    onDelete(imageList[index]);
                    onImageRemove(index);
                }

                if(multiple) {
                    return (
                        <div className="flex flex-wrap gap-2">
                            {imageList.map((image, index) => (
                                <div key={index} className="image-item relative">
                                    <div className="border rounded-lg w-[100px] h-[100px]">
                                        <img src={image['data_url']} alt="" className='object-cover h-[100%] w-[100%] rounded-lg'/>
                                    </div>
                                    
                                    <div className="image-item__btn-wrapper absolute top-0 right-0 p-2 z-1000000">
                                        <button color="light" onClick={(event) => handleDelete(event, index)}><FaRegCircleXmark /></button>
                                    </div>
                                </div>
                            ))}
                            <Button
                                className='w-[100px] h-[100px]'
                                color="light"
                                onClick={onImageUpload}
                                {...dragProps}
                            >
                                <img src="https://fb-blog.ru/wp-content/uploads/dobavit-foto-v-facebook-1.png" alt=""/>
                            </Button>
                        </div>
                    ) 
                } else {
                    return (
                        <div>
                            {imageList.map((image, index) => (
                                <div key={index} className="h-full">
                                    <div className='border-solid border-2 rounded-lg w-[140px] h-[140px]'>
                                        <img src={image['data_url']} alt="" className='object-cover h-[100%] w-[100%] rounded-lg'/>
                                    </div>
                                    
                                    <div className="flex justify-center">
                                        <button onClick={(event) => handleUpdate(event, index)}>Обновить</button>
                                    </div>
                                </div>
                            ))}
                        {imageList.length === 0 && <Button
                                color="light"
                                onClick={onImageUpload}
                                {...dragProps}
                                className='border-solid border-2 rounded-lg w-[140px] h-[140px]'
                            >
                                <img src="https://fb-blog.ru/wp-content/uploads/dobavit-foto-v-facebook-1.png" alt="" className='object-cover h-[100%] w-[100%] rounded-lg'/>
                            </Button>}
                            
                            
                        </div>
                    ) 
                }
            }}
        </ImageUploading>
    )
}

export default ImageUploader