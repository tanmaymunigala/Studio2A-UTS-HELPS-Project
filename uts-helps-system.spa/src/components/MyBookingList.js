import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

const CustomTableCell = withStyles(theme => ({
  head: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  body: {
    fontSize: 14,
  },
}))(TableCell);

const styles = theme => ({
  root: {
    width: '100%',
    marginTop: theme.spacing.unit * 3,
    overflowX: 'auto',
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

const rows = [
  createData('How to improve your English', '21/05/2019', '21/05/2019', '13:00 - 16:00', 'CB01.05.02', 4.0),
  createData('Learning grammar 101', '22/05/2019', '22/05/2019', '13:00 - 16:00', 'CB01.05.04', 4.3),
  createData('Speaking skill improvement', '23/05/2019', '23/05/2019', '13:00 - 16:00', 'CB01.07.02', 6.0),
  createData('How to Prepare for your Exams', '21/05/2019', '21/05/2019', '13:00 - 16:00', 'CB01.01.02', 4.3),
  createData('Write Now@HELPS! Writing Support Session', '25/05/2019', '25/05/2019', '13:00 - 16:00', 'CB01.06.02', 3.9),
];

function CustomizedTable(props) {
  const { classes } = props;

  return (
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
            <TableRow className={classes.row} key={row.id}>
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
  );
}

CustomizedTable.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(CustomizedTable);