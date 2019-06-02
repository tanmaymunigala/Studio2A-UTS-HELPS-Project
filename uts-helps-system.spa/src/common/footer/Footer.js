import React from "react";
import Grid from "@material-ui/core/Grid";
import { Typography, withStyles } from "@material-ui/core";
 import Style from "./Style"

function Footer({ children }) {
  return (
    <Grid
      container
      style={{ backgroundColor: "#171414" }}
      direction="column"
      justify="space-evenly"
      alignItems="center"
    >
      <Grid
        container
        style={{ marginTop: 20 }}
        direction="row"
        justify="center"
        spacing={40}
        alignItems="center"
      >
        <Grid item>
          <Typography style={{ color: "white" }} variant="h6">
            {" "}
            <a style={{textDecoration:'none',color:'white'}}href="https://www.uts.edu.au/current-students/support/helps">About Us</a>
          </Typography>
        </Grid>
        <Grid item>
          <Typography style={{ color: "white" }} variant="h6">
          <a style={{textDecoration:'none',color:'white'}} href="https://www.uts.edu.au/current-students/support/helps">FAQ</a>
          </Typography>
        </Grid>
        <Grid item>
          <Typography style={{ color: "white" }} variant="h6">
          <a style={{textDecoration:'none',color:'white'}} href="https://www.uts.edu.au/current-students/support/helps">Contact Us</a>
          </Typography>
        </Grid>
      </Grid>

      <Grid
        item
        style={{
          marginTop: 20,
          marginBottom: 20,
          marginRight: 70,
          marginLeft: 70
        }}
      >
        <Typography style={{ color: "white" }} paragraph={true}>
          © Copyright UTS - CRICOS Provider No: 00099F - 27 November 2008 10:34
          AM The page is authorised by Director, SSU - Send comments to
          operations manager Disclaimer | Privacy | Copyright | Accessibility |
          Web policy | UTS homepage
        </Typography>
      </Grid>
    </Grid>
  );
}

export default withStyles(Style)(Footer);
