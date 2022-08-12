import React from 'react';
import ReactDOM from 'react-dom';
import "./index.css";
import { BrowserRouter } from 'react-router-dom';
import Routes from './pages/routes';

const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter>
    <Routes />
  </BrowserRouter>,
  rootElement);


