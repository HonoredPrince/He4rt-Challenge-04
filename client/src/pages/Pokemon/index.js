import React, { useState, useEffect } from 'react';
import { FiArrowLeft, FiTrash2, FiLogOut } from 'react-icons/fi'
import { Link, useHistory } from 'react-router-dom';

import api from '../../services/api';

import './styles.css';

import logoImage from '../../assets/pokedexLogo.png';

export default function Pokemon() {

    const [pokemons, setPokemons] = useState([]);

    const userEmail = localStorage.getItem('userEmail');
    const accessToken = localStorage.getItem('accessToken');

    const history = useHistory();

    const authorization = {
        headers: {
            Authorization: `Bearer ${accessToken}`
        }
    };

    useEffect(() => {
        fetchPokemons();
    }, [accessToken]);

    async function fetchPokemons() {
        const response = await api.get('api/pokemon', authorization);
        setPokemons([...pokemons, ...response.data]);
    }

    async function logout() {
        try {
            await api.get('api/login/revoke', authorization);

            localStorage.clear();
            history.push('/')
        } catch (error) {
            alert('Logout failed! Try Again!')
        }
    }

    function capitalize(str) {
        return str.charAt(0).toUpperCase() + str.slice(1);
    }

    async function deletePokemon(id) {
        try {
            await api.delete(`api/pokemon/${id}`, authorization)

            setPokemons(pokemons.filter(pokemon => pokemon.id !== id))
        } catch (error) {
            alert('Error deleting Pokemon! Try Again!')
        }
    }

    return (
        <div className="pokemons-container">
            <header>
                <img src={logoImage} alt="pokedexLogo" />
                <span>Welcome, <strong>{userEmail.toLowerCase()}</strong>!</span>
                <Link className="button" to="/addPokemon">Add New Pokemon</Link>
                <Link className="back-link" to="/selector">
                    <FiArrowLeft size={16} color="#251fc5" />
                    Back to Selector
                </Link>
                <button onClick={logout} type="button">
                    <FiLogOut size={18} color="#251FC5" />
                </button>
            </header>

            <h1>Registered Pokemons</h1>

            <ul>
                {pokemons.map(pokemon => (
                    <li key={pokemon.id}>
                        <strong>Name:</strong>
                        <p>{capitalize(pokemon.name)}</p>
                        <strong>Main Attribute:</strong>
                        <p>{capitalize(pokemon.attribute)}</p>
                        <strong>Image:</strong>
                        <img src={pokemon.imageUrl} alt="new" />
                        <strong>Date of Registration:</strong>
                        <p>{Intl.DateTimeFormat('pt-BR').format(new Date(pokemon.createdAt))}</p>

                        <button onClick={() => deletePokemon(pokemon.id)} type="button">
                            <FiTrash2 size={20} color="#251FC5" />
                        </button>
                    </li>
                ))}
            </ul>
        </div>
    );
}
