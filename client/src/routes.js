import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import Pokemon from './pages/Pokemon';
import Login from './pages/Login';

export default function Routes() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Login} />
                <Route path="/pokemons" component={Pokemon} />
            </Switch>
        </BrowserRouter>
    );
}
