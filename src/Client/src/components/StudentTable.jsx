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
import StudentCard from "../common/StudentCard.jsx";
import Input from '@mui/joy/Input';
import { visuallyHidden } from '@mui/utils';
import { alpha } from '@mui/material/styles';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import {
    GridRowModes,
    DataGrid,
    GridToolbarContainer,
    GridToolbarExport,
    GridActionsCellItem,
    GridRowEditStopReasons,
  } from '@mui/x-data-grid';
import axios from 'axios';


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
  const [isNew, setIsNew] = React.useState(true);
  const [Row, setRow ] = React.useState({});
  const [open, setOpen] = React.useState(false);
  const [edit, setEdit] = React.useState(true);
  const [editRequest, setEditRequest] = React.useState(true);
  const [editSave, setEditSave] = React.useState("Edit");
  const [editSaveRequest, setEditSaveRequest] = React.useState("Edit");
  const [birthDate, setBirthDate] =React.useState(row?.birthDate);
  const [requests, setRequests] = React.useState([row.requests]);

  const handleDelete = (id) =>
  {
  console.log(id);
  axios.delete('http://localhost:5137/Student/'+id);
  window.location.reload();
  }

  const handleEdit = (row) =>
  {
    console.log(isNew)
    if(edit)
      setEditSave("Save");
    else
    {
      setEditSave("Edit");
        if(row?.isNew)
        {
          row.email = "blablabla";
          row.phone = "blablabla";
          delete row.isNew;
          axios.post('http://localhost:5137/Student', row)
        }
        else
          axios.put('http://localhost:5137/Student/'+row.id, row);

        console.log(row);
    }
    console.log("test");    
    setEdit(!edit);
  }
  
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
          <Input value={row?.fullName} readOnly={edit} onChange={(e) => setRow(row.fullName = e.target.value)}/>
        </TableCell>
        <TableCell align="right" type="date" width={180}><Input value={row?.birthDate} readOnly={edit} onChange={(e) => setRow(row.birthDate = e.target.value)} width={180}/></TableCell>
        <TableCell align="right"><Input value={row?.snils} readOnly={edit} onChange={(e) => setRow(row.snils = e.target.value)}/></TableCell>
        <TableCell align="right"><Input value={row?.documentSeries} readOnly={edit} onChange={(e) => setRow(row.documentSeries = e.target.value)}/></TableCell>
        <TableCell align="right"><Input value={row?.documentNumber} readOnly={edit} onChange={(e) => setRow(row.documentNumber = e.target.value)}/></TableCell>
        <TableCell align="right"><Input value={row?.nationality} readOnly={edit} onChange={(e) => setRow(row.nationality = e.target.value)}/></TableCell>
        <td>
          <Box sx={{ display: 'flex', gap: 1 }}>
            <Button size="sm" variant="plain" color="neutral" onClick={() => handleEdit(row)}>
              {editSave}
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
                    <TableCell>EducationProgramId</TableCell>
                    <TableCell>Education Program Name</TableCell>
                    <TableCell>Interview</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {row?.requests?.map((requestsRow) => (                  
                    <TableRow key={requestsRow?.id}>
                      <TableCell component="th" scope="row">
                        <Input readOnly={editRequest} value={requestsRow?.educationProgramId} onChange={(e) => setRow(requestsRow.educationProgramId = e.target.value)}/>
                      </TableCell>
                      <TableCell><Input readOnly={editRequest} value={requestsRow?.educationProgram?.name} onChange={(e) => setRow(requestsRow.educationProgram.name = e.target.value)}/></TableCell>                   
                      <TableCell><Input readOnly={editRequest} value={requestsRow?.interview} onChange={(e) => setRow(requestsRow.interview = e.target.value)}/></TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </Box>
          </Collapse>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box sx={{ margin: 1 }}>
              <Typography variant="h6" gutterBottom component="div">
                Groups
              </Typography>
              <Table size="small" aria-label="purchases">
                <TableHead>
                  <TableRow>
                    <TableCell>Name</TableCell>
                    <TableCell>Education Program Name</TableCell>
                    <TableCell>Start Date</TableCell>
                    <TableCell>End Date</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {row?.groups?.map((groupsRow) => (                  
                    <TableRow key={groupsRow?.id}>
                      <TableCell component="th" scope="row">
                        <Input readOnly={editRequest} value={groupsRow?.name} onChange={(e) => setRow(groupsRow.name = e.target.value)}/>
                      </TableCell>
                      <TableCell><Input readOnly={editRequest} value={groupsRow?.educationProgram?.name} onChange={(e) => setRow(groupsRow.educationProgram.name = e.target.value)}/></TableCell>                   
                      <TableCell><Input readOnly={editRequest} value={groupsRow?.startDate} onChange={(e) => setRow(groupsRow.startDate = e.target.value)}/></TableCell>
                      <TableCell><Input readOnly={editRequest} value={groupsRow?.endDate} onChange={(e) => setRow(groupsRow.endDate = e.target.value)}/></TableCell>
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

    const handleClickAdd = () => {
      console.log(111);
      setRows((rows) => [...rows, {isNew: true}]);
    };

    React.useEffect(() => {
    fetch('http://localhost:5137/Student/paged?page=0&size=50')
        .then((response) => response.json())
        .then((json) => setRows(json.data))
        .catch(() => console.log(12345))},[]);
  return (
    <Box>
    <EnhancedTableToolbar numSelected={selected.length} />
    <Button color="primary" startIcon={<AddIcon />} onClick={handleClickAdd}>
      Add record
    </Button>
    <TableContainer component={Paper}>
      <Table aria-label="collapsible table">
        <TableHead>
          <TableRow>
            <TableCell />
            <TableCell>Full Name</TableCell>
            <TableCell align="right" width={18}>Birth Date</TableCell>
            <TableCell align="right">SNILS</TableCell>
            <TableCell align="right">Doc Number</TableCell>
            <TableCell align="right">Doc Series</TableCell>
            <TableCell align="right">Nationality</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows?.map((row) => (
            <Row key={row?.id} row={row} isNew={row.isNew}/>
          ))}
        </TableBody>

      </Table>
    </TableContainer>
    </Box>
  );
}