import * as React from 'react';
import PropTypes from 'prop-types';
import Box from '@mui/material/Box';
import Collapse from '@mui/material/Collapse';
import IconButton from '@mui/material/IconButton';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import { TablePagination } from '@mui/material';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import TableRow from '@mui/material/TableRow';
import Button from '@mui/material/Button';
import AddIcon from '@mui/icons-material/Add';
import TableSortLabel from '@mui/material/TableSortLabel';
import Toolbar from '@mui/material/Toolbar';
import Checkbox from '@mui/material/Checkbox';
import Tooltip from '@mui/material/Tooltip';
import FormControlLabel from '@mui/material/FormControlLabel';
import Switch from '@mui/material/Switch';
import DeleteIcon from '@mui/icons-material/Delete';
import FilterListIcon from '@mui/icons-material/FilterList';
import { visuallyHidden } from '@mui/utils';
import { alpha } from '@mui/material/styles';
import {
    GridRowModes,
    DataGrid,
    GridToolbarContainer,
    GridToolbarExport,
    GridActionsCellItem,
    GridRowEditStopReasons,
  } from '@mui/x-data-grid';

  function EditToolbar(props) {
    const { setRows, setRowModesModel } = props;
  
    const handleClick = () => {
      const id = 1;
    };
  
    return (
        <Button color="primary" startIcon={<AddIcon />} onClick={handleClick}>
          Add record
        </Button>
    );
  }

  function EnhancedTableToolbar(props) {
    const { numSelected } = props;
  
    return (
      <Toolbar
        sx={{
          pl: { sm: 2 },
          pr: { xs: 1, sm: 1 },
          ...(numSelected > 0 && {
            bgcolor: (theme) =>
              alpha(theme.palette.primary.main, theme.palette.action.activatedOpacity),
          }),
        }}
      >
        {numSelected > 0 ? (
          <Typography
            sx={{ flex: '1 1 100%' }}
            color="inherit"
            variant="subtitle1"
            component="div"
          >
            {numSelected} selected
          </Typography>
        ) : (
          <Typography
            sx={{ flex: '1 1 100%' }}
            variant="h6"
            id="tableTitle"
            component="div"
          >
            Students
          </Typography>
        )}
  
        {numSelected > 0 ? (
          <Tooltip title="Delete">
            <IconButton>
              <DeleteIcon />
            </IconButton>
          </Tooltip>
        ) : (
          <Tooltip title="Filter list">
            <IconButton>
              <FilterListIcon />
            </IconButton>
          </Tooltip>
        )}
      </Toolbar>
    );
  }
  function Row(props) {
    const { row } = props;
    const [open, setOpen] = React.useState(false);
  
    return (
      <React.Fragment>
        <TableRow sx={{ '& > *': { borderBottom: 'unset' } }}>
          <TableCell>
            <IconButton
              aria-label="expand row"
              size="small"
              onClick={() => setOpen(!open)}
            >
              {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
            </IconButton>
          </TableCell>
          <TableCell component="th" scope="row">
            {row?.name}
          </TableCell>
          <TableCell align="right">{row?.educationProgramId}</TableCell>
          {/* <TableCell align="right">{row?.educationProgram}</TableCell> */}
          <TableCell align="right">{row?.startDate}</TableCell>
          <TableCell align="right">{row?.endDate}</TableCell>
          {/* <TableCell align="right">{row?.students}</TableCell> */}
        </TableRow>
        <TableRow>
          <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
            <Collapse in={open} timeout="auto" unmountOnExit>
              <Box sx={{ margin: 1 }}>
                <Typography variant="h6" gutterBottom component="div">
                  Requests
                </Typography>
                <Table size="small" aria-label="purchases">
                  <TableHead>
                    <TableRow>
                      <TableCell>Request Author</TableCell>
                      <TableCell>Date</TableCell>
                      <TableCell align="right">Education Program Name</TableCell>
                      <TableCell align="right">Education Form Id</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {row?.students?.map((requestsRow) => (
                      <TableRow key={requestsRow?.id}>
                        <TableCell component="th" scope="row">
                          {requestsRow?.name}
                        </TableCell>
                        <TableCell>{requestsRow?.educationProgram?.createdAt}</TableCell>
                        <TableCell align="right">{requestsRow?.educationProgram?.name}</TableCell>
                        <TableCell align="right">{requestsRow?.educationFormId}</TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </Box>
            </Collapse>
          </TableCell>
        </TableRow>
      </React.Fragment>
    );
  }

  export default function GroupTable() {
    const [selected, setSelected] = React.useState([]);
    const [rows, setRows] = React.useState([{}]);
      React.useEffect(() => {
    fetch('http://localhost:5137/Group')
        .then((response) => response.json())
        .then((json) => setRows(json))
        .catch(() => console.log(12345))

}, []);
  return (
    <Box>
    <EnhancedTableToolbar numSelected={selected.length} />
    <EditToolbar></EditToolbar>
    <TableContainer component={Paper}>
      <Table aria-label="collapsible table">
        <TableHead>
          <TableRow>
            <TableCell />
            <TableCell>Id</TableCell>
            <TableCell align="right">Name</TableCell>
            <TableCell align="right">Education Program Id</TableCell>
            <TableCell align="right">Education Program</TableCell>
            <TableCell align="right">Start Date</TableCell>
            <TableCell align="right">End Date</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows?.map((row) => (
            <Row key={row?.id} row={row} />
          ))}
        </TableBody>

      </Table>
    </TableContainer>
    </Box>
  );
}