import React, { Component } from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
// Material libaray
import { withStyles } from "@material-ui/core/styles";
//Routes
import * as Routes from "../routes/route";


 
import Style from "./Style.js";
class App extends Component {
  render() {
    const { classes } = this.props;
    return (
      <div>
        <BrowserRouter>
        <Routes.Header />

          <Switch>
             <Route exact path="/" component={Routes.Login} />
            <Route
              path="/RegistrationPersonalDetails"
              component={Routes.RegistrationPersonalDetails}
            />
            <Route path="/Dashboard" component={Routes.Dashboard} />
            <Route path="/Dashboard" component={Routes.Dashboard} />
            <Route path="/MyBooking" component={Routes.MyBooking} />
            <Route path="/Workshop" component={Routes.Workshop} />
            <Route path="/Admin" component={Routes.Admin} />
            <Route path ="/AboutUs" component={Routes.AboutUs}/>
            <Route path ="/Sessions" component={Routes.Sessions}/>
            <Route path ="/Main" component={Routes.Main}/>
            <Route path ="/Advisiors" component={Routes.Advisiors}/>
            <Route path ="/WorkshopAdmin" component={Routes.WorkshopAdmin}/>
            <Route path ="/AdminDashboard" component={Routes.AdminDashboard}/>
            <Route path ="/EmailTemplates" component={Routes.EmailTemplates}/>
            <Route path ="/WaitingLists" component={Routes.WaitingLists}/>
            
            
           </Switch>
        </BrowserRouter>
        <Routes.Footer />
      </div>
    );
  }
}
export default withStyles(Style)(App);
