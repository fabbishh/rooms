import { createContext, useContext, useEffect, useState, ReactNode } from 'react';
import { showNotification } from '../utils/notificationManager';
import { jwtDecode } from 'jwt-decode';
import Cookies from 'js-cookie';
import { getDecodedToken } from '../utils/jwtUtils';

type AuthProviderProps = {
	children?: ReactNode;
}

type User = {
	id: string;
	role: string;
	email?: string;
	phone?: string;
};

type IAuthContext = {
	authenticated?: boolean;
	setAuthenticated: (newState: boolean) => void;
	user?: User;
	setUser: (user: User) => void;
};

interface JwtPayload {
	nameid: string;
	role: string;
	email?: string;
	phone?: string;
	exp: number;
}

const AuthContext = createContext<IAuthContext>(undefined!);

export const useAuth = () => {
	const context = useContext(AuthContext);
	if (!context) {
		showNotification('error', 'useAuth must be used within an AuthProvider');
	}
	return context;
};

export const AuthProvider = ({ children }: AuthProviderProps) => {
	const [authenticated, setAuthenticated] = useState<boolean>();
	const [user, setUser] = useState<User>();

	useEffect(() => {
		const decodedToken = getDecodedToken();

		if (decodedToken) {
			setAuthenticated(true);
			setUser({
				id: decodedToken.nameid,
				role: decodedToken.role,
				email: decodedToken.email,
				phone: decodedToken.phone
			});
		} else {
			setAuthenticated(false);
		}
	}, []);

	return (
		<AuthContext.Provider value={{ authenticated, setAuthenticated, user, setUser }}>
			{children}
		</AuthContext.Provider>
	);
};