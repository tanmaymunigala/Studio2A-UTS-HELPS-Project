import React, { Component } from 'react'
import MyBookingList from './MyBookingList'
import TextField from '@material-ui/core/TextField';
import {Link} from "react-router-dom";


export class MyBooking extends Component {
  render() {
    return (
      <div>
          <br/>
          !Pro tip : Avoid TimeTable clash, Check beforehand!
          <div>
            <TextField
              id="standard-read-only-input"
              align="left"
              defaultValue="My upcoming booking"
              margin="normal"
              InputProps={{
                readOnly: true,
              }}/>
          </div>
          <MyBookingList/>
          <div>
          <Link to="/Dashboard"><button>Return to Dashboard</button></Link>
        </div>
      </div>
    )
  }
}

export default MyBooking
