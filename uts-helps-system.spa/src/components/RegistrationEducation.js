import React, {Component} from "react";
import {Link} from "react-router-dom";

export default class RegistrationEducation extends Component {
    render(){
        return(
            <div>
                <div>  <label>UTS : HELPS</label></div>
                <div>  <label>Student Registration</label>
                <label>______________Educational Details</label>
                </div>

                <div>
                    <label>Degree Type</label>
                    <div>
                    <input type="radio" id="ug" name="degree" value="ug"
                    checked/>
                        <label for="ug">UnderGraduate</label>
                        <input type="radio" id="g" name="degree" value="g"
                    checked/>
                        <label for="g">Graduate</label>
                        <input type="radio" id="doctor" name="degree" value="doctor"
                    checked/>
                        <label for="doctor">Doctorate</label>
                </div>
                </div>
                <div>
                    <label>Degree Name</label>
                    <textarea></textarea>
                </div>
                <div>
                    <label>Student Type</label>
                    <textarea></textarea>
                </div>

                <div>
                    <label>Educational Background</label>
                    <div>
                    <input type="radio" id="toefl" name="education" value="toefl"
                    checked/>
                        <label for="toefl">TOEFL</label>
                        <input type="radio" id="ielts" name="education" value="ielts"
                    checked/>
                        <label for="toefl">IELTS</label>
                        <input type="radio" id="diploma" name="education" value="diploma"
                    checked/>
                        <label for="diploma">Diploma</label>

                        <div>
                            <textarea>Others</textarea>
                        </div>
                    </div>
                </div>

                <div>
                    <Link to ="/Dashboard"><button>Register</button></Link>
                </div>
            </div>
        )
    }

}