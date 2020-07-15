const initState = {
    weather: {
        mars: [{}]
    }
};

export const marsWeather = (state, action) => {
    if(typeof state == 'undefined') return initState;

    return {
        ...state,
        weather: {
            mars: action.data
        }
    }
}

