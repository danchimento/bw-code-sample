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
        setRates([...result]);
        setError(null);
      })
      .catch((err) => {
        setRates([])
        setError("Error getting rates");
      });
  }

  const renderError = () => {
    if (error) {
      return (<div className='error'>
        <p className='error-text'>{error}</p>
        <p>If the problem persists, please don't contact us.</p>
      </div>)
    }
  }
  
  if (!rates.length && !error) {
    fetchRates();
  }

  return (
    <div className="App">

      <header>1 BTC</header>

      {renderError()}

      {rates.map((r, i) => (
        <Rate key={i} rate={r} />
      ))}

      <button onClick={fetchRates} className='btn btn-light'>Refresh</button>
        
    </div>
  );
}

export default App;
