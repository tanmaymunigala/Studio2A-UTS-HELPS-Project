import React from "react"
import Grid from "@material-ui/core/Grid"
import { Typography } from "@material-ui/core";
import utsLogo from "../../assets/pictures/utsFooter.PNG"
var style = {
    backgroundColor: "#F8F8F8",
    borderTop: "1px solid #E7E7E7",
    textAlign: "center",
    padding: "20px",
    position: "fixed",
    left: "0",
    bottom: "0",
    height: "60px",
    width: "100%",
}

var phantom = {
  display: 'block',
  padding: '20px',
  height: '60px',
  width: '100%',
}

  function Footer({ children }) {
    return (


        <Grid container  
            style={{backgroundColor:"#171414"}}
            direction="column"
            justify="space-evenly"
            alignItems="center">
           
             <Grid container 
                         style={{marginTop:20}}
                        direction="row"
                        justify="center"
                        spacing={40}
                        alignItems="center">
                     
                    <Grid item> 
                        <Typography style={{color:"white"}} variant="h6"> About Us </Typography>
                    </Grid>
                    <Grid item>
                        <Typography style={{color:"white"}}  variant="h6">FAQ</Typography>          
                    </Grid>
                    <Grid item>
                        <Typography style={{color:"white"}}  variant="h6">Contact Us</Typography>          
                    </Grid>
                </Grid>

                <Grid item style={{marginTop:20,marginBottom:20,marginRight:70,marginLeft:70}}>
                    <Typography style={{color:"white"}} paragraph={true}>
                        © Copyright UTS - CRICOS Provider No: 00099F - 27 November 2008 10:34 AM
                        The page is authorised by Director, SSU - Send comments to operations manager
                        Disclaimer | Privacy | Copyright | Accessibility | Web policy | UTS homepage
                    </Typography>
            </Grid>
       </Grid>
    )
}

export default  ( Footer);