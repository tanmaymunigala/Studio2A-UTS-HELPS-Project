import React, {Component} from "react";
//import {Link} from "react-router-dom";
import { Drawer, Layout, Content, Header,HeaderRow,Tab,HeaderTabs} from 'react-mdl';

import AdminDashboard from "./AdminDashboard"

export default class EmailTemplates extends Component {
    render(){
        return(
            <div style={{height: '800px', position: 'relative',}}>
                      
    
    <Layout fixedHeader fixedTabs>
        <Header>
            <HeaderRow title="_______________________________________________________________________Email Templates______________________________________________________________________________________________________________________________________________" />
            <HeaderTabs ripple activeTab={1} onChange={(tabId) => {}}>
                <Tab>Template A</Tab>
                <Tab>Template B</Tab>
                <Tab>Template C</Tab>
            </HeaderTabs>
        </Header>
        <Drawer title="Admin" />
        <Header>
            <HeaderRow title="" />
            <HeaderTabs ripple activeTab={1} onChange={(tabId) => {}}>
                <Tab>Template D</Tab>
                <Tab>Template E</Tab>
                <Tab>Template F</Tab>
            </HeaderTabs>
        </Header>
        <Header>
            <HeaderRow title="" />
            <HeaderTabs ripple activeTab={1} onChange={(tabId) => {}}>
                <Tab>Template G</Tab>
                <Tab>Template H</Tab>
                <Tab>Template I</Tab>
            </HeaderTabs>
        </Header>
        <Header>
            <HeaderRow title="" />
            <HeaderTabs ripple activeTab={1} onChange={(tabId) => {}}>
                <Tab>Template J</Tab>
                <Tab>Template K</Tab>
                <Tab>Template L</Tab>
            </HeaderTabs>
        </Header>
        <Header>
            <HeaderRow title="" />
            <HeaderTabs ripple activeTab={1} onChange={(tabId) => {}}>
                <Tab>Template M</Tab>
                <Tab>Template N</Tab>
                <Tab>Template O</Tab>
            </HeaderTabs>
        </Header>
        <Content>
            <div className="page-content">
            </div>
        </Content>
        
    </Layout>
</div>

        )
    }

}