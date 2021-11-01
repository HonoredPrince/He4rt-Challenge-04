import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';

import api from '../../services/api';

import './styles.css';

import logoImage from '../../assets/pixelmonLogo.png'

export default function Register() {

    const [name, setTrainerName] = useState('');
    const [region, setTrainerRegion] = useState('');
    const [age, setTrainerAge] = useState(0);

    const userId = localStorage.getItem('userLoggedId');
    const accessToken = localStorage.getItem('accessToken');

    const authorization = {
        headers: {
            Authorization: `Bearer ${accessToken}`
        }
    };

    const history = useHistory();

    async function registration(e) {
        e.preventDefault();

        const trainerData = {
            name,
            region,
            age,
            userId
        };

        try {
            await api.post('api/trainer', trainerData, authorization);

            history.push('/selector');
        } catch (error) {
            alert('Creation failed during API call! Try again!');
        }
    }

    return (
        <div className="registration-container">
            <section className="form">
                <img src={logoImage} alt="pixelmonLogo" />
                <form onSubmit={registration}>
                    <h1>Create your Trainer!</h1>

                    <input
                        placeholder="Trainer Name"
                        value={name}
                        onChange={e => setTrainerName(e.target.value)}
                    />

                    <input
                        placeholder="Region"
                        value={region}
                        onChange={e => setTrainerRegion(e.target.value)}
                    />

                    <input
                        type="number"
                        placeholder="0"
                        value={age}
                        onChange={e => setTrainerAge(e.target.value)}
                    />
                    <button className="button" type="submit">Create</button>
                </form>
            </section>
        </div>
    )
}
