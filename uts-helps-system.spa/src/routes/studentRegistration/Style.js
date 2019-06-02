const Style = theme => ({
    root: {
      display: "flex",
      justifyContent: "center",
      alignItems: "center",
      flexDirection: "column",
      maxWidth: 800,
      marginLeft: "auto",
      marginRight: "auto",
      marginTop: theme.spacing.unit * 2,
      marginBottom: theme.spacing.unit * 2,
      padding: theme.spacing.unit * 2,
      backgroundColor:'#f5f5f5',
      borderRadius: 25

    },
    appbar: {
      alignItems: "center"
    },
    p: {
      marginTop: 20,
      marginBottom: 20
    },
    card: {
      width: 300,
      height: 300,
      margin: 20,
      display: "flex",
      flexWrap: "wrap",
      justifyContent: "center",
      alignItems: "center"
    },
    icon: {
      height: 25,
      padding: theme.spacing.unit
    },
    section1: {
      margin: `${theme.spacing.unit * 3}px ${theme.spacing.unit * 2}px`
    },
    section2: {
      margin: theme.spacing.unit * 2
    },
    dividerInset: {
      margin: `5px 0 0 ${theme.spacing.unit * 9}px`
    },
    column: {
      padding: theme.spacing.unit * 2,
      margin: 5
    },
    link: {
      textDecoration: "none"
    }, 
    cardIcon: { 
      fontSize: "96px"
    },
    signupButton: {
      margin: theme.spacing.unit
    }
  }); 
  
  export default Style;