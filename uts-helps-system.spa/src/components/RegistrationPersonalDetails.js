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
                <div>
                    <label>Name</label>
                    <textarea></textarea>
                </div>
                <div>
                    <label>Faculty</label>
                    <textarea></textarea>
                </div>
                <div>
                    <label>Course</label>
                    <textarea></textarea>
                </div>
                <div>
                    <label>Email</label>
                    <textarea></textarea>
                </div>
                <div>
                    <label>Mobile</label>
                    <textarea></textarea>
                </div>
                <div>
                    <label>Gender</label>
                  
                    <input type="radio" id="male" name="gender" value="male"
                    checked/>
                        <label for="male">Male</label>

                    <input type="radio" id="female" name="gender" value="female"
                    checked/>
                    <label for="female">Female</label>

                    <input type="radio" id="na" name="gender" value="na"
                    checked/>
                    <label for="na">Do not want to specify</label>
                    
                </div>

                <div>
                    <label>First Language</label>
                    <textarea></textarea>
                </div>
                <div>
                    <label>Ethnic Origin</label>
                    <textarea></textarea>
                </div>
                </div>
                <Link to="/RegistrationEducation"><button>Next</button></Link>
            </div>
        )
    }

}