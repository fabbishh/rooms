import {useLinkClickHandler, useLocation} from "react-router-dom";
import {CustomFlowbiteTheme, Navbar} from "flowbite-react";

export interface AppNavLinkProps {
    to: string;
    text: string;
    onClick?: () => void;
}

export default function AppNavLink(props: AppNavLinkProps) {
    const location = useLocation();
    const clickHandler = useLinkClickHandler(props.to);

    return <span onClick={clickHandler}>
        <Navbar.Link href={props.to} active={location.pathname === props.to} onClick={props.onClick}>
            {props.text}
        </Navbar.Link>
    </span>;
}