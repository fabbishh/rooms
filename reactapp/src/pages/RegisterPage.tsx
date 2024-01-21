import React, { useState } from 'react';
import { register, validateConfirmationCode } from '../services/api/auth';
import { showNotification } from '../utils/notificationManager';
import { useAuth } from '../context/AuthContext';

const RegisterPage = () => {
  const [phoneNumber, setPhoneNumber] = useState('');
  const [consent, setConsent] = useState(false);
  const [smsCode, setSmsCode] = useState('');
  const [showSmsInput, setShowSmsInput] = useState(false);
  const { setAuthenticated } = useAuth();

  const handleRegistration = async () => {
    try {
      const response = await register(phoneNumber);

      if (response.ok) {
        setShowSmsInput(true);
      } else {
        
      }
    } catch (error) {
      // Обработка ошибок запроса
    }
  };

  const handleSmsVerification = async () => {
    try {
      const response = await validateConfirmationCode(phoneNumber, smsCode, true);
      setAuthenticated(true);
    } catch (error: any) {
      showNotification('error', error.message);
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center">
      <div className="max-w-md w-full p-8 bg-white rounded-md shadow-md">
        <label className="block mb-4">
          Номер телефона:
          <input
            type="tel"
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
            className="w-full mt-2 p-2 border border-gray-300 rounded-md"
          />
        </label>
        <label className="block mb-4">
          <input
            type="checkbox"
            checked={consent}
            onChange={() => setConsent(!consent)}
            className="mr-2"
          />
          Нажимая «Зарегистрироваться», вы предоставляете Согласие на обработку персональных данных в соответствии с Политикой в отношении обработки персональных данных.
        </label>
        {!showSmsInput ? (
          <button
            onClick={handleRegistration}
            disabled={!consent}
            className="w-full py-2 px-4 bg-blue-500 text-white rounded-md"
          >
            Зарегистрироваться
          </button>
        ) : (
          <div>
            <label className="block mb-4">
              Код из смс:
              <input
                type="text"
                value={smsCode}
                onChange={(e) => setSmsCode(e.target.value)}
                className="w-full mt-2 p-2 border border-gray-300 rounded-md"
              />
            </label>
            <button
              onClick={handleSmsVerification}
              className="w-full py-2 px-4 bg-blue-500 text-white rounded-md"
            >
              Подтвердить
            </button>
          </div>
        )}
      </div>
    </div>
  );
};

export default RegisterPage;
