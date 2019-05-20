import React, {Component} from "react";
import {Link} from "react-router-dom";

export default class Dashboard extends Component {
    render(){
        return(
            <div>
                <div>
                   <label>UTS HELPS</label>
                   <div>
                   <Link to="/MyBooking"><button>My Bookings</button></Link>
                   <Link to="/Workshop"><button>Workshops</button></Link>
                   <button>Resources</button>
                   <button>FAQ</button>
                   </div>
                   <div>
                   <Link to="/"><button>Return to Homepage</button></Link>
                   </div>
                </div>
            </div>
        )
    }

}