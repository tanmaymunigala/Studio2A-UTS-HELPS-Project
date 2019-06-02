import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import { Card, CardHeader } from "@material-ui/core";
import ButtonBase from '@material-ui/core/ButtonBase';

const styles = theme => ({
  root: {
    flexGrow: 1,
  },
  paper: {
    padding: 10,
    margin: 'auto',
    maxWidth: 5000,
  },
  img: {
    margin: 'auto',
    display: 'block',
    maxWidth: '100%',
    maxHeight: '100%',
  },
});



function ComplexGrid(props) {
  const { classes } = props;
  return (
    <div className={classes.root}>
        <Card raised="true" style={{ background: "#81d4fa",marginTop:20 , marginBottom:20, marginLeft: 10, marginRight: 10,marginBottom:30 }} >
        <CardHeader style={{fontFamily:"Times New Roman" }} />
        <Grid item style={{  marginLeft: 10, marginRight: 10, marginBottom:20  }}>
        <Paper className={classes.paper}>
        <Grid container spacing={2}>
          <Grid item xs={12} sm container>
            <Grid item xs container direction="column" spacing={2} >
              <Grid item xs>
                <Typography gutterBottom variant="subtitle1">
                  How to study 101
                </Typography>
                <Typography variant="body2" gutterBottom>
                  CB01.05.101
                </Typography>
                <Typography variant="body2" color="textSecondary">
                  22/5/2019
                </Typography>
              </Grid>
              <Grid item>
                <Typography variant="body2" style={{ cursor: 'pointer' }}>
                  Remove
                </Typography>
              </Grid>
            </Grid>
            <Grid item>
              <Typography variant="subtitle1">$19.00</Typography>
            </Grid>
          </Grid>
        </Grid>
      </Paper>
        </Grid>
        </Card>
      
    </div>
  );
}

ComplexGrid.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(ComplexGrid);