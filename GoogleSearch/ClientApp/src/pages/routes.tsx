import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import Home from './Home/index';

export default function Subroutes() {


	return (
		<BrowserRouter>
			<Switch>
				<Route path='/' component={() => Home()} />
			</Switch>

		</BrowserRouter>
	);
};

