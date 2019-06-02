import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import { Link } from "react-router-dom";
import WorkshopDetail from './WorkshopDetail'
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import ListItemText from '@material-ui/core/ListItemText';
import ListItem from '@material-ui/core/ListItem';
import List from '@material-ui/core/List';
import Divider from '@material-ui/core/Divider';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import Typography from '@material-ui/core/Typography';
import CloseIcon from '@material-ui/icons/Close';
import Slide from '@material-ui/core/Slide';

const CustomTableCell = withStyles(theme => ({
  head: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  body: {
    fontSize: 14,
  },
}))(TableCell);



const Transition = React.forwardRef(function Transition(props, ref) {
  return <Slide direction="up" ref={ref} {...props} />;
});


const styles = theme => ({
  root: {
    width: '100%',
    marginTop: theme.spacing.unit * 3,
    overflowX: 'auto',
    minHeight:300
  },
  table: {
    minWidth: 700,
  },
  row: {
    '&:nth-of-type(odd)': {
      backgroundColor: theme.palette.background.default,
    },
  },
});

let id = 0;
function createData(name, startDate, endDate, time, room, sessions) {
  id += 1;
  return { id, name, startDate, endDate, time, room, sessions };
}

function handleClick(item){
  return(
    <WorkshopDetail name={item}/>
  );
}

const rows = [
  createData('How to improve your English', '21/05/2019', '21/05/2019', '13:00 - 16:00', 'CB01.05.02', 5),
  createData('Learning grammar 101', '22/05/2019', '22/05/2019', '13:00 - 16:00', 'CB01.05.04', 5),
  createData('Write Now@HELPS! Writing Support Session', '25/05/2019', '25/05/2019', '13:00 - 16:00', 'CB01.06.02', 3),
];

function CustomizedTable(props) {
  const { classes } = props;

  const [open, setOpen] = React.useState(false);

  function handleClickOpen() {
    setOpen(true);
  }

  function handleClose() {
    setOpen(false);
  }
  return (
    <div>
    <Paper className={classes.root}>
      <Table className={classes.table}>
        <TableHead>
          <TableRow>
            <CustomTableCell>Topic </CustomTableCell>
            <CustomTableCell align="right">Start Date</CustomTableCell>
            <CustomTableCell align="right">End Date </CustomTableCell>
            <CustomTableCell align="right">Time </CustomTableCell>
            <CustomTableCell align="right">Room </CustomTableCell>
            <CustomTableCell align="right">Sessions </CustomTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map(row => (
            <TableRow className={classes.row} key={row.id} onClick={handleClickOpen}>
                <CustomTableCell component="th" scope="row">
                  {row.name}
                </CustomTableCell>
                <CustomTableCell align="right">{row.startDate}</CustomTableCell>
                <CustomTableCell align="right">{row.endDate}</CustomTableCell>
                <CustomTableCell align="right">{row.time}</CustomTableCell>
                <CustomTableCell align="right">{row.room}</CustomTableCell>
                <CustomTableCell align="right">{row.sessions}</CustomTableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </Paper>
    <Dialog fullScreen open={open} onClose={handleClose} TransitionComponent={Transition}>
        <AppBar className={classes.appBar}  >
          <Toolbar>
            <IconButton edge="start" color="inherit" onClick={handleClose} aria-label="Close">
              <CloseIcon />
            </IconButton>
          </Toolbar>
        </AppBar>
        <WorkshopDetail/>
      </Dialog>
    </div>
  );
}



CustomizedTable.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(CustomizedTable);