/*
* This is the theme of the application
*
* @auther: Wai Leong Lau      @Date: 23/02/2018
*/

// Material UI Libaray
import { createMuiTheme } from '@material-ui/core/styles'
import { cyan, amber, indigo, grey, blue, lightBlue } from '@material-ui/core/colors';

// App theme
const Theme = createMuiTheme({
  palette: {
    primary: {
      light: cyan[50],
      main: cyan[800],
      dark: cyan[900],
      searchBox: cyan[500],
      searchBoxFocus: cyan[50]
    },
    secondary: {
      light: amber[400],
      main: amber[500],
      dark: amber[600],
    },
    footer: grey[900],
    icon: {
      facebook: {
        main: indigo[500],
        dark: indigo[900],
      },
      google: {
        main: blue[500],
        dark: blue[900]
      },
      linkedIn: {
        main: lightBlue[800],
        dark: lightBlue[900],
      },
    },
    fontLight: grey[50],
    fontGrey: grey[400],
    white: '#fff',
  },
  typography: {
    useNextVariants: true,
  },
});

export default Theme
