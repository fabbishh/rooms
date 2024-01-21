import React, { useEffect, useState } from 'react';
import { useForm, SubmitHandler, Controller } from 'react-hook-form';
import api from '../../services/api/api';
import { showNotification } from '../../utils/notificationManager';
import { AddressSuggestions, DaDataSuggestion, DaDataAddress } from 'react-dadata';
import 'react-dadata/dist/react-dadata.css';
import { Button, FileInput, Label, Select, TextInput, Textarea } from 'flowbite-react';
import { constants } from 'crypto';
import Editor from '../ui/Editor';
import SaveTourAgencyForm from './SaveTourAgencyForm';

const TourAgencyProfileTab: React.FC = () => {
	return (
		<div className='mx-24'>
			<h2 className="text-2xl font-bold mb-4">Профиль Турагенства</h2>
			<SaveTourAgencyForm role="tourAgency"/>
		</div>
	);
};

export default TourAgencyProfileTab;
