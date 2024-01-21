import React, { useEffect, useState } from 'react'
import { Sidebar, Menu, MenuItem, SubMenu, menuClasses, sidebarClasses } from 'react-pro-sidebar';
import { NavLink } from 'react-router-dom';
import { FaHouse, FaAddressBook, FaEarthEurope } from 'react-icons/fa6';
import useTourAgencyInfo from '../../hooks/useTourAgencyInfo';

type Props = {}

const TourAgencySideBar = (props: Props) => {
    const tourAgencyInfo = useTourAgencyInfo();
    const [tabsDisabled, setTabsDisabled] = useState(true);

    useEffect(() => {
        if(tourAgencyInfo?.id) {
            setTabsDisabled(false)
        } else {
            setTabsDisabled(true);
        }
    }, [tourAgencyInfo])

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
                        component={<NavLink to="/my-tour-agency/profile" />}
                    >
                        Профиль
                    </MenuItem>
                    <MenuItem
                        icon={<FaAddressBook />}
                        component={<NavLink to="/my-tour-agency/contacts" />}
                        disabled={tabsDisabled}
                    >
                        Контакты
                    </MenuItem>
                    <MenuItem
                        icon={<FaEarthEurope />}
                        component={<NavLink to="/my-tour-agency/tours" />}
                        disabled={tabsDisabled}
                    >
                        Туры
                    </MenuItem>
                    <MenuItem
                        icon={<FaEarthEurope />}
                        component={<NavLink to="/my-tour-agency/promo" />}
                        disabled={tabsDisabled}
                    >
                        Продвижение
                    </MenuItem>
                </Menu>
            </Sidebar>
        </div>
    )
}

export default TourAgencySideBar