import * as React from 'react';
import Box from '@mui/material/Box';
import IconButton from '@mui/material/IconButton';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import TableRow from '@mui/material/TableRow';
import Button from '@mui/material/Button';
import AddIcon from '@mui/icons-material/Add';
import Toolbar from '@mui/material/Toolbar';
import Tooltip from '@mui/material/Tooltip';
import DeleteIcon from '@mui/icons-material/Delete';
import FilterListIcon from '@mui/icons-material/FilterList';
import Input from '@mui/joy/Input';
import { alpha } from '@mui/material/styles';
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
            {global.config.conf.educationForm[window.localStorage.getItem("lang")]}
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
  const [isNew] = React.useState(true);
  const [, setRow ] = React.useState({});
  const [edit, setEdit] = React.useState(true);
  const [editSave, setEditSave] = React.useState(global.config.conf.edit[window.localStorage.getItem("lang")]);

  const handleDelete = (id) =>
  {
    axios.delete(global.config.conf.address.denis + 'EducationForm/'+id);
    window.location.reload();
  }

  const handleEdit = (row) =>
  {
    console.log(isNew)
    if(edit)
      setEditSave(global.config.conf.save[window.localStorage.getItem("lang")]);
    else
    {
      setEditSave(global.config.conf.edit[window.localStorage.getItem("lang")]);
        if(row?.isNew)
        {
          delete row.isNew;
          axios.post(global.config.conf.address.denis + 'EducationForm', row)
        }
        else
          axios.put(global.config.conf.address.denis + 'EducationForm/'+row.id, row);

        console.log(row);
    }  
    setEdit(!edit);
  }

  return (
    <React.Fragment>
      <TableRow sx={{ '& > *': { borderBottom: 'unset' } }}>
        <TableCell align="center">
            <Input align="center" value={row?.name} readOnly={edit} onChange={(e) => setRow(row.name = e.target.value)}/>
        </TableCell>
        <td>
          <Box sx={{ display: 'flex', gap: 1 }}>
            <Button size="sm" variant="plain" color="neutral" onClick={() => handleEdit(row)}>
              {editSave}
            </Button>
            <Button size="sm" variant="soft" color="danger"  onClick={(e) => handleDelete(row?.id)}>
            {global.config.conf.delete[window.localStorage.getItem("lang")]}
             </Button>
          </Box>
        </td>
      </TableRow>
    </React.Fragment>
  );
}

export default function EducationFormTable() {
    const [selected] = React.useState([]);
    const [rows, setRows] = React.useState([{}]);

    const handleClickAdd = () => {
      setRows((rows) => [...rows, {isNew: true}]);
    };

    React.useEffect(() => {
    fetch(global.config.conf.address.denis + 'EducationForm')
        .then((response) => response.json())
        .then((json) => setRows(json))
        .catch(() => console.log('err'))},[]);
  return (
    <Box>
    <EnhancedTableToolbar numSelected={selected.length} />
    <Button color="primary" startIcon={<AddIcon />} onClick={handleClickAdd}>
    {global.config.conf.addRecord[window.localStorage.getItem("lang")]}
    </Button>
    <TableContainer component={Paper}>
      <Table aria-label="collapsible table">
        <TableHead>
          <TableRow>
            <TableCell align="center" >{global.config.conf.name[window.localStorage.getItem("lang")]}</TableCell>
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