import React, { Component } from "react";
import { Link } from "react-router-dom";
import { Grid, AppBar, Tabs, Tab } from "@material-ui/core";

import {
  Avatar,
  Collapse,
  IconButton,
  Typography,
  withStyles
} from "@material-ui/core";

//Imports for the card component, just copy the whole line when using cards
import {
  Card,
  CardHeader,
  CardContent,
  CardMedia,
  CardActions
} from "@material-ui/core";
//Imports for Icons, copy the whole line when using Icons
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
// import FavoriteIcon from "@material-ui/icons"
import HelpIcon from "@material-ui/icons";
import PersonPinIcon from "@material-ui/icons/PersonPin";
// import {ThumbDown, ShoppingBasket, PersonPinIcon, PhoneIcon,ThumbUp,ShareIcon,MoreVertIcon} from "@material-ui/icons"

import x from "../..//assets/pictures/skillsCard.jpg";
import classnames from "classnames";
import Style from "./Style";

function TabContainer(props) {
  return (
    <Typography component="div" style={{ padding: 8 * 3 }}>
      {props.children}
    </Typography>
  );
}

class Dashboard extends Component {
  state = {
    value: 0,
    expanded: false
  };
  handleChange = (event, value) => {
    this.setState({ value });
  };
  //for card component
  handleExpandClick = () => {
    this.setState(state => ({ expanded: !state.expanded }));
  };
  render() {
    const { value } = this.state;
    const { classes } = this.props;

    return (
      <Grid container>
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
        {value === 1 && <TabContainer>Item Two</TabContainer>}
        {value === 2 && <TabContainer>Item Three</TabContainer>}
        {value === 3 && <TabContainer>Item Four</TabContainer>}
        {value === 4 && <TabContainer>Item Five</TabContainer>}
        {value === 5 && <TabContainer>Item Six</TabContainer>}
        {value === 6 && <TabContainer>Item Seven</TabContainer>}

        <Grid item style={{ minHeight: 570 }}>
          <Card className={classes.card}>
            <CardHeader
              avatar={
                <Avatar aria-label="Recipe" className={classes.avatar}>
                  R
                </Avatar>
              }
              action={
                <IconButton>
                  <PersonPinIcon />
                </IconButton>
              }
              title="Shrimp and Chorizo Paella"
              subheader="September 14, 2016"
            />
            <CardMedia className={classes.media} src={x} title="Paella dish" />
            <CardContent>
              <Typography component="p">
                This impressive paella is a perfect party dish and a fun meal to
                cook together with your guests. Add 1 cup of frozen peas along
                with the mussels, if you like.
              </Typography>
            </CardContent>
            <CardActions className={classes.actions} disableActionSpacing>
              <IconButton aria-label="Add to favorites">
                <PersonPinIcon />
              </IconButton>
              <IconButton aria-label="Share">
                <PersonPinIcon />
              </IconButton>
              <IconButton
                className={classnames(classes.expand, {
                  [classes.expandOpen]: this.state.expanded
                })}
                onClick={this.handleExpandClick}
                aria-expanded={this.state.expanded}
                aria-label="Show more"
              >
                <ExpandMoreIcon />
              </IconButton>
            </CardActions>
            <Collapse in={this.state.expanded} timeout="auto" unmountOnExit>
              <CardContent>
                <Typography paragraph>Method:</Typography>
                <Typography paragraph>
                  Heat 1/2 cup of the broth in a pot until simmering, add
                  saffron and set aside for 10 minutes.
                </Typography>
                <Typography paragraph>
                  Heat oil in a (14- to 16-inch) paella pan or a large, deep
                  skillet over medium-high heat. Add chicken, shrimp and
                  chorizo, and cook, stirring occasionally until lightly
                  browned, 6 to 8 minutes. Transfer shrimp to a large plate and
                  set aside, leaving chicken and chorizo in the pan. Add
                  pimentón, bay leaves, garlic, tomatoes, onion, salt and
                  pepper, and cook, stirring often until thickened and fragrant,
                  about 10 minutes. Add saffron broth and remaining 4 1/2 cups
                  chicken broth; bring to a boil.
                </Typography>
                <Typography paragraph>
                  Add rice and stir very gently to distribute. Top with
                  artichokes and peppers, and cook without stirring, until most
                  of the liquid is absorbed, 15 to 18 minutes. Reduce heat to
                  medium-low, add reserved shrimp and mussels, tucking them down
                  into the rice, and cook again without stirring, until mussels
                  have opened and rice is just tender, 5 to 7 minutes more.
                  (Discard any mussels that don’t open.)
                </Typography>
                <Typography>
                  Set aside off of the heat to let rest for 10 minutes, and then
                  serve.
                </Typography>
              </CardContent>
            </Collapse>
          </Card>
        </Grid>
      </Grid>
    );
  }
}

export default withStyles(Style)(Dashboard);
