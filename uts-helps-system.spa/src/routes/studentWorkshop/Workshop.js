import React, { Component } from "react";
import WorkshopAvailable from "./WorkshopAvailable";
import WorkshopUpcoming from "./WorkshopUpcoming";
import TextField from "@material-ui/core/TextField";
import { Link } from "react-router-dom";
import Grid from "@material-ui/core/Grid";
import Button from "@material-ui/core/Button";
import Snackbar from "@material-ui/core/Snackbar";
import IconButton from "@material-ui/core/IconButton";
import CloseIcon from "@material-ui/icons/Close";
import LinearProgress from "@material-ui/core/LinearProgress";
import SnackbarContent from "@material-ui/core/SnackbarContent";
import AddIcon from "@material-ui/icons/Add";
import Fab from "@material-ui/core/Fab";
import Tooltip from "@material-ui/core/Tooltip";
import { Card, CardHeader } from "@material-ui/core";
export class Workshop extends Component {
  state = {
    completed: 0,
    open: false
  };
  // this is for linear Progression
  componentDidMount() {
    this.timer = setInterval(this.progress, 500);
  }

  componentWillUnmount() {
    clearInterval(this.timer);
  }
  progress = () => {
    const { completed } = this.state;
    if (completed === 100) {
      this.setState({ completed: 0 });
    } else {
      const diff = Math.random() * 10;
      this.setState({ completed: Math.min(completed + diff, 100) });
    }
  };
  //this is for snackBar
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
    return (
      <div>
        <Card raised="true" style={{ background: "#81d4fa",marginTop:20 , marginBottom:20, marginLeft: 10, marginRight: 10,marginBottom:30 }} >
        <CardHeader style={{fontFamily:"Times New Roman" }} title={"Dear StudentX, current workshops available to you are"}/>
        <Grid item style={{  marginLeft: 10, marginRight: 10, marginBottom:20  }}>
          <WorkshopAvailable />
        </Grid>
        </Card>
        

         <Card   raised="true" style={{ background: "#81d4fa", marginBottom:20, marginLeft: 10, marginRight: 10 }} >
           <CardHeader style={{fontFamily:"Times New Roman" }} title={"Dear StudentX, Upcoming workshops available to you are"}/>
          <Grid item style={{ marginLeft: 10, marginRight: 10 }}>
            <WorkshopUpcoming />
          </Grid>
          <Grid item>
            <Tooltip title="Add" aria-label="Add">
              <Fab color="primary" style={{ minWidth: 210, marginLeft: 30,marginTop:30 }}>
                Upcoming  WorkShops
                <AddIcon onClick={this.handleClick}>
                  {" "}
                  Available WorkShops
                </AddIcon>
              </Fab>
            </Tooltip>
            {/* <Button onClick={this.handleClick}> Available WorkShops</Button> */}
            <Snackbar
              anchorOrigin={{
                vertical: "bottom",
                horizontal: "left"
              }}
              open={this.state.open}
              autoHideDuration={6000}
              onClose={this.handleClose}
              ContentProps={{
                "aria-describedby": "message-id"
              }}
              action={[
                ,
                <IconButton
                  key="close"
                  aria-label="Close"
                  color="inherit"
                  onClick={this.handleClose}
                >
                  <CloseIcon />
                </IconButton>
              ]}
            >
              <SnackbarContent
                onClose={this.handleClose}
                variant="failure"
                message={
                  <span style={{ fontSize: 20 }} id="message-id">
                    There are no more Upcoming WorkShops Available At this moment
                  </span>
                }
              />
            </Snackbar>
          </Grid>
          <Grid item style={{ marginLeft: 10, marginRight: 10, marginTop: 20 ,marginBottom:20}}>
            <LinearProgress variant="buffer" value={this.state.completed} />
            <br />
            <LinearProgress
              color="secondary"
              variant="determinate"
              value={this.state.completed}
            />
          </Grid>
         
        </Card>
        <div >
            <Link to="/Dashboard">
              <button>Return to Dashboard</button>
            </Link>
          </div>
      </div>
    );
  }
}

export default Workshop;
