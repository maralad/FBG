import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';


function App() {
  const [competitions, setCompetitions] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/v1/competitions').then(response =>{
    console.log(response);  
    setCompetitions(response.data);
    })
  }, [])

  return (
    <div>
      <Header as='h2' icon='users' content='Competitions'/>
          <List>
          {competitions.map((competition: any) =>(
               <List.Item key={competition.id}>
                 {competition.title}

               </List.Item>
            
              ))}
          </List>
         

    </div>
  );
}

export default App;
