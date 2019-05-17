import React from "react"

var style = {
    backgroundColor: "#F8F8F8",
    borderTop: "1px solid #E7E7E7",
    textAlign: "center",
    padding: "20px",
    position: "fixed",
    left: "0",
    bottom: "0",
    height: "60px",
    width: "100%",
}

var phantom = {
  display: 'block',
  padding: '20px',
  height: '60px',
  width: '100%',
}

function Footer({ children }) {
    return (
        <div>
            <div style={phantom} />
            <div style={style}>
                { children }
                <p>© Copyright UTS - CRICOS Provider No: 00099F - 27 November 2008 10:34 AM
The page is authorised by Director, SSU - Send comments to operations manager
Disclaimer | Privacy | Copyright | Accessibility | Web policy | UTS homepage</p>
            </div>
        </div>
    )
}

export default Footer