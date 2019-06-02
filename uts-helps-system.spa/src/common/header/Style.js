//imports from material UI
import { fade } from '@material-ui/core/styles/colorManipulator';

const Style = theme => ({
         root: {
          width: '100%',
           color:"red",
        },
        
        hover: {textDecoration: 'none' , color:'white',fontWeight:'normal', fontSize:45,
          "&:hover": {
            fontWeight:'bold', 
           }
        },
        grow: {
          flexGrow: 1,
        },
        menuButton: {
          marginLeft: -12,
          marginRight: 20,
        },
        title: {
          display: 'none',
          [theme.breakpoints.up('sm')]: {
            display: 'block',
          },
        },
        search: {
          position: 'sticky',
          marginTop:20,
           marginLeft:90,
           marginRight:90,
           marginBottom:20,
          borderRadius: theme.shape.borderRadius,
          backgroundColor: fade(theme.palette.common.white, 0.15),
          '&:hover': {
            backgroundColor: fade(theme.palette.common.white, 0.25),
          },
           //marginLeft: 70,
          width: '100%',
          [theme.breakpoints.up('sm')]: {
            marginLeft: 100,
            width: 'auto',
          },
        },
        searchIcon: {
          width: theme.spacing.unit * 9,
          height: '100%',
          position: 'absolute',
          pointerEvents: 'none',
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
        },
        inputRoot: {
          color: 'inherit',
          width: '100%',
          minWidth:500,
        },
        inputInput: {
          paddingTop: theme.spacing.unit*3,
          paddingRight: theme.spacing.unit,
          paddingBottom: 25,
          paddingLeft: theme.spacing.unit * 10,
          transition: theme.transitions.create('width'),
          minWidth:1000,
          width: '100%',
          [theme.breakpoints.up('md')]: {
            width: 200,
          },
        },
        sectionDesktop: {
          display: 'none',
          [theme.breakpoints.up('md')]: {
            display: 'flex',
          },
        },
        sectionMobile: {
          display: 'flex',
          [theme.breakpoints.up('md')]: {
            display: 'none',
          },
        },
      });
export default Style;
