// SanatoriumProfileTab.tsx
import useSanatoriumInfo from '../../../hooks/useSanatoriumInfo';
import SaveSanatoriumForm from '../forms/SaveSanatoriumForm';


const SanatoriumProfileTab = () => {
	const { sanatoriumInfo, toggleFetch, setToggleFetch } = useSanatoriumInfo();

	return (
		<div className='mx-24'>
			<h2 className="text-2xl font-bold mb-4">Профиль санатория</h2>
			<SaveSanatoriumForm sanatoriumId={sanatoriumInfo.id} role="sanatoriumAdmin" onSave={() => setToggleFetch(!toggleFetch)}/>
		</div>
	);
};

export default SanatoriumProfileTab;
