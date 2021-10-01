import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';

import api from '../../services/api';

import './styles.css';

import logoImage from '../../assets/pixelmonLogo.png'

export default function Login() {

    const [email, setUserEmail] = useState('');
    const [password, setPassword] = useState('');

    const history = useHistory();

    async function login(e) {
        e.preventDefault();

        const data = {
            email,
            password,
        };

        try {
            const response = await api.post('api/login/signin', data);

            localStorage.setItem('userEmail', email);
            localStorage.setItem('accessToken', response.data.accessToken);
            localStorage.setItem('refreshToken', response.data.refreshToken);

            history.push('/pokemons');
        } catch (error) {
            alert('Login failed! Try again!');
        }

    }

    return (
        <div className="login-container">
            <section className="form">
                <img src={logoImage} alt="Erudio Logo" />
                <form onSubmit={login}>
                    <h1>Access your Account</h1>

                    <input
                        placeholder="Email"
                        value={email}
                        onChange={e => setUserEmail(e.target.value)}
                    />

                    <input
                        type="password"
                        placeholder="Password"
                        value={password}
                        onChange={e => setPassword(e.target.value)}
                    />

                    <button className="button" type="submit">Login</button>
                </form>

            </section>
        </div>
    )
}
