import React, {Component} from "react";
//import {Link} from "react-router-dom";

export default class Dashboard extends Component {
    render(){
        return(
            <div>
                <div>
                   <label>UTS HELPS</label>
                   <div>
                   <button>My Bookings</button>
                   <button>Workshops</button>
                   <button>Resources</button>
                   <button>FAQ</button>
                   <textarea>Search</textarea>
                   
                </div>
                </div>
            </div>
        )
    }

}