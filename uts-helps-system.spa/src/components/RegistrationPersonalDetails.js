import React, {Component} from "react";
import {Link} from "react-router-dom";

export default class RegistrationPersonalDetails extends Component {
    render(){
        return(
            <div>
                <div>  <label>UTS : HELPS</label></div>
                <div>  <label>Student Registration</label>
                <label>______________Personal Details</label>
                </div>
                <div> 
                
                </div>
                <Link to="/helloWorld"><button>Next</button></Link>
            </div>
        )
    }

}