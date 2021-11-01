import React, { useState } from 'react';
import { useHistory } from 'react-router';
import { Link, } from 'react-router-dom';
import { FiArrowLeft } from 'react-icons/fi'

import api from '../../services/api';

import './styles.css';

import logoImage from '../../assets/pokedexLogo.png';


export default function AddPokemon() {
    const [name, setPokemonName] = useState('');

    const history = useHistory();

    const accessToken = localStorage.getItem('accessToken');

    const authorization = {
        headers: {
            Authorization: `Bearer ${accessToken}`
        }
    };

    async function addPokemon(e) {
        e.preventDefault();

        const data = {
            name
        }

        try {
            await api.post(`api/pokemon`, data, authorization)
        } catch (error) {
            alert('Error while recording Pokemon! Try again!')
        }
        history.push('/pokemons');
    }

    return (
        <div className="add-pokemon-container">
            <div className="content">
                <section className="form">
                    <img src={logoImage} alt="pokedexLogo" />
                    <h1>Add A New Pokemon</h1>
                    <p>Enter the pokemon name to add from PokeApi</p>
                    <Link className="back-link" to="/pokemons">
                        <FiArrowLeft size={16} color="#251fc5" />
                        Back to Pokemons
                    </Link>
                </section>

                <form onSubmit={addPokemon}>
                    <input
                        placeholder="Pokemon Name"
                        value={name}
                        onChange={e => setPokemonName(e.target.value)}
                    />
                    <button className="button" type="submit">Add</button>
                </form>
            </div>
        </div>
    );
}
