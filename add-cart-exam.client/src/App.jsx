import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [products, setForecasts] = useState();

    useEffect(() => {
        populateWeatherData();
    }, []);

    const deleteData = (id) => {
        
        fetch('api/RemoveProduct/' + id, {
            method: 'DELETE'
        })
            .then(res => res.json())
            .then(res => {
                console.log(res);
                populateWeatherData();
            })
            .catch(err => console.log(err));
    }

    const contents = products === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Product ID</th>
                    <th>Product Name (C)</th>
                    <th>Cost </th>
                    <th>Amount</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {products.map(product =>
                    <tr key={product.productId}>
                        <td>{product.productName}</td>
                        <td>{product.cost}</td>
                        <td>{product.quantity}</td>
                        <td>{product.amount}</td>
                        <td><button onClick={deleteData(product.productId)}>Delete</button></td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">Product List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
    
    async function populateWeatherData() {
        const response = await fetch('api/GetProducts');
        const data = await response.json();
        setForecasts(data);
    }
}

export default App;