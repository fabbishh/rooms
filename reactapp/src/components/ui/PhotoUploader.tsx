import React, { useState, ChangeEvent } from 'react';
import { UseFormRegister, UseFormSetValue } from 'react-hook-form';
import { FaFileImage } from 'react-icons/fa';

interface PhotoUploaderProps {
  onChange: (selectedPhotos: File[]) => void;
}

const PhotoUploader: React.FC<PhotoUploaderProps> = ({ onChange }) => {
  const [selectedPhotos, setSelectedPhotos] = useState<File[]>([]);
  const [photoPreviews, setPhotoPreviews] = useState<string[]>([]);

  const handlePhotoChange = (e: ChangeEvent<HTMLInputElement>) => {
    const files = e.target.files;

    if (files) {
      const newSelectedPhotos = Array.from(files);
      const newValidPhotos = checkDuplicates(newSelectedPhotos);

      setSelectedPhotos([...selectedPhotos, ...newValidPhotos]);
      onChange([...selectedPhotos, ...newValidPhotos]);

      const newPhotoPreviews = newValidPhotos.map((photo) => {
        if (!photoPreviews.includes(photo.name)) {
          const reader = new FileReader();

          return new Promise<string>((resolve) => {
            reader.onload = (e) => {
              const result = e.target?.result as string;
              resolve(result);
            };
            reader.readAsDataURL(photo);
          });
        }

        return Promise.resolve('');
      });

      Promise.all(newPhotoPreviews).then((previews) => {
        const filteredPreviews = previews.filter((preview) => preview !== '');
        setPhotoPreviews([...photoPreviews, ...filteredPreviews]);
      });

      e.target.value = '';
    }
  };

  const handleRemovePhoto = (index: number) => {
    const newSelectedPhotos = [...selectedPhotos];
    newSelectedPhotos.splice(index, 1);

    const newPhotoPreviews = [...photoPreviews];
    newPhotoPreviews.splice(index, 1);

    setSelectedPhotos(newSelectedPhotos);
    setPhotoPreviews(newPhotoPreviews);

    onChange(selectedPhotos);
  };

  const checkDuplicates = (newSelectedphotos: File[]) => {
      const newValidPhotos: File[] = [];
      var uniquePhotos = selectedPhotos;

      newSelectedphotos.forEach(selectedPhoto => {
        const photoExists = uniquePhotos.some(uniquePhoto => uniquePhoto.name === selectedPhoto.name)

        if(!photoExists) {
          newValidPhotos.push(selectedPhoto);
        } else {

        }
      })

      return newValidPhotos;
  }
  

  return (
    <div className="">
        <label className="cursor-pointer">
            <input
                type="file"
                onChange={handlePhotoChange}
                multiple
                className="hidden"
                accept="image/png, image/jpeg"
            />
            <div className="w-16 h-16 bg-gray-300 flex items-center justify-center rounded-full">
              <FaFileImage size={32} color="#4A5568" />
            </div>
          </label>
      <div className="flex flex-wrap mt-8">
        {photoPreviews.map((preview, index) => (
          <div key={index} className="relative mr-4 mb-4">
            <img
              src={preview}
              alt={`Preview ${index}`}
              className="w-24 rounded "
            />
            <button
              onClick={() => handleRemovePhoto(index)}
              className="absolute top-0 right-0 p-1 bg-red-500 text-white rounded-full"
            >
              X
            </button>
          </div>
        ))}
      </div>
    </div>
  );
};

export default PhotoUploader;
