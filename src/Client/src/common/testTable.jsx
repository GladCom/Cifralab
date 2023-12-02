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
import StudentCard from "./StudentCard.jsx";
import Input from '@mui/joy/Input';
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
import axios from 'axios';





function EditToolbar(props) {
    const { setRows, setRowModesModel } = props;
  
    const handleClick = () => {
      StudentCard(true);
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
  const {row} = props;
  const [Row, setRow ] = React.useState({});
  const {edit} = false;
  const [open, setOpen] = React.useState(false);
  const handleDelete = (id) =>
  {
  console.log(id);
  axios.delete('http://localhost:5137/Student/'+id);
  window.location.reload();
  }
//******************************************************************************************** */
  const [birthDate, setBirthDate] = React.useState(row?.birthDate);
  const [isHiddenBD, setHiddenBD] = React.useState(true);
  const handleEditBirthDate = () =>
  {
    if(isHiddenBD)
      setBirthDate("");
    else
      setBirthDate(row?.birthDate);
    setHiddenBD(!isHiddenBD);
  }

  const [snils, setSnils] = React.useState(row?.snils);
  const [isHiddenSnils, setHiddenSnils] = React.useState(true);
  const handleEditSnils = () =>
  {
    if(isHiddenSnils)
      setSnils("");
    else
      setSnils(row?.snils);
    setHiddenSnils(!isHiddenSnils);
  }

  const [id, setId] = React.useState(row?.id);
  const [isHiddenId, setHiddenId] = React.useState(true);
  const handleEditId = () =>
  {
    if(isHiddenId)
      setId("");
    else
      setId(row?.id);
    setHiddenId(!isHiddenId);
  }

  const [docS, setDocS] = React.useState(row?.documentSeries);
  const [isHiddenDocS, setHiddenDocS] = React.useState(true);
  const handleEditDocS = () =>
  {
    if(isHiddenDocS)
      setDocS("");
    else
      setDocS(row?.documentSeries);
    setHiddenDocS(!isHiddenDocS);
  }

  const [docN, setDocN] = React.useState(row?.documentNumber);
  const [isHiddenDocN, setHiddenDocN] = React.useState(true);
  const handleEditDocN = () =>
  {
    if(isHiddenDocN)
      setDocN("");
    else
      setDocN(row?.documentNumber);
    setHiddenDocN(!isHiddenDocN);
  }

  const [nationality, setNationality] = React.useState(row?.nationality);
  const [isHiddenNationality, setHiddenNationality] = React.useState(true);
  const handleEditNationality = () =>
  {
    if(isHiddenNationality)
      setNationality("");
    else
      setNationality(row?.nationality);
    setHiddenNationality(!isHiddenNationality);
  }
//******************************************************************************************** */
  
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
        <TableCell align="right" onDoubleClick={handleEditId}>
          {id}<input hidden={isHiddenId} value={row?.id} type="text" onChange={(e) => setRow(row.id = e.target.value)}></input>
        </TableCell>
        <TableCell align="right" onDoubleClick={handleEditBirthDate}>
          {birthDate}<input hidden={isHiddenBD} value={row?.birthDate} type="text" onChange={(e) => setRow(row.birthDate = e.target.value)}></input>
        </TableCell>
        <TableCell align="right" onDoubleClick={handleEditSnils}>
          {snils}<input hidden={isHiddenSnils} value={row?.snils} type="text" onChange={(e) => setRow(row.snils = e.target.value)}></input>
        </TableCell>
        <TableCell align="right" onDoubleClick={handleEditDocS}>
          {docS}<input hidden={isHiddenDocS} value={row?.documentSeries} type="text" onChange={(e) => setRow(row.documentSeries = e.target.value)}></input>
        </TableCell>
        <TableCell align="right" onDoubleClick={handleEditDocN}>
          {docN}<input hidden={isHiddenDocN} value={row?.documentNumber} type="text" onChange={(e) => setRow(row.documentNumber = e.target.value)}></input>
        </TableCell>
        <TableCell align="right" onDoubleClick={handleEditDocN}>
          {docN}<input hidden={isHiddenDocN} value={row?.documentNumber} type="text" onChange={(e) => setRow(row.documentNumber = e.target.value)}></input>
        </TableCell>
        <td>
          <Box sx={{ display: 'flex', gap: 1 }}>
            <Button size="sm" variant="plain" color="neutral">
              Edit
            </Button>
            <Button size="sm" variant="soft" color="danger"  onClick={(e) => handleDelete(row?.id)}>
              Delete
             </Button>
          </Box>
        </td>
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
                  {row?.requests?.map((requestsRow) => (
                    <TableRow key={requestsRow?.fullName}>
                      <TableCell component="th" scope="row">
                        <Input value={requestsRow?.fullName} readOnly={true}></Input>
                      </TableCell>
                      <TableCell align="right"><Input value={requestsRow?.educationProgram?.createdAt}></Input></TableCell>                   
                      <TableCell align="right"><Input value={requestsRow?.educationProgram?.name}></Input></TableCell>
                      <TableCell align="right"><Input value={requestsRow?.educationFormId}></Input></TableCell>
                      <td>
                        <Box sx={{ display: 'flex', gap: 1 }}>
                          <Button size="sm" variant="plain" color="neutral">
                          Edit
                          </Button>
                          <Button size="sm" variant="soft" color="danger">
                          Delete
                          </Button>
                        </Box>
                      </td>
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



export default function CollapsibleTable() {
    const [selected, setSelected] = React.useState([]);
    const [rows, setRows] = React.useState([{}]);
      React.useEffect(() => {
    fetch('http://localhost:5137/Student/paged?page=0&size=50')
        .then((response) => response.json())
        .then((json) => setRows(json.data))
        .catch(() => console.log(12345))

}, []);
  return (
    <Box>
    <EnhancedTableToolbar numSelected={selected.length} />
    <StudentCard/>
    <TableContainer component={Paper}>
      <Table aria-label="collapsible table">
        <TableHead>
          <TableRow>
            <TableCell />
            <TableCell>Id</TableCell>
            <TableCell align="right">Birth Date</TableCell>
            <TableCell align="right">SNILS</TableCell>
            <TableCell align="right">Doc Number</TableCell>
            <TableCell align="right">Doc Series</TableCell>
            <TableCell align="right">Nationality</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows?.map((row) => (
            <Row key={row?.id} row={row}/>
          ))}
        </TableBody>

      </Table>
    </TableContainer>
    </Box>
  );
}