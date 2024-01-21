import { Button, FileInput, Label, TextInput } from 'flowbite-react'
import Select from 'react-select';
import React, { useEffect, useState } from 'react'
import Editor from '../ui/Editor'
import { Controller, SubmitHandler, useForm } from 'react-hook-form'
import { AddressSuggestions, DaDataAddress, DaDataSuggestion } from 'react-dadata'
import { showNotification } from '../../utils/notificationManager'
import api from '../../services/api/api'
import ImageUploader from '../image/ImageUploader';
import StatusSelect from '../status/StatusSelect';
import RegionSelect from '../region/RegionSelect';

interface FormInput {
	id: string
	name: string;
	subjectId: string;
	location?: DaDataSuggestion<DaDataAddress>;
	email: string;
	link: string;
	description: string;
	photoUrl: string;
	logo: File,
	ownerId?: string,
	status: number
}

type Props = {
	role: "admin" | "tourAgency",
	tourAgencyId?: string,
	onSave?: () => void
}

const SaveTourAgencyForm = ({ role, tourAgencyId, onSave }: Props) => {
	const [logoPreview, setLogoPreview] = useState<string | null>(null);
	const [tourAgencyData, setTourAgencyData] = useState(null);
	const [userOptions, setUserOptions] = useState<any[]>([]);

	const [selectedRegionName, setSelectedRegionName] = useState<any>();

	const {
		handleSubmit,
		register,
		setValue,
		reset,
		watch,
		getValues,
		control,
		formState: { errors }
	} = useForm<FormInput>();

	useEffect(() => {
		const fetchData = async () => {
			try {
				let url = "";
				if (role === "admin") {
					if (!tourAgencyId) {
						return;
					}
					url = `/tourAgency/form-data/${tourAgencyId}`;
				} else {
					url = `/tourAgency/profile`
				}

				const response = await api.get(url)
				const data = {
					...response?.data, location: {
						value: response.data.location,
						unrestricted_value: null,
						data: null
					}
				};

				setTourAgencyData(data);
				setLogoPreview(data?.photoUrl)
			} catch (error: any) {
				showNotification('error', error.message);
			}

		}

		const fetchUsers = async () => {
			try {
				var response = await api.get("/user/touragency-admins");
				const options = response.data?.map((item: any) => ({ value: item.id, label: item.email }))
				setUserOptions(options);
			} catch (error: any) {
				showNotification("error", error.message);
			}
		}

		fetchData();
		if (role === "admin") {
			fetchUsers();
		}
	}, [])

	useEffect(() => {
		reset(tourAgencyData!);
	}, [tourAgencyData])

	const onPhotoChange = (imageList: any) => {
		setValue("logo", imageList[0].file);
		setLogoPreview(imageList[0].data_url);
	}

	const renderOwnerField = () => {
		if (role === "admin") {
			return (
				<div className='mb-4'>
					<div className="mb-2 block">
						<Label htmlFor="ownerId" value="Владелец" />
					</div>
					<Controller
						control={control}
						name="ownerId"
						rules={{
							required: "Поле обязательно для заполнения",
						}}
						render={({
							field: { onChange, value },
							fieldState: { invalid, isTouched, isDirty, error },
							formState,
						}) => (
							<Select
								options={userOptions}
								isSearchable={true}
								placeholder="Выберите пользователя"
								value={userOptions.find(u => u.value === value)}
								onChange={(item: any) => setValue("ownerId", item?.value)}
								isClearable={true}
								loadingMessage={() => "Загрузка..."}
								noOptionsMessage={() => "Ничего не найдено"}
							/>
						)}
					/>
					<p className='text-red-500'>{errors?.ownerId?.message}</p>
				</div>
			)
		}
	}

	const onSubmit: SubmitHandler<FormInput> = async (data: any) => {
		try {
			const formData = new FormData();

			for (var key in data) {
				if (key === "photoUrl") {
					continue;
				}
				if (key === "location") {
					formData.append(key, data[key].value);
					continue;
				}
				formData.append(key, data[key]);
			}

			const saveUrl = role === "admin" ? "/tourAgency/save-by-admin" : "/tourAgency/save-profile";
			await api.post(saveUrl, formData);
			onSave?.();
			showNotification("success", "Данные сохранены")
		} catch (error: any) {
			showNotification("error", error.message);
		}

	};

	const renderStatusSelect = () => {
		if (role === "admin") {
			return (
				<div>
					<div className="mb-2 block">
						<Label htmlFor="status" value="Изменить статус" />
					</div>
					<Controller
						control={control}
						name="status"
						defaultValue={
                            1
                        }
						render={({
							field: { onChange, value },
							fieldState: { error },
							formState,
						}) => (
							<StatusSelect value={value} onChange={onChange} />
						)}
					/>
				</div>
			)
		}
	}

	return (
		<form onSubmit={handleSubmit(onSubmit)} className="max-w-[800px]">
			<div className="flex flex-wrap gap-5">
				<div className="grow space-y-8">
					<div>
						<label className="block text-gray-700">Название:</label>
						<TextInput {...register("name")} />
					</div>
					<div>
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
									onChange={(item: any) => {
										setValue("subjectId", item?.value);
										setSelectedRegionName(item?.name);
										setValue("location", undefined);
									}}
									isClearable={true}
								/>
							)}
						/>
					</div>
				</div>
				<div className='h-[134px] w-[134px] items-center mt-8'>
					<ImageUploader multiple={false} initialImages={logoPreview ? [{ 'data_url': logoPreview }] : []} onChange={onPhotoChange} />
				</div>
			</div>

			<div className="mt-8">
				<div className="grid grid-cols-2 gap-4">
					<div className="mb-4">
						<label className="block text-gray-700">Адрес:</label>
						<Controller
							name="location"
							control={control}
							render={({
								field: { onChange, value },
								fieldState: { invalid, isTouched, isDirty, error },
								formState,
							}) => (
								<AddressSuggestions
									token={process.env.REACT_APP_DADATA_API_KEY!}
									value={value}
									filterLocations={[{ "region": selectedRegionName }]}
									onChange={onChange}
									selectOnBlur={true}
									inputProps={{
										disabled: !watch("subjectId"),
										onChange: (event: any) => {
											if (event.target.value == "") {
												setValue("location", undefined)
											}
										},
									}}
									httpCache={false}
								/>
							)}
						/>


					</div>
					<div className="mb-4">
						<label className="block text-gray-700">Email:</label>
						<TextInput type="email" {...register("email")} />
					</div>
				</div>
				<div className="mb-4">
					<label className="block text-gray-700">Ссылка на сайт:</label>
					<TextInput {...register("link")} />
				</div>
				{renderOwnerField()}
				{renderStatusSelect()}
				<div className="mb-4">
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
						}) => (
							<Editor value={value} onChange={onChange} />
						)}
					/>
					<p className='text-red-500'>{errors?.description?.message}</p>
				</div>
			</div>
			<div className='flex justify-center'>
				<Button type="submit">Сохранить</Button>
			</div>

		</form>
	)
}

export default SaveTourAgencyForm