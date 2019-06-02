import React, { Component } from "react";
import { Link } from "react-router-dom";
import { Grid, AppBar, Tabs, Tab } from "@material-ui/core";
import {Navigation, Drawer, Layout, Content, Header} from 'react-mdl';

//import {Link} from "react-router-dom";

export default class AdminDashboard extends Component {
    render(){
        return(
            <div style={{height: '800px', position: 'relative'}}>
    <Layout style={{background: 'url(http://www.photos-public-domain.com/wp-content/uploads/2012/08/navy-blue-micro-fiber-cloth-fabric-texture-600x400.jpg) center / cover'}}>
        <Header transparent title="UTS : HELPS " style={{color: 'white'}}>
            <Navigation>
                <a href="#"><Link to="/Advisiors">Advisiors</Link></a>
                <a href="#">About Us</a>
                <a href="#">Profile</a>
            </Navigation>
        </Header>
        <Drawer title="UTS:HELPS Admin">
            <Navigation>
              <a href="#">  <Link to="/Sessions"> Sessions</Link></a>
                <Link to="/Advisiors"><a href="#">Advisors</a></Link>
                <Link to="/WaitingLists"><a href="#">Waiting Lists</a></Link>
                <a href="#">Update Messages</a>
                <a href="#">Rooms</a>
                <Link to= "/WorkshopAdmin"><a href="#">Workshops</a></Link>
                <a href="#">Student Management</a>
                <Link to= "/EmailTemplates"><a href="#">Email Templates</a></Link>
            </Navigation>
        </Drawer>
        <Content />
    </Layout>
</div>

        )
    }

}
