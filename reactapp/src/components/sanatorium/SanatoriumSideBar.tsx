import React, { useEffect, useState } from 'react'
import { FaAddressBook, FaEarthEurope, FaHouse, FaHotTubPerson, FaCalendarDays, FaBuilding, FaBath    } from 'react-icons/fa6'
import { Menu, MenuItem, Sidebar, SubMenu, sidebarClasses } from 'react-pro-sidebar'
import { NavLink } from 'react-router-dom'
import useSanatoriumInfo from '../../hooks/useSanatoriumInfo'
import { useAuth } from '../../context/AuthContext'

const SanatoriumSideBar = () => {
    const { tabsDisabled } = useSanatoriumInfo();

    const sideBarStyles = {
        [`.${sidebarClasses.container}`]: {
            backgroundColor: 'white',
            color: '#0e7490',
        },
    }

    const hoverButtonStyle = {
        backgroundColor: '#0e7490',
        color: 'white',
    }

    const activeButtonStyle = {
        backgroundColor: '#164e63',
        color: 'white',
    }

    return (
        <div className="flex">
            <Sidebar rootStyles={sideBarStyles}>
                <Menu menuItemStyles={{
                    button:{
                            ['&:hover']: hoverButtonStyle,
                            [`&.active`]: activeButtonStyle
                    },
                }}
                >
                    <MenuItem
                        icon={<FaHouse />}
                        component={<NavLink to="/my-sanatorium/profile" />}
                    >
                        Профиль
                    </MenuItem>
                    <MenuItem
                        icon={<FaCalendarDays />}
                        component={<NavLink to="/my-sanatorium/reservations" />}
                        disabled={tabsDisabled}
                    >
                        Бронирования
                    </MenuItem>
                    <MenuItem
                        icon={<FaHotTubPerson />}
                        component={<NavLink to="/my-sanatorium/food" />}
                        disabled={tabsDisabled}
                    >
                        Питание
                    </MenuItem>
                    <MenuItem
                        icon={<FaHotTubPerson />}
                        component={<NavLink to="/my-sanatorium/comfort" />}
                        disabled={tabsDisabled}
                    >
                        Комфорт
                    </MenuItem>
                    <MenuItem
                        icon={<FaBath />}
                        component={<NavLink to="/my-sanatorium/service" />}
                        disabled={tabsDisabled}
                    >
                        Услуги
                    </MenuItem>
                    <MenuItem
                        icon={<FaEarthEurope />}
                        component={<NavLink to="/my-sanatorium/places" />}
                        disabled={tabsDisabled}
                    >
                        Рядом
                    </MenuItem>
                    <SubMenu label="Номера" icon={<FaBuilding />} disabled={tabsDisabled}>
                        <MenuItem
                            component={<NavLink to="/my-sanatorium/rooms" />}
                        >
                            Номера
                        </MenuItem>
                        <MenuItem component={<NavLink to="/my-sanatorium/houses" />}
                        > 
                            Отдельное жилье
                        </MenuItem>
                    </SubMenu>
                    
                    <MenuItem
                        icon={<FaAddressBook />}
                        component={<NavLink to="/my-sanatorium/contacts" />}
                        disabled={tabsDisabled}
                    >
                        Контакты
                    </MenuItem>
                    <MenuItem
                        icon={<FaAddressBook />}
                        component={<NavLink to="/my-sanatorium/promo" />}
                        disabled={tabsDisabled}
                    >
                        Продвижение
                    </MenuItem>
                    <MenuItem
                        icon={<FaAddressBook />}
                        component={<NavLink to="/my-sanatorium/description" />}
                        disabled={tabsDisabled}
                    >
                        Описание
                    </MenuItem>
                </Menu>
            </Sidebar>
        </div>
    )
}

export default SanatoriumSideBar