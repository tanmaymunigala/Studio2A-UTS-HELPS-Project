import React, {Component} from "./node_modules/react";
import {Link} from "./node_modules/react-router-dom";

export default class RegistrationPersonalDetails extends Component {
    render(){
        return(
            <div>
                <div>  <label>UTS : HELPS</label></div>
                <div>  <label>Student Registration</label>
                </div>
                <div> 
                <div>
                <label>First Name: </label>
                </div>
                <div>
                <label>Last Name: </label>
                </div>
                <Link to="/helloWorld"><button>Next</button></Link>
                </div>
                <div>
                   <Link to="/"><button>Return to Homepage</button></Link>
                </div>
            </div>
        )
    }

}