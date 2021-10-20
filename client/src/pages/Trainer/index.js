import React, { useState, useEffect } from 'react';
import { FiArrowLeft, FiPower, FiEdit, FiTrash2, FiLogOut } from 'react-icons/fi'
import { Link, useHistory } from 'react-router-dom';

import api from '../../services/api';

import './styles.css';

import logoImage from '../../assets/pokedexLogo.png';
import trainerPngJson from '../../json/TrainerSprites.json'

export default function Trainer() {

    const [trainerSpriteUrl, setTrainerSpriteUrl] = useState('');

    const [trainerId, setTrainerId] = useState(null);
    const [trainerName, setTrainerName] = useState('');
    const [trainerRegion, setTrainerRegion] = useState('');
    const [trainerAge, setTrainerAge] = useState(0);

    const [pokemons, setPokemons] = useState([]);

    const userId = localStorage.getItem('userLoggedId');
    const accessToken = localStorage.getItem('accessToken');

    const history = useHistory();

    const authorization = {
        headers: {
            Authorization: `Bearer ${accessToken}`
        }
    };

    useEffect(() => {
        fetchTrainerWithPokemons();
        setTrainerSpriteUrl(trainerPngJson[Math.floor(Math.random() * trainerPngJson.length)].sprite_url);
    }, [accessToken]);

    async function fetchTrainerWithPokemons() {
        const response = await api.get(`api/trainer/completeTrainerByUserId/${userId}`, authorization);

        setTrainerId(response.data.id);
        setTrainerName(response.data.name);
        setTrainerRegion(response.data.region);
        setTrainerAge(response.data.age);
        setPokemons([...pokemons, ...response.data.pokemons]);
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

    async function deletePokemon(id) {
        try {
            await api.delete(`api/trainer/removePokemonFromPokedex/${trainerId}?pokemonId=${id}`, authorization)

            setPokemons(pokemons.filter(pokemon => pokemon.id !== id))
        } catch (error) {
            alert('Error deleting Pokemon! Try Again!')
        }
    }

    function capitalize(str) {
        return str.charAt(0).toUpperCase() + str.slice(1);
    }

    return (
        <div className="book-container">
            <header>
                <img src="https://archives.bulbagarden.net/media/upload/3/3a/Spr_B2W2_Ace_Trainer_M.png" alt="trainerPng" />
                <span>Welcome, <strong>{capitalize(trainerName)}</strong>!</span>
                <span>Region: <strong>{capitalize(trainerRegion)}</strong></span>
                <span>Age: <strong>{trainerAge}</strong></span>
                <Link className="back-link" to="/selector">
                    <FiArrowLeft size={16} color="#251fc5" />
                    Back to Selector
                </Link>
                <button onClick={logout} type="button">
                    <FiLogOut size={18} color="#251FC5" />
                </button>
            </header>

            <div>
                <h1>{capitalize(trainerName)} Pokedex</h1>
                <a className="button" href={'/capturePokemon/' + trainerId}>Capture a Pokemon</a>
            </div>


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
