import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

class App extends Component {
  render() {
    return (
      <div>
        <from>
          <div>
            <label>User Name</label>
            <input type="text"></input>
            </div>  

            <div>
              <label>Password</label>
              <input type="password"></input>
            </div>
            <div>
              <input type="submit" value="Login"></input>
            </div>
        </from>        
        
      </div>
    );
  }
}

export default App;
