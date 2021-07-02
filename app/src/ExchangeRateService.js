export default function GetExchangeRates() {
    return new Promise((resolve, reject) => {
        fetch("http://localhost:5000/ExchangeRate")
            .then(res => res.json())
            .then(
                (result) => resolve(result),
                (error) => reject(error)
            )
    });
}