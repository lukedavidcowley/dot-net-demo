import React from 'react'

export const SolPanel = (props) => { 
    const data = props.solData;
    if(data === undefined) return;

    console.log("profile", data.startDate);//Object.keys(data));
    return (
        <div className="panel panel-default">
            <div className="panel-body">
                <div># {data.number || "no data"}</div>
                <div>Starts: {data.startDate || "no data"}</div>
                <div>Ends: {data.endDate || "no data"}</div>
                <div>Temperature: {data.weatherProfile.temperature.average || "no data"}</div>
                <div>Pressure: {data.weatherProfile.pressure.average || "no data"}</div>
                <div>Wind Speed: {data.weatherProfile.windSpeed.average || "no data"}</div>
                <div>Wind Direction{data.weatherProfile.windDirection || "no data"}</div>
            </div>
        </div>
)}