import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import Pokemon from './pages/Pokemon';
import Login from './pages/Login';
import RegisterUser from './pages/RegisterUser';
import RegisterTrainer from './pages/RegisterTrainer'
import Trainer from './pages/Trainer';
import AddPokemon from './pages/AddPokemon';
import CapturePokemon from './pages/CapturePokemon';
import Selector from './pages/Selector';

export default function Routes() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Login} />
                <Route path="/pokemons" component={Pokemon} />
                <Route path="/addPokemon" component={AddPokemon} />
                <Route path="/registerUser" component={RegisterUser} />
                <Route path="/registerTrainer" component={RegisterTrainer} />
                <Route path="/trainer" component={Trainer} />
                <Route path="/capturePokemon/:trainerId" component={CapturePokemon} />
                <Route path="/selector" component={Selector} />
            </Switch>
        </BrowserRouter>
    );
}
