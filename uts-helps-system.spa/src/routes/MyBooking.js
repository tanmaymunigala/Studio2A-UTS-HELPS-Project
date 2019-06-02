import React, { Component } from 'react'
import MyBookingList from './MyBookingList'
import TextField from '@material-ui/core/TextField';
import {Link} from "react-router-dom";
import { Grid, AppBar, Tabs, Tab } from "@material-ui/core";
import PersonPinIcon from "@material-ui/icons/PersonPin";
import {
  Avatar,
  Collapse,
  IconButton,
  Typography,
  withStyles
} from "@material-ui/core";


function TabContainer(props) {
  return (
    <Typography component="div" style={{ padding: 8 * 3 }}>
      {props.children}
    </Typography>
  );
}


export class MyBooking extends Component {
  
  state = {
    completed:0,
    open:false,
    value: 0


  };

  handleChange = (event, value) => {
    this.setState({ value });
  };
  handleExpandClick = () => {
    this.setState(state => ({ expanded: !state.expanded }));
  };


  handleClick = () => {
    this.setState({ open: true });
  };
  handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }
    this.setState({ open: false });
  };
  

  
  render() {
    
    const{value} = this.state;
    const{classes} = this.props;
  
    return (
      <div>
          
          <div>

          <AppBar position="static" color="default">
          <Tabs
            value={value}
            onChange={this.handleChange}
            variant="scrollable"
            scrollButtons="on"
            indicatorColor="primary"
            textColor="primary"
          >
            <Tab
              component={Link}
              to="/Dashboard"
              label=" Dashboard "
              icon={<PersonPinIcon />}
            />
            
        
            <Tab
              component={Link}
              to="/MyBooking"
              label=" MyBooking "
              icon={<PersonPinIcon />}
            />
            <Tab
              component={Link}
              to="/Workshop"
              label="Workshop"
              icon={<PersonPinIcon />}
            />
            </Tabs>
        </AppBar>
        <br/>
          WARNING: Avoid TimeTable clash, Check beforehand!
          <div></div>

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
