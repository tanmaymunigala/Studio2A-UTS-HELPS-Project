import React, {Component} from "react";
//import {Link} from "react-router-dom";
import { Drawer, Layout, Content, Header,HeaderRow,Tab,HeaderTabs} from 'react-mdl';

import AdminDashboard from "./AdminDashboard"

export default class EmailTemplates extends Component {
    render(){
        return(
            <div style={{height: '700px', position: 'relative'}}>
                        <AdminDashboard/>
    
    <Layout fixedHeader fixedTabs>
        <Header>
            <HeaderRow title="Title" />
            <HeaderTabs ripple activeTab={1} onChange={(tabId) => {}}>
                <Tab>Template A</Tab>
                <Tab>Template B</Tab>
                <Tab>Template C</Tab>
            </HeaderTabs>
        </Header>
        <Drawer title="Title" />
        <Content>
            <div className="page-content">You can add logic to update the content of this container based on the "activeTab" receive in the `onChange` callback.</div>
        </Content>
    </Layout>
</div>
        )
    }

}