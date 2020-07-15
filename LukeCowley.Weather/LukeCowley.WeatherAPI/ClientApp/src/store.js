import { createStore } from 'redux';
import { marsWeather } from './reducers/mars-weather-reducers'

export const store = createStore(marsWeather, window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());