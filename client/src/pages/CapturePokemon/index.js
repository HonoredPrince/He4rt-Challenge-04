import React, { useState, useEffect } from 'react';
import { useHistory, useParams } from 'react-router';
import { Link, } from 'react-router-dom';
import { FiArrowLeft } from 'react-icons/fi'

import { FiDisc } from 'react-icons/fi'

import api from '../../services/api';

import './styles.css';

import logoImage from '../../assets/pokedexLogo.png';


export default function AddPokemon() {
    const [pokemons, setPokemons] = useState([]);

    const { trainerId } = useParams();

    const history = useHistory();

    const accessToken = localStorage.getItem('accessToken');

    const authorization = {
        headers: {
            Authorization: `Bearer ${accessToken}`
        }
    };

    useEffect(() => {
        loadPokemons();
    }, [accessToken]);

    async function loadPokemons() {
        const response = await api.get('api/pokemon', authorization);
        setPokemons([...pokemons, ...response.data]);
    }

    async function addPokemon(id, name) {

        const data = {
            id,
            name
        }

        try {
            console.log(data);
            await api.post(`api/trainer/addPokemonToPokedex/${trainerId}`, data, authorization)
        } catch (error) {
            alert('Error while adding Pokemon to this trainer pokedex! Try again!')
        }
        history.push('/trainer');
    }

    function capitalize(str) {
        return str.charAt(0).toUpperCase() + str.slice(1);
    }

    return (
        <div className="book-container">
            <div className="content">
                <section className="form">
                    <img src={logoImage} alt="Erudio" />
                    <Link className="back-link" to="/trainer">
                        <FiArrowLeft size={16} color="#251fc5" />
                        Back to Trainer
                    </Link>
                    <h1>Capture One Pokemon!</h1>
                    <p>These are the pokemons avaliable to pick to your pokedex.</p>
                </section>

                <h1>Registered Pokemons</h1>

                <ul>
                    {pokemons.map(pokemon => (
                        <li key={pokemon.id}>
                            <strong>{capitalize(pokemon.name)}</strong>
                            <img src={pokemon.imageUrl} alt="new" />
                            <button onClick={() => addPokemon(pokemon.id, pokemon.name)} type="button">
                                <FiDisc size={20} color="#251FC5" />
                            </button>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
}
