import React, { useState } from 'react';
import { login, validateConfirmationCode } from '../services/api/auth';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import Input from 'react-phone-number-input/input';
import { Button, Label, TextInput } from 'flowbite-react';
import { getDecodedToken } from '../utils/jwtUtils';
import api from '../services/api/api';
import Cookies from 'js-cookie';
import { showNotification } from '../utils/notificationManager';
import { SmartCaptcha } from '@yandex/smart-captcha';



const LoginPage = () => {
    const [email, setEmail] = useState<string>();
    const [smsCode, setSmsCode] = useState('');
    const [showSmsInput, setShowSmsInput] = useState(false);
    const navigate = useNavigate();
    const { setAuthenticated, setUser } = useAuth();

    const handleLogin = async () => {
        await login(email!);
        setShowSmsInput(true);
    };

    const handleSmsVerification = async () => {
        try {
            const response = await api.post(`/auth/validateCode`, {
                email: email,
                code: smsCode,
                shouldUpdateConfirm: true
            });

            Cookies.set("accessToken", response.data.accessToken);
            Cookies.set("refreshToken", response.data.refreshToken);

            const token = getDecodedToken();
            if (token) {
                setUser({
                    id: token.nameid,
                    role: token.role,
                    email: token.email,
                    phone: token.phone
                });
                setAuthenticated(true);
            }
            navigate("/");

        } catch (error: any) {
            console.log(error)
            setSmsCode('');
        } 
    };

    return (
        <div className="min-h-screen flex items-center justify-center">
            <div className="max-w-md w-full p-8 bg-white rounded-md shadow-md space-y-4">
                <div >
                    <div className="mb-2 block">
                        <Label htmlFor="Email" value="Email" />
                    </div>
                    <TextInput type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
                </div>

                {!showSmsInput ? (
                    <div className='flex justify-center'>
                        <Button
                            onClick={handleLogin}
                        >
                            Войти
                        </Button>
                    </div>
                ) : (
                    <div className="space-y-6">
                        <div>
                            <div className="mb-2 block">
                                <Label htmlFor="smsCode" value="Проверочный код" />
                            </div>
                            <TextInput
                                type="text"
                                value={smsCode}
                                onChange={(e) => setSmsCode(e.target.value)}
                            />
                        </div>
                        <div className='flex justify-center'>
                            <Button
                                onClick={handleSmsVerification}
                            >
                                Подтвердить
                            </Button>
                        </div>

                    </div>
                )}
            </div>
        </div>
    );
};

export default LoginPage;
