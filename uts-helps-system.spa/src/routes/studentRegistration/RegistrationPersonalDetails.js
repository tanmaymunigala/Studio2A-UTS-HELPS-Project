import React, { Component } from "react";
import PropTypes from "prop-types";
import { withStyles } from "@material-ui/core/styles";
import Style from "./Style";
import { TextField, AppBar, Toolbar, Typography } from "@material-ui/core";
import { Grid, Button, Paper, Divider } from "@material-ui/core";
//Uts Picture
import UTSregi from "../../assets/pictures/uts-regi.PNG";

// Router
import { Link } from "react-router-dom";
//dialog
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogContentText,
  DialogActions
} from "@material-ui/core";

// Gender Button
import GenderSelect from "./GenderSelect";

class Business extends Component {
  state = {
    dialog: false,
    Name: "",
    Faculty: "",
    Course: "",
    email: "",
    mobile: "",
    FirstLanguage: "",
    orgin: "",
    password: "",
    con_password: "",
    code: ""
  };

  //close the confirm dialog
  handleClose = () => {
    this.setState({ dialog: false });
  };

  handleChange = e => {
    this.setState({ [e.target.name]: e.target.value });
  };
  handleverifyCode = e => {
    //check the code and code password have the same value
    console.log(this.state.code);
    if (32199 !== 32199) {
      alert("Codes Do Not Match!");
      e.preventDefault();
    } else {
      return <Link to="/Dashboard"> Complete Sign Up </Link>;
    }
  };
  handleSubmit = e => {
    //check the password and confirm password have the same value
    if (e.target.password.value !== e.target.con_password.value) {
      alert("Passwords Do Not Match!");
      e.preventDefault();
    } else {
      e.preventDefault();
      this.setState({ dialog: true });
    }
  };

  render() {
    const { classes } = this.props;

    return (
      <div
        style={{
          marginLeft: "auto",
          marginRight: "auto",
          backgroundImage: `url(${UTSregi})`,
          opacity: 0.7,
          minHeight: 800,
          marginTop: 0
        }}
      >
        {" "}
        <Grid container>
          <Paper className={classes.root}>
            {/* Signup Title for form */}
            <Link to="/signup" className={classes.link}>
              <AppBar position="static" className={classes.appbar}>
                <Toolbar>
                  <Typography variant="h6" color="inherit">
                    Student Registration
                  </Typography>
                </Toolbar>
              </AppBar>
            </Link>

            <Typography
              variant="body1"
              color="inherit"
              className={classes.section1}
            >
              Already have an account here? <Link to="/"> Sign In here!</Link>
            </Typography>
            <Grid
              container
              className={classes.column}
              direction="row"
              alignItems="center"
              justify="center"
              spacing={24}
            >
              <Grid className={classes.column} item xs={12} sm={6}>
                <form onSubmit={this.handleSubmit}>
                  <Grid
                    container
                    direction="row"
                    spacing={8}
                    alignItems="center"
                    justify="center"
                  >
                    {/* Business Name */}
                    <Grid item xs={12}>
                      <TextField
                        required
                        id="Name"
                        name="Name"
                        label="Name"
                        variant="outlined"
                        fullWidth
                        autoComplete="bname"
                        value={this.state.Name}
                        onChange={this.handleChange}
                      />
                    </Grid>
                    {/* Faculty */}
                    <Grid item xs={12}>
                      <TextField
                        required
                        id="Faculty"
                        name="Faculty"
                        label="Faculty"
                        variant="outlined"
                        fullWidth
                        autoComplete="lname"
                        value={this.state.Faculty}
                        onChange={this.handleChange}
                      />
                    </Grid>
                    {/* Course */}
                    <Grid item xs={12}>
                      <TextField
                        required
                        id="Course"
                        name="Course"
                        label="Course"
                        variant="outlined"
                        fullWidth
                        autoComplete="lname"
                        value={this.state.Course}
                        onChange={this.handleChange}
                      />
                    </Grid>
                    {/* Email */}
                    <Grid item xs={12}>
                      <TextField
                        required
                        id="email"
                        name="email"
                        label="Email"
                        type="email"
                        variant="outlined"
                        fullWidth
                        value={this.state.email}
                        onChange={this.handleChange}
                      />
                    </Grid>
                    {/* mobile */}
                    <Grid item xs={12}>
                      <TextField
                        required
                        id="mobile"
                        name="mobile"
                        label="Mobile"
                        type="mobile"
                        variant="outlined"
                        fullWidth
                        value={this.state.mobile}
                        onChange={this.handleChange}
                      />
                    </Grid>
                    {/* GenderSelect */}
                    <Grid item xs={12}>
                      <GenderSelect />
                    </Grid>
                    <Grid item xs={12}>
                      <TextField
                        id="FirstLanguage"
                        name="FirstLanguage"
                        label="First Language"
                        type="FirstLanguage"
                        variant="outlined"
                        fullWidth
                        value={this.state.FirstLanguage}
                        onChange={this.handleChange}
                      />
                    </Grid>
                    {/* orgin */}
                    <Grid item xs={12}>
                      <TextField
                        id="orgin"
                        name="orgin"
                        label="Orgin"
                        type="orgin"
                        variant="outlined"
                        fullWidth
                        value={this.state.orgin}
                        onChange={this.handleChange}
                      />
                    </Grid>
                    {/* Password */}
                    <Grid item xs={12}>
                      <TextField
                        required
                        id="password"
                        name="password"
                        label="Password"
                        type="password"
                        variant="outlined"
                        fullWidth
                        value={this.state.password}
                        onChange={this.handleChange}
                        helperText="Password policy: uppercase letters, lowercase letters, numbers"
                      />
                    </Grid>
                    {/* Confirm password */}
                    <Grid item xs={12}>
                      <TextField
                        required
                        id="con_password"
                        name="con_password"
                        label="Confirm password"
                        type="password"
                        variant="outlined"
                        fullWidth
                        value={this.state.con_password}
                        onChange={this.handleChange}
                      />
                    </Grid>
                    <Button
                      className={classes.signupButton}
                      variant="contained"
                      size="large"
                      color="primary"
                      type="submit"
                    >
                      Register Now{" "}
                    </Button>
                    {/* Confirmation dialog */}
                    <Dialog
                      open={this.state.dialog}
                      onClose={this.handleClose}
                      aria-labelledby="form-dialog-title"
                    >
                      <DialogTitle id="form-dialog-title">
                        Validation Code
                      </DialogTitle>
                      <Divider variant="fullWidth" />
                      <DialogContent>
                        <DialogContentText className={classes.p}>
                          Enter code received at acount.com to complete sign up
                        </DialogContentText>

                        {/* Dialog form inside */}
                        <TextField
                          autoFocus
                          id="code"
                          margin="dense"
                          type="text"
                          placeholder="Verification Code (6 digits)"
                          fullWidth
                          onChange={this.handleChange}
                        />
                      </DialogContent>
                      <DialogActions>
                        {/* Dialog buttons */}
                        <Button
                          component={Link}
                          to="/Dashboard"
                          variant="contained"
                          color="primary"
                          color="primary"
                          label="Verify"
                        > verify
                            </Button>
                        <Button onClick={this.handleClose} color="primary">
                          Cancel
                        </Button>
                      </DialogActions>
                    </Dialog>
                  </Grid>
                </form>
              </Grid>
            </Grid>
          </Paper>
        </Grid>
      </div>
    );
  }
}

Business.propTypes = {
  classes: PropTypes.object.isRequired
};

export default withStyles(Style)(Business);
