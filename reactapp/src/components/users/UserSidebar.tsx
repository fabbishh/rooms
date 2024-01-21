import React from 'react'
import { FaAddressBook, FaBuilding, FaEarthEurope, FaHouse } from 'react-icons/fa6'
import { Menu, MenuItem, Sidebar, SubMenu, sidebarClasses } from 'react-pro-sidebar'
import { NavLink } from 'react-router-dom'

type Props = {}

const UserSideBar = (props: Props) => {
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
                        component={<NavLink to="/account/settings" />}
                    >
                        Профиль
                    </MenuItem>
                    <MenuItem
                        icon={<FaHouse />}
                        component={<NavLink to="/account/reservations" />}
                    >
                        Мои бронирования
                    </MenuItem>
                    <MenuItem
                        icon={<FaHouse />}
                        component={<NavLink to="/account/favourite" />}
                    >
                        Мои избранные санатории
                    </MenuItem>
                </Menu>
            </Sidebar>
        </div>
    )
    }

export default UserSideBar