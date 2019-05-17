import React, {Component} from "react";
import {Link} from "react-router-dom";

export default class RegistrationPersonalDetails extends Component {
    render(){
        return(
            <div>
                <div>  <label>Test the registering student page</label></div>
                <Link to="/helloWorld"><button>Test</button></Link>
                <div>
                <Link to="/helloWorld"><button>Test</button></Link>
                </div>
            </div>
        )
    }

}