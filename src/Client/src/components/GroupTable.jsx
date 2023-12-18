import * as React from 'react';
import Box from '@mui/material/Box';
import Collapse from '@mui/material/Collapse';
import IconButton from '@mui/material/IconButton';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
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
import Toolbar from '@mui/material/Toolbar';
import Checkbox from '@mui/material/Checkbox';
import Tooltip from '@mui/material/Tooltip';
import DeleteIcon from '@mui/icons-material/Delete';
import FilterListIcon from '@mui/icons-material/FilterList';
import Input from '@mui/joy/Input';
import { alpha } from '@mui/material/styles';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import ListItemText from '@mui/material/ListItemText';
import style from './style/Tables.css';
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
            color="black"
          >
            Группы
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
  const [editSave, setEditSave] = React.useState("Изменить");
  const [educationPrograms, setEducationPrograms] = React.useState([{}]);
  const [students, setStudents] = React.useState([]);

  const handleDelete = (id) =>
  {
    axios.delete(global.config.conf.address.denis + 'Group/'+id);
    window.location.reload();
  }

  const handleEdit = (row) =>
  {
    if(edit)
      setEditSave("Сохранить");
    else
    {
      setEditSave("Изменить");
        if(row?.isNew)
        {
          delete row.isNew;
          axios.post(global.config.conf.address.denis + 'Group', row)
        }
        else
          axios.put(global.config.conf.address.denis + 'Group/'+row.id, row);

        console.log(row);
    }
    setEdit(!edit);
  }
  const handleChangeEducationProgram = (id) => {
    setRow(row.educationProgramId = educationPrograms.filter(x => x.id == id)[0]?.id);
  }

  React.useEffect(() => {
    fetch(global.config.conf.address.denis + 'EducationProgram')
        .then((response) => response.json())
        .then((json) => setEducationPrograms(json))
        .catch(() => console.log())},[]);

  React.useEffect(() => {
   fetch(global.config.conf.address.denis + 'Student')
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
        <TableCell align="center">
          <IconButton
            aria-label="expand row"
            size="small"
            onClick={() => setOpen(!open)}
          >
            {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
          </IconButton>
        </TableCell>
        <TableCell align="center" component="th" scope="row" title={row?.id}>
          <Input value={row?.id} readOnly={edit} onChange={(e) => setRow(row.name = e.target.value)}/>
        </TableCell>
        <TableCell align="center" sx={{width: '250px', height: '35px'}} title={row?.educationProgramId}>
          <div>
            <FormControl sx={{ m: 1, width: 250}}>
              <Select
              labelId="demo-multiple-checkbox-label"
              id="demo-multiple-checkbox"
              value={[row?.educationProgramId]}
              renderValue={() => educationPrograms?.filter(x => x.id == row.educationProgramId)[0]?.name}
              onChange={(e) => handleChangeEducationProgram(e.target.value)}
              MenuProps={MenuProps}
              sx={{height: 36}}
              readOnly={edit} 
              >
              {educationPrograms.map((program) => (
                <MenuItem key={program?.id} value={program?.id}>
                  <ListItemText primary={program?.name}/>
                </MenuItem>
              ))}
              </Select>
            </FormControl>
          </div>
        </TableCell>
        <TableCell align="center" sx={{width: '100px', height: '35px'}} title={row?.startDate}>< Input value={row?.startDate} readOnly={edit} onChange={(e) => setRow(row.startDate = e.target.value)}/></TableCell>
        <TableCell align="center" sx={{width: '100px', height: '35px'}} title={row?.endDate}><Input value={row?.endDate} readOnly={edit} onChange={(e) => setRow(row.endDate = e.target.value)}/></TableCell>
        <TableCell align="center" sx={{ m: 1, width: 70 }} title={row?.students}>
          <div>
            <FormControl sx={{ m: 1, width: 260}}>
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
              Удалить
             </Button>
          </Box>
        </td>
      </TableRow>
      <TableRow>
        <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box sx={{ margin: 1 }}>
              <Typography variant="h6" gutterBottom component="div">
                Студенты
              </Typography>
              <Table size="small" aria-label="purchases">
                <TableHead>
                  <TableRow>
                    <TableCell align="center">ID</TableCell>
                    <TableCell align="center">Имя</TableCell>
                    <TableCell align="center">Фамилия</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {row?.students?.map((student) => (                  
                    <TableRow key={student?.id}>
                      <TableCell align="center" title={student?.id}><Input value={student?.id}/></TableCell>                   
                      <TableCell align="center" component="th" scope="row" title={student?.fullName}>
                        <Input value={student?.fullName}/>
                      </TableCell>
                      <TableCell align="center" title={student?.fullName}><Input value={student?.fullName} /></TableCell>
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
    fetch(global.config.conf.address.denis + 'Group')
        .then((response) => response.json())
        .then((json) => setRows(json))
        .catch(() => console.log(12345))},[]);
  return (
    <Box>
    <EnhancedTableToolbar numSelected={selected.length} />
    <Button color="primary" startIcon={<AddIcon />} onClick={handleClickAdd}>
      Добавить
    </Button>
    <TableContainer component={Paper}>
      <Table aria-label="collapsible table">
        <TableHead>
          <TableRow>
            <TableCell />
            <TableCell align="center">Имя</TableCell>
            <TableCell align="center" >Образовательная программа</TableCell>
            <TableCell align="center">Дата начала</TableCell>
            <TableCell align="center">Дата окончания</TableCell>
            <TableCell align="center">Студенты</TableCell>
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