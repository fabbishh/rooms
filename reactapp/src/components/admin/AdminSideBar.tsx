import React from 'react'
import { FaAddressBook, FaBuilding, FaEarthEurope, FaHouse } from 'react-icons/fa6'
import { Menu, MenuItem, Sidebar, SubMenu, sidebarClasses } from 'react-pro-sidebar'
import { NavLink } from 'react-router-dom'

type Props = {}

const AdminSideBar = (props: Props) => {
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
                    button: {
                        ['&:hover']: hoverButtonStyle,
                        [`&.active`]: activeButtonStyle
                    },
                }}
                >
                    <MenuItem
                        icon={<FaHouse />}
                        component={<NavLink to="/admin/sanatoriums" />}
                    >
                        Санатории
                    </MenuItem>
                    <SubMenu label="Номера" icon={<FaBuilding />}>
                        <MenuItem
                            component={<NavLink to="/admin/rooms" />}
                        >
                            Номера
                        </MenuItem>
                        <MenuItem component={<NavLink to="/admin/houses" />}
                        >
                            Отдельное жилье
                        </MenuItem>
                    </SubMenu>
                    <MenuItem
                        icon={<FaEarthEurope />}
                        component={<NavLink to="/admin/tour-agencies" />}
                    >
                        Турагенства
                    </MenuItem>
                    <MenuItem
                        icon={<FaEarthEurope />}
                        component={<NavLink to="/admin/tours" />}
                    >
                        Туры
                    </MenuItem>
                    <SubMenu label="Питание" icon={<FaEarthEurope />}>
                        <MenuItem component={<NavLink to="/admin/sanatorium-food" />}> В Санатории </MenuItem>
                        <MenuItem component={<NavLink to="/admin/room-food" />}> В Жилье </MenuItem>
                    </SubMenu>
                    <MenuItem icon={<FaEarthEurope />} component={<NavLink to="/admin/room-bathroom" />}>
                        Санузел
                    </MenuItem>
                    <SubMenu label="Комфорт" icon={<FaEarthEurope />}>
                        <MenuItem component={<NavLink to="/admin/sanatorium-comfort" />}
                        >
                            В Санатории
                        </MenuItem>
                        <MenuItem component={<NavLink to="/admin/room-comfort" />}
                        >
                            В Жилье
                        </MenuItem>
                    </SubMenu>
                    <MenuItem
                        icon={<FaEarthEurope />}
                        component={<NavLink to="/admin/services" />}
                    >
                        Услуги
                    </MenuItem>
                    <MenuItem
                        icon={<FaEarthEurope />}
                        component={<NavLink to="/admin/regions" />}
                    >
                        Регионы
                    </MenuItem>
                    <MenuItem
                        icon={<FaEarthEurope />}
                        component={<NavLink to="/admin/places" />}
                    >
                        Места
                    </MenuItem>
                    <MenuItem
                        icon={<FaEarthEurope />}
                        component={<NavLink to="/admin/users" />}
                    >
                        Пользователи
                    </MenuItem>
                    <SubMenu label="Отзывы" icon={<FaEarthEurope />}>
                        <MenuItem component={<NavLink to="/admin/sanatoriums-reviews" />}
                        >
                            Санатории
                        </MenuItem>
                        <MenuItem component={<NavLink to="/admin/tours-reviews" />}
                        >
                            Туры
                        </MenuItem>
                    </SubMenu>
                </Menu>
            </Sidebar>
        </div>
    )
}

export default AdminSideBar