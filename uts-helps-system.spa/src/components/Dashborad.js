import React, {Component} from "react";
import {Link} from "react-router-dom";

export default class Dashboard extends Component {
    render(){
        return(
            <div>
                <div>
                   <label>UTS HELPS</label>
                   <div>
                   <Link to ="/MyBooking"><button>My Bookings</button></Link>
                   <Link to ="/Workshops"><button>Workshops</button></Link>
                   <Link to ="/Resources"><button>Resources</button></Link>
                   <Link to ="/FAQ"><button>FAQ</button></Link>
                   <textarea>Search</textarea>
                   
                </div>
                </div>
            </div>
        )
    }

}