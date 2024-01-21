// AppRouter.tsx
import React from 'react';
import { BrowserRouter as Router, Route, Routes, useLocation } from 'react-router-dom';
import SanatoriumsPage from '../pages/SanatoriumsPage';
import RoomDetailsPage from '../pages/RoomDetailsPage';
import SanatoriumDetailsPage from '../pages/SanatoriumDetailsPage';
import ToursPage from '../pages/ToursPage';
import RegisterPage from '../pages/RegisterPage';
import LoginPage from '../pages/LoginPage';
import Protected from './Protected';
import NavigationMenu from './ui/NavigationMenu';
import TourAgencyProfileTab from './tourAgency/TourAgencyProfileTab';
import SidebarLayout from '../layouts/SidebarLayout';
import TourAgencyContactsTab from './tourAgency/TourAgencyContactsTab';
import TourAgencyToursTab from './tourAgency/TourAgencyToursTab';
import Footer from './ui/Footer';
import TourAgencySideBar from './tourAgency/TourAgencySideBar';
import SanatoriumSideBar from './sanatorium/SanatoriumSideBar';
import SanatoriumProfileTab from './sanatorium/sanatoriumProfile/SanatoriumProfileTab';
import SanatoriumComfortTab from './sanatorium/sanatoriumProfile/SanatoriumComfortTab';
import SanatoriumServiceTab from './sanatorium/sanatoriumProfile/SanatoriumServiceTab';
import SanatoriumPlacesTab from './sanatorium/sanatoriumProfile/SanatoriumPlacesTab';
import SanatoriumRoomsTab from './sanatorium/sanatoriumProfile/SanatoriumRoomsTab';
import SanatoriumContactsTab from './sanatorium/sanatoriumProfile/SanatoriumContactsTab';
import { useAuth } from '../context/AuthContext';
import AdminSideBar from './admin/AdminSideBar';
import AdminSanatoriumsTab from './admin/Sanatorium/AdminSanatoriumsTab';
import TourAgenciesTab from './admin/TourAgency/TourAgenciesTab';
import SanatoriumsComfortTab from './admin/Comfort/SanatoriumsComfortTab';
import RoomComfortTab from './admin/Comfort/RoomComfortTab';
import ServicesTab from './admin/ServicesTab';
import RoomReservePage from '../pages/RoomReservePage';
import SanatoriumReservationsTab from './sanatorium/sanatoriumProfile/SanatoriumReservationsTab';
import RegionsTab from './admin/RegionsTab';
import AdminToursTab from './admin/Tours/AdminToursTab';
import AdminUsersTab from './admin/users/AdminUsersTab';
import TourDetails from './tour/TourDetails';
import AdminRoomsTab from './admin/Room/AdminRoomsTab';
import SanatoriumPromoTab from './sanatorium/sanatoriumProfile/SanatoriumPromoTab';
import SanatoriumsReviewsTab from './admin/Review/SanatoriumsReviewsTab';
import ToursReviewsTab from './admin/Review/ToursReviewsTab';
import SanatoriumHousesTab from './sanatorium/sanatoriumProfile/SanatoriumHousesTab';
import AdminHousesTab from './admin/Room/AdminHousesTab';
import UserSideBar from './users/UserSidebar';
import UserProfileTab from './users/UserProfileTab';
import UserReservationsTab from './users/UserReservationsTab';
import UserFavouriteTab from './users/UserFavouriteTab';
import AdminPlacesTab from './admin/Places/AdminPlacesTab';
import TourAgencyPromoTab from './tourAgency/TourAgencyPromoTab';
import AdminFoodForSanatoriumTab from './admin/Food/AdminFoodForSanatoriumTab';
import AdminFoodForRoomTab from './admin/Food/AdminFoodForRoomTab';
import AdminRoomBathroom from './admin/Bathroom/AdminRoomBathroom';
import SanatoriumFoodTab from './sanatorium/sanatoriumProfile/SanatoriumFoodTab';
import SanatoriumDescriptionTab from './sanatorium/sanatoriumProfile/SanatoriumDescriptionTab';

