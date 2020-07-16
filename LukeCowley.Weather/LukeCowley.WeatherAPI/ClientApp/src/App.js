import React, { Component } from 'react';
import { Route } from 'react-router';
import { Provider } from 'react-redux';
import { Home } from './components/Home';
import { store } from './store';
import { updateMarsWeather } from './actions/creators/mars-weather-action-creators'

import './custom.css'

export default class App extends Component {
  static displayName = App.name;
  async componentDidMount() {
    const response = await fetch('https://localhost:44315/api/v1/marsweather/lastweek');
    const data = await response.json(); 
    store.dispatch(updateMarsWeather(data));
  }
  
  render () {
    return (
      <Provider store={store}>
          <Route exact path='/' component={Home} />
      </Provider>
    );
  }
}
