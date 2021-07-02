import "./App.css";
import GetExchangeRates from "./ExchangeRateService";
import React, { useState } from "react";
import { Rate } from "./Rate";

function App() {
  const [rates, setRates] = useState([]);
  const [error, setError] = useState('');

  const fetchRates = () => {
    GetExchangeRates()
      .then((result) => {
        setRates(result);
        setError(null);
      })
      .catch((err) => {
        setError("Error getting rates");
      });
  }

  const renderError = () => {
    if (error) {
      return (<div className='error'>
        <p className='error-text'>{error}</p>
        <p>If the problem persists, please don't contact us.</p>
        <button onClick={fetchRates} type='button' className='btn btn-dark btn-lg'>Try Again</button>
      </div>)
    }
  }

  
  if (!rates.length) {
    fetchRates();
  }

  return (
    <div className="App">

      <header>1 BTC</header>

      {renderError()}

      {rates.map((r, i) => (
        <Rate key={i} rate={r} />
      ))}

    </div>
  );
}

export default App;
