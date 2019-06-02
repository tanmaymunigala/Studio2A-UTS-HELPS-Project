import React, { Component } from "react";
import { Link } from "react-router-dom";
import Grid from "@material-ui/core/Grid";
import Paper from "@material-ui/core/Paper";
import TextField from "@material-ui/core/TextField";
import UTSBanner from "../../../assets/pictures/banner.jpg";
import InputAdornment from "@material-ui/core/InputAdornment";
import Visibility from "@material-ui/icons/Visibility";
import VisibilityOff from "@material-ui/icons/VisibilityOff";
import IconButton from "@material-ui/core/IconButton";
import { Typography } from "@material-ui/core";
import Checkbox from "@material-ui/core/Checkbox";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import PropTypes from "prop-types";
import Button from "@material-ui/core/Button";
import Style from "./Style"
export default class Login extends Component {
  state = {
    password: "",
    showPassword: false,
    checkedA: true
  };

  handleChange = prop => event => {
    this.setState({ [prop]: event.target.value });
  };
  handleChangeCheckBox = name => event => {
    this.setState({ [name]: event.target.checked });
  };
  handleClickShowPassword = () => {
    this.setState(state => ({ showPassword: !state.showPassword }));
  };
  render() {
    const { classes } = this.props;

    return (
      <Paper
        style={{
          marginLeft: "auto",
          marginRight: "auto",
          backgroundImage: `url(${UTSBanner})`,
          opacity: 0.7,
          minHeight: 800
        }}
      >
        <Grid container>
          <Grid
            container
            style={{
              borderStyle: "solid",
              borderWidth: 7,
              borderRadius: 5,
              borderColor: "#4D7DDC",
              backgroundColor: "white",
              maxWidth: 900,
              minHeight: 400,
              marginRight: "auto",
              marginLeft: "auto",
              marginTop: 150
            }}
            direction="column"
            justify="center"
            alignItems="center"
          >
            <Grid
              item
              style={{
                marginLeft: "auto",
                marginRight: "auto",
                marginBottom: 30
              }}
            >
              <Typography
                style={{ fontFamily: "open-sans", color: "#000000" }}
                variant="h3"
              >
                Welcome to UTS HELPS Booking System
              </Typography>
            </Grid>
            <Grid item>
              <TextField
                style={{ flexBasis: 200, margin: 8, minWidth: 270 }}
                id="filled-uncontrolled"
                label="Username"
                defaultValue="foo"
                minWidth="300"
                margin="normal"
                marginLeft="auto"
                marginRight="auto"
                variant="filled"
              />
            </Grid>
            <Grid item>
              <TextField
                id="filled-adornment-password"
                style={{ flexBasis: 200, margin: 8 }}
                variant="filled"
                type={this.state.showPassword ? "text" : "password"}
                label="Password"
                value={this.state.password}
                onChange={this.handleChange("password")}
                InputProps={{
                  endAdornment: (
                    <InputAdornment position="end">
                      <IconButton
                        aria-label="Toggle password visibility"
                        onClick={this.handleClickShowPassword}
                      >
                        {this.state.showPassword ? (
                          <VisibilityOff />
                        ) : (
                          <Visibility />
                        )}
                      </IconButton>
                    </InputAdornment>
                  )
                }}
              />
            </Grid>
            <Grid item style={{ marginLeft: 1, marginRight: 100 }}>
              <FormControlLabel
                control={
                  <Checkbox
                    checked={this.state.checkedA}
                    onChange={this.handleChangeCheckBox("checkedA")}
                    value="checkedA"
                    color="primary"
                  />
                }
                label="Keep me logged in"
              />
            </Grid>

            <Grid item>
              <Button
                component={Link}
                to="/Dashboard"
                variant="contained"
                color="primary"
                style={{
                  width: "100%",
                  padding: 15,
                  marginTop: 10,
                  marginLeft: "auto",
                  marginRight: "auto",
                  minWidth: 265
                }}
              >
                Log In
              </Button>
            </Grid>
          </Grid>

          {/* <Link to="/Dashboard"><button>Login</button></Link>
                <div>
                <Link to="/RegistrationPersonalDetails"><button>Register</button></Link> */}
        </Grid>
      </Paper>
    );
  }
}
