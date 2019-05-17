import React, {Component} from "react";
import {BrowserRouter,Route} from "react-router-dom";

import Login from "./Login";
import RegistrationPersonalDetails from "./RegistrationPersonalDetails";
import Dashboard from "./Dashborad";
import Admin from "./Admin";
import RegistrationEducation from "./RegistrationEducation"
import MyBooking from "./MyBooking"
import Workshops from "./Workshops"
import Resources from "./Resources"
import FAQ from "./FAQ"


import {Header, Footer} from '../common'



export default class App extends Component {
    render(){
        return(
            <div>
                <Header/>
                <BrowserRouter>
                <Route exact path = "/" component = {Login}/>
                <Route exact path = "/RegistrationPersonalDetails" component = {RegistrationPersonalDetails}/>
                <Route exact path = "/Dashboard" component = {Dashboard}/>
                <Route exact path = "/MyBooking" component = {MyBooking}/>
                <Route exact path = "/Admin" component = {Admin}/>
                <Route exact path = "/RegistrationEducation" component = {RegistrationEducation}/>
                <Route exact path = "/MyBooking" component = {MyBooking}/>
                <Route exact path = "/Workshops" component = {Workshops}/>
                <Route exact path = "/FAQ" component = {FAQ}/>
                <Route exact path = "/Resources" component = {Resources}/>
                </BrowserRouter>
                <Footer/>
            </div>
            

           
        )
    }
}
