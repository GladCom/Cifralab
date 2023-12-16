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
import ListItemText from '@mui/material/ListItemText';

import axios from 'axios';

const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: 100,
      width: 250,
    },
  },
};

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
            Groups
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
  const [educationPrograms, setEducationPrograms] = React.useState([{}]);
  const [students, setStudents] = React.useState([]);

  const handleDelete = (id) =>
  {
    axios.delete('http://localhost:5137/Group/'+id);
    window.location.reload();
  }

  const handleEdit = (row) =>
  {
    if(edit)
      setEditSave("Save");
    else
    {
      setEditSave("Edit");
        if(row?.isNew)
        {
          delete row.isNew;
          axios.post('http://localhost:5137/Group', row)
        }
        else
          axios.put('http://localhost:5137/Group/'+row.id, row);

        console.log(row);
    }
    setEdit(!edit);
  }
  const handleChangeEducationProgram = (id) => {
    row.educationProgram = educationPrograms.filter(x => x.id == id)[0];
  }

  React.useEffect(() => {
    fetch('http://localhost:5137/EducationProgram')
        .then((response) => response.json())
        .then((json) => setEducationPrograms(json))
        .catch(() => console.log())},[]);

  React.useEffect(() => {
   fetch('http://localhost:5137/Student')
      .then((response) => response.json())
      .then((json) => setStudents(json))
      .catch(() => console.log())},[]);

  const handleChandeStudents = (id) => {
    let student = students.filter(x => x.id == id[1])[0];
    if(row?.students == null || row?.students == undefined)
      row.students = [];  
    if (row?.students.indexOf(student) == -1)
      setRow(row?.students.push(student));
    else
      setRow(row?.students.splice(row?.students.indexOf(student), 1));
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
          <Input value={row?.id} readOnly={edit} onChange={(e) => setRow(row.name = e.target.value)}/>
        </TableCell>
        <TableCell sx={{width: '100px', height: '35px'}}>
            <Box sx={{ minWidth: 120 }}>
                <FormControl fullWidth>
                    <InputLabel id="demo-simple-select-label">Education Program</InputLabel>
                    <Select
                    sx={{
                        width: '480px',
                        height: '35px',
                        justifyContent: 'center'
                    }}
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    value={educationPrograms[0].name}
                    label="Education Program"
                    onChange={(e) => handleChangeEducationProgram(e.target.value)}
                    readOnly={edit}
                    >
                    {educationPrograms.map((program) => (
                        <MenuItem value={program.id}>{program.name}</MenuItem>
                    ))}
                    </Select>
                </FormControl>
            </Box>
        </TableCell>
        <TableCell sx={{width: '100px', height: '35px'}}>< Input value={row?.startDate} readOnly={edit} onChange={(e) => setRow(row.startDate = e.target.value)}/></TableCell>
        <TableCell sx={{width: '100px', height: '35px'}}><Input value={row?.endDate} readOnly={edit} onChange={(e) => setRow(row.endDate = e.target.value)}/></TableCell>
        <TableCell align="right" sx={{ m: 1, width: 70 }}>
          <div>
            <FormControl sx={{ m: 1, width: 160}}>
              <Select
              labelId="demo-multiple-checkbox-label"
              id="demo-multiple-checkbox"
              multiple
              value={[row?.students]}
              renderValue={() => row?.students?.map(x => x.fullName)?.join(', ')}
              onChange={(e) => handleChandeStudents(e.target.value)}
              MenuProps={MenuProps}
              sx={{height: 36}}
              readOnly={edit}
              >
              {students.map((student) => (
                <MenuItem key={student?.id} value={student?.id} sx={{width: 500}}>
                  <Checkbox checked={row?.students?.indexOf(student) > -1} />
                  <ListItemText primary={[student?.fullName, ' ', student?.id]} sx={{width: 499}}/>
                </MenuItem>
              ))}
              </Select>
            </FormControl>
          </div>
        </TableCell>
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
                    <TableCell>Id</TableCell>
                    <TableCell>Name</TableCell>
                    <TableCell>Name</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {row?.students?.map((student) => (                  
                    <TableRow key={student?.id}>
                      <TableCell><Input value={student?.id}/></TableCell>                   
                      <TableCell component="th" scope="row">
                        <Input value={student?.fullName}/>
                      </TableCell>
                      <TableCell><Input value={student?.fullName} /></TableCell>
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

    const handleClickAdd = () => {
      console.log(111);
      setRows((rows) => [...rows, {isNew: true}]);
    };

    React.useEffect(() => {
    fetch('http://localhost:5137/Group')
        .then((response) => response.json())
        .then((json) => setRows(json))
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
            <TableCell>Name</TableCell>
            <TableCell >Education Program</TableCell>
            <TableCell >startDate</TableCell>
            <TableCell >endDate</TableCell>
            <TableCell >Students</TableCell>
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