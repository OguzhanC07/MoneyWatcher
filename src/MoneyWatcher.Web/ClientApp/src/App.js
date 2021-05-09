import './App.css';
import React, {useState, useEffect} from 'react';
import axios from 'axios';

function App() {
    const [data, setData] = useState("");
    const getData = async () => {
        axios.get('api/login')
            .then(function (response) {
                setData(response.data)
                console.log(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .then(function () {
                // always executed
            });
    }

    useEffect(async () => {
        const result = await axios(
            'api/login',
        );
        setData(result.data);
        console.log(result)
    }, []);


    return (
        <div className="App">
            <button>
                Get Data
            </button>
            {data !== "" ?
                <div>
                    <p>{data.ahmet}</p>
                    <p>{data.number}</p>
                </div> : null}
        </div>
    );
}

export default App;
