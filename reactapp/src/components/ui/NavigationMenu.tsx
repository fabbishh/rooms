// NavigationMenu.tsx
import React, { useState } from 'react';
import { NavLink } from "react-router-dom";
import { useAuth } from '../../context/AuthContext';
import { logout } from '../../services/api/auth';
import { Avatar, Button, CustomFlowbiteTheme, Dropdown, Flowbite, Navbar } from 'flowbite-react';
import AppNavLink from './AppNavLink';
import { FaAngleDown } from 'react-icons/fa6';
import RegionSelector from '../region/RegionSelector';
import { useRegion } from '../../context/RegionContext';

// const customTheme: CustomFlowbiteTheme = {
// 	navbar: {
// 		root: {
// 			base: "bg-white px-2 py-2.5 dark:border-gray-700 dark:bg-gray-800 sm:px-4",
// 			rounded: {
// 				on: "rounded",
// 				off: ""
// 			},
// 			bordered: {
// 				on: "border",
// 				off: ""
// 			},
// 			inner: {
// 				base: "mx-auto flex flex-wrap items-center justify-between",
// 				fluid: {
// 					on: "",
// 					off: "container"
// 				}
// 			}
// 		},
// 		brand: {
// 			base: "flex items-center"
// 		},
// 		collapse: {
// 			base: "w-full md:block md:w-auto",
// 			list: "mt-4 flex flex-col md:mt-0 md:flex-row md:space-x-8 md:text-sm md:font-medium",
// 			hidden: {
// 				on: "hidden",
// 				off: ""
// 			}
// 		},
// 		link: {
// 			base: "block py-2 pr-4 pl-3 md:p-0",
// 			active: {
// 				on: "bg-earth text-white dark:text-white md:bg-transparent md:text-earth",
// 				off: "border-b border-gray-100  text-gray-700 hover:bg-gray-50 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white md:border-0 md:hover:bg-transparent md:hover:text-earth md:dark:hover:bg-transparent md:dark:hover:text-white"
// 			},
// 			disabled: {
// 				on: "text-gray-400 hover:cursor-not-allowed dark:text-gray-600",
// 				off: ""
// 			}
// 		},
// 		toggle: {
// 			base: "inline-flex items-center rounded-lg p-2 text-sm text-gray-500 hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-600 md:hidden",
// 			icon: "h-6 w-6 shrink-0"
// 		}
// 	},
// };

const NavigationMenu: React.FC = () => {

	const { authenticated, user, setAuthenticated } = useAuth();

	const handleLogout = async () => {
		await logout();
		setAuthenticated(false);
	}

	return (
		//<Flowbite theme={{ theme: customTheme }}>
			<Navbar fluid rounded border>
				<Navbar.Brand href="/">
					<img src="https://logo.com/image-cdn/images/kts928pd/production/438d53780735a1f3ce6549d6909bc19b8eb5f2b0-338x337.png?w=1080&q=72" className="mr-3 h-6 sm:h-9" alt="Flowbite React Logo" />
				</Navbar.Brand>
				<div className="flex md:order-2 gap-8">
					<RegionSelector />
					{authenticated ? <Dropdown
						arrowIcon={false}
						inline
						label={
							<div className='flex items-center gap-1'>{user?.email ? user?.email : user?.phone} <FaAngleDown /></div>
						}
					>
						<Dropdown.Header>
							<span className="block truncate text-sm font-medium">{user?.email ? user?.email : user?.phone}</span>
						</Dropdown.Header>
						{user?.role === "SanatoriumAdmin" &&
							<Dropdown.Item>
								<NavLink
									to="/my-sanatorium/profile"
									className={({ isActive, isPending }) => {
										return isPending ? "" : isActive ? "text-cyan-700" : "";
									}}>
									ЛК Санатория
								</NavLink>
							</Dropdown.Item>}
						{user?.role === "TourAgencyAdmin" &&
							<Dropdown.Item>
								<NavLink
									to="/my-tour-agency/profile"
									className={({ isActive, isPending }) => {
										return isPending ? "" : isActive ? "text-cyan-700" : "";
									}}>
									ЛК Турагенства
								</NavLink>
							</Dropdown.Item>}
						{user?.role === "Admin" &&
							<Dropdown.Item>
								<NavLink
									to="/admin/sanatoriums"
									className={({ isActive, isPending }) => {
										return isPending ? "" : isActive ? "text-cyan-700" : "";
									}}>
									Панель администратора
								</NavLink>
							</Dropdown.Item>}

						{user?.role === "User" &&
							<>
								<Dropdown.Item>
									<NavLink
										to="/account/settings"
										className={({ isActive, isPending }) => {
											return isPending ? "" : isActive ? "text-cyan-700" : "";
										}}>
										Профиль
									</NavLink>
								</Dropdown.Item>
								
								<Dropdown.Item>
									<NavLink
										to="/account/reservations"
										className={({ isActive, isPending }) => {
											return isPending ? "" : isActive ? "text-cyan-700" : "";
										}}>
										Мои бронирования
									</NavLink>
								</Dropdown.Item>
								<Dropdown.Item>
									<NavLink
										to="/account/favourite"
										className={({ isActive, isPending }) => {
											return isPending ? "" : isActive ? "text-cyan-700" : "";
										}}>
										Мои избранные санатории
									</NavLink>
								</Dropdown.Item>
							</>}

						<Dropdown.Divider />
						<Dropdown.Item href='/login' onClick={handleLogout}>
							Выйти
						</Dropdown.Item>
					</Dropdown>
						:
						<NavLink
							to="/login"
							onClick={handleLogout}
							className={({ isActive, isPending }) => {
								return isPending ? "" : isActive ? "text-cyan-700" : "";
							}}>
							Войти
						</NavLink>}
					<Navbar.Toggle />
				</div>
				<Navbar.Collapse>
					<AppNavLink to="/" text="Санатории" />
					<AppNavLink to="/tours" text="Туры" />

				</Navbar.Collapse>
			</Navbar>
		//</Flowbite>
	);
};

export default NavigationMenu;
