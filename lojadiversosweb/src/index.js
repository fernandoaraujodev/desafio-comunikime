import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';

import reportWebVitals from './reportWebVitals';

import { BrowserRouter as Router, Route, Switch, Redirect } from 'react-router-dom';

// react bootstrap
import 'bootstrap/dist/css/bootstrap.min.css';

// pages
import Dashboard from './pages/dashboard';
import Store from './pages/store';

import {ToastProvider} from 'react-toast-notifications'

// define as rotas do react-router
const routes = (
  <Router>
    <Switch>
      <Route path='/dashboard'  component={Dashboard} />
      <Route path='/store' component={Store} />
      <Route>
        <Redirect to="/store" />
      </Route>
    </Switch>
  </Router>
)

ReactDOM.render(
  <React.StrictMode>
    <ToastProvider>
    {routes}
    </ToastProvider>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
