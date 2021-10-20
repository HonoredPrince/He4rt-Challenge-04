import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';

import api from '../../services/api';

import './styles.css';

import logoImage from '../../assets/pixelmonLogo.png'

export default function Register() {

    const [email, setUserEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmationPassword, setConfirmationPassword] = useState('');

    const history = useHistory();

    async function registration(e) {
        e.preventDefault();

        const data = {
            email,
            password,
        };

        //const { password, confirmationPassword } = this.state;

        if (password !== confirmationPassword) {
            alert("Passwords don't match")
        } else {
            try {
                await api.post('api/user', data);

                history.push('/');
            } catch (error) {
                alert('Registration failed during API call! Try again!');
            }
        }
    }

    return (
        <div className="login-container">
            <section className="form">
                <img src={logoImage} alt="Erudio Logo" />
                <form onSubmit={registration}>
                    <h1>Make your Account</h1>

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

                    <input
                        type="password"
                        placeholder="Confirm Password"
                        value={confirmationPassword}
                        onChange={e => setConfirmationPassword(e.target.value)}
                    />

                    <button className="button" type="submit">Register</button>
                </form>

            </section>
        </div>
    )
}