const AppRouter: React.FC = () => {
	return (
		<Router>
			<NavigationMenu />
			<Routes>
				<Route path="/" element={<SanatoriumsPage />} />
				<Route path="/sanatoriums/:sanatoriumId" element={<SanatoriumDetailsPage />} />
				<Route path="/room/:roomId" element={<RoomDetailsPage />} />
				<Route path="/room/reserve/:roomId" element={<RoomReservePage />} />
				<Route path="/tours" element={<ToursPage />} />
				<Route path="/tours/:tourId" element={<TourDetails />} />
				<Route element={<Protected redirectPath='/' />}>
					<Route element={<SidebarLayout children={<UserSideBar />} />}>
						<Route path="/account/settings" element={<UserProfileTab />} />
						<Route path="/account/reservations" element={<UserReservationsTab />} />
						<Route path="/account/favourite" element={<UserFavouriteTab />} />
					</Route>
					<Route element={<SidebarLayout children={<TourAgencySideBar />} />}>
						<Route path="/my-tour-agency/profile" element={<TourAgencyProfileTab />} />
						<Route path="/my-tour-agency/contacts" element={<TourAgencyContactsTab />} />
						<Route path="/my-tour-agency/tours" element={<TourAgencyToursTab />} />
						<Route path="/my-tour-agency/promo" element={<TourAgencyPromoTab />} />
					</Route>
					<Route element={<SidebarLayout children={<SanatoriumSideBar />} />}>
						<Route path="/my-sanatorium/profile" element={<SanatoriumProfileTab />} />
						<Route path="/my-sanatorium/reservations" element={<SanatoriumReservationsTab />} />
						<Route path="/my-sanatorium/comfort" element={<SanatoriumComfortTab />} />
						<Route path="/my-sanatorium/service" element={<SanatoriumServiceTab />} />
						<Route path="/my-sanatorium/places" element={<SanatoriumPlacesTab />} />
						<Route path="/my-sanatorium/rooms" element={<SanatoriumRoomsTab />} />
						<Route path="/my-sanatorium/houses" element={<SanatoriumHousesTab />} />
						<Route path="/my-sanatorium/contacts" element={<SanatoriumContactsTab />} />
						<Route path="/my-sanatorium/promo" element={<SanatoriumPromoTab />} />
						<Route path="/my-sanatorium/food" element={<SanatoriumFoodTab />} />
						<Route path="/my-sanatorium/description" element={<SanatoriumDescriptionTab />} />
					</Route>
					<Route element={<SidebarLayout children={<AdminSideBar />} />}>
						<Route path="/admin/sanatoriums" element={<AdminSanatoriumsTab />} />
						<Route path="/admin/tour-agencies" element={<TourAgenciesTab />} />
						<Route path="/admin/sanatorium-comfort" element={<SanatoriumsComfortTab />} />
						<Route path="/admin/room-comfort" element={<RoomComfortTab />} />
						<Route path="/admin/services" element={<ServicesTab />} />
						<Route path="/admin/regions" element={<RegionsTab />} />
						<Route path="/admin/tours" element={<AdminToursTab />} />
						<Route path="/admin/users" element={<AdminUsersTab />} />
						<Route path="/admin/rooms" element={<AdminRoomsTab />} />
						<Route path="/admin/houses" element={<AdminHousesTab />} />
						<Route path="/admin/sanatoriums-reviews" element={<SanatoriumsReviewsTab />} />
						<Route path="/admin/tours-reviews" element={<ToursReviewsTab />} />
						<Route path="/admin/places" element={<AdminPlacesTab />} />
						<Route path="/admin/sanatorium-food" element={<AdminFoodForSanatoriumTab/>} />
						<Route path="/admin/room-food" element={<AdminFoodForRoomTab />} />
						<Route path="/admin/room-bathroom" element={<AdminRoomBathroom />} />
					</Route>
				</Route>
				<Route path="/register" element={<RegisterPage />} />
				<Route path="/login" element={<LoginPage />} />
			</Routes>
			<Footer />
		</Router>
	);
};

export default AppRouter;
