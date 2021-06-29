import "./App.css";
import GetExchangeRates from "./ExchangeRateService";
import React, { useState } from "react";
import { Rate } from "./Rate";

function App() {
  const [rates, setRates] = useState([]);

  if (!rates.length) {
    GetExchangeRates()
      .then((result) => {
        setRates(result);
      })
      .catch((err) => {
        // Handle errors
        console.error(err);
      });
  }

  return (
    <div className="App">
      <header>1 BTC</header>
      {rates.map((r, i) => (
        <Rate key={i} rate={r} />
      ))}
    </div>
  );
}

export default App;
