import React, {Component} from "react";
import {Link} from "react-router-dom";

export default class Login extends Component {
    render(){
        return(
            <div>
                <div>
                    <label>UTS: HELPS</label>
                </div>
                <div>
                    <label>Student Number: </label>
                    <textarea></textarea>
                </div>
                <div>
                    <label>Password</label>
                    <textarea></textarea>
                </div>
                <Link to="/Dashboard"><button>Login</button></Link>
                <div>
                <Link to="/Admin"><button>Not a Student</button></Link>
                </div>
                <div>
                <Link to="/RegistrationPersonalDetails"><button>Register(Students)</button></Link>
                </div>
            </div>
        )
    }

}