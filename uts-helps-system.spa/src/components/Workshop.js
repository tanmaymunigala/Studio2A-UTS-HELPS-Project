import React, { Component } from 'react'
import WorkshopAvailable from './WorkshopAvailable'
import WorkshopUpcoming from './WorkshopUpcoming'
import TextField from '@material-ui/core/TextField';

export class Workshop extends Component {
  render() {
    return (
        <div>
        <div>
          <TextField
            id="standard-read-only-input"
            align="left"
            defaultValue="Available workshops"
            margin="normal"
            InputProps={{
              readOnly: true,
            }}/>
        </div>
        <WorkshopAvailable/>
        <div>
          <TextField
            id="standard-read-only-input"
            align="left"
            defaultValue="Upcoming workshops"
            margin="normal"
            InputProps={{
              readOnly: true,
            }}/>
        </div>
        <WorkshopUpcoming/>
    </div>
    )
  }
}

export default Workshop