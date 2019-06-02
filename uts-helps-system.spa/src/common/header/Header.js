import React from "react";
import PropTypes from "prop-types";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import IconButton from "@material-ui/core/IconButton";
import Typography from "@material-ui/core/Typography";
import InputBase from "@material-ui/core/InputBase";
import Badge from "@material-ui/core/Badge";
import MenuItem from "@material-ui/core/MenuItem";
import Menu from "@material-ui/core/Menu";
import { withStyles } from "@material-ui/core/styles";
import MenuIcon from "@material-ui/icons/Menu";
import SearchIcon from "@material-ui/icons/Search";
import { Link } from "react-router-dom";

import Style from "./Style";

class Header extends React.Component {
  state = {
    anchorEl: null,
    mobileMoreAnchorEl: null
  };
  handleMenuClose = () => {
    this.setState({ anchorEl: null });
    this.handleMobileMenuClose();
  };

  handleMobileMenuOpen = event => {
    this.setState({ mobileMoreAnchorEl: event.currentTarget });
  };

  handleMobileMenuClose = () => {
    this.setState({ mobileMoreAnchorEl: null });
  };

  render() {
    const { anchorEl, mobileMoreAnchorEl } = this.state;
    const { classes } = this.props;
    const isMenuOpen = Boolean(anchorEl);
    const isMobileMenuOpen = Boolean(mobileMoreAnchorEl);

    return (
      <div className={classes.root}>
        <AppBar
          style={{
            position: "static",
            backgroundColor: "#b71c1c",
            minHeight: 80
          }}
        >
          <Toolbar style={{ marginTop: 10 }}>
            {/* Logo */}
             <Link to="/Dashboard"  className={classes.hover}>
                UTS HELPS
             </Link>
             <div className={classes.search}>
              <div className={classes.searchIcon}>
                <SearchIcon />
              </div>
              <InputBase
                placeholder="Search…"
                classes={{
                  root: classes.inputRoot,
                  input: classes.inputInput
                 }}
              />
            </div>
           </Toolbar>
        </AppBar>
      </div>
    );
  }
}


Header.propTypes = {
  classes: PropTypes.object.isRequired
};

export default withStyles(Style)(Header);
