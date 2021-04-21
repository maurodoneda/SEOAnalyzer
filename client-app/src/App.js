import logo from './logo.svg';
import './App.css';
import React, {useEffect, useState} from 'react';
import axios from 'axios';
import SearchForm from './SearchForm';

function App() {

  <SearchForm/>

  const[apiResponse, setApiResponse] = useState([]);
  let searchTerm = "land registry" 
  let url = "www.infotrack.co.uk"
  let endPoint = `https://localhost:5001/Search/GetSearchResults/?searchTerm=${searchTerm}&url=${url}`; 

  useEffect(() => {
    axios.get(endPoint).then((response)=>{
      console.log("position", response);
      setApiResponse(response.data);
    });
  }, [])


  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
           <p> Position of your search: {apiResponse}</p>
        </header>
    </div>
  );
}

export default App;
