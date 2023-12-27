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
            {global.config.conf.students[window.localStorage.getItem("lang")]}
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
  const [open, setOpen] = React.useState(false);
  const [edit, setEdit] = React.useState(true);
  const [editRequest] = React.useState(true);
  const [editSave, setEditSave] = React.useState(global.config.conf.edit[window.localStorage.getItem("lang")]);
  const [requests, setRequests] = React.useState([row.requests]);
  const [groups, setGroups] = React.useState([row.groups]);

  const handleDelete = (id) =>
  {
    console.log(id);
    axios.delete(global.config.conf.address.denis + 'Student/'+id);
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
          row.email = "blablabla";
          row.phone = "blablabla";
          delete row.isNew;
          axios.post(global.config.conf.address.denis + 'Student', row)
        }
        else
          axios.put(global.config.conf.address.denis + 'Student/'+row.id, row);

        console.log(row);
    }
    console.log("test");    
    setEdit(!edit);
  }
  
  React.useEffect(() => {
    fetch(global.config.conf.address.denis + 'Request')
        .then((response) => response.json())
        .then((json) => setRequests(json))
        .catch(() => console.log())},[]);

  React.useEffect(() => {
     fetch(global.config.conf.address.denis + 'Group')
        .then((response) => response.json())
        .then((json) => setGroups(json))
        .catch(() => console.log())},[]);

  const handleChandeRequests = (id) => {
    let request = requests.filter(x => x.id === id[1])[0];
    if(row?.requests == null || row?.requests === undefined)
      row.requests = [];  
    if (row?.requests.indexOf(request) === -1)
      setRow(row?.requests.push(request));
    else
      setRow(row?.requests.splice(row?.requests.indexOf(request), 1));
  }

  const handleChandeGroups = (id) => {
    let group = groups.filter(x => x.id === id[1])[0];
    if(row?.groups === null || row?.groups === undefined)
      row.groups = [];  
    if (row?.groups.indexOf(group) === -1)
      setRow(row?.groups.push(group));
    else
      setRow(row?.groups.splice(row?.groups.indexOf(group), 1));
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
        <TableCell component="th" scope="row" sx={{ m: 1, width: 450 }}>
          <Input value={row?.fullName} readOnly={edit} onChange={(e) => setRow(row.fullName = e.target.value)}/>
        </TableCell>
        <TableCell align="right" type="date" sx={{ m: 1, width: 111 }}><Input value={row?.birthDate} readOnly={edit} onChange={(e) => setRow(row.birthDate = e.target.value)} sx={{ m: 1, width: 110 }}/></TableCell>
        <TableCell align="right" sx={{ m: 1, width: 150 }}><Input value={row?.snils} readOnly={edit} onChange={(e) => setRow(row.snils = e.target.value)}sx={{ m: 1, width: 140 }}/></TableCell>
        <TableCell align="right" sx={{ m: 1, width: 70 }}><Input value={row?.documentSeries} readOnly={edit} onChange={(e) => setRow(row.documentSeries = e.target.value)} sx={{ m: 1, width: 69 }}/></TableCell>
        <TableCell align="right" sx={{ m: 1, width: 130 }}><Input value={row?.documentNumber} readOnly={edit} onChange={(e) => setRow(row.documentNumber = e.target.value)} sx={{ m: 1, width: 129 }}/></TableCell>
        <TableCell align="right" sx={{ m: 1, width: 70 }}><Input value={row?.nationality} readOnly={edit} onChange={(e) => setRow(row.nationality = e.target.value)} sx={{ m: 1, width: 60 }}/></TableCell>
        <TableCell align="right" sx={{ m: 1, width: 70 }}>
          <div>
            <FormControl sx={{ m: 1, width: 160}}>
              <Select
              labelId="demo-multiple-checkbox-label"
              id="demo-multiple-checkbox"
              multiple
              value={[row?.requests]}
              onChange={(e) => handleChandeRequests(e.target.value)}
              renderValue={() => row?.requests?.map(x => x.fullName)?.join(', ')}            
              MenuProps={MenuProps}
              sx={{height: 36}}
              readOnly={edit}
              >
              {requests.map((request) => (
                <MenuItem key={request?.id} value={request?.id}>
                  <Checkbox checked={row?.requests?.indexOf(request) > -1} />
                  <ListItemText primary={[request?.fullName, request?.id]} />
                </MenuItem>
              ))}
              </Select>
            </FormControl>
          </div>
        </TableCell>
        <TableCell align="right" sx={{ m: 1, width: 70 }}>
          <div>
            <FormControl sx={{ m: 1, width: 160}}>
              <Select
              labelId="demo-multiple-checkbox-label"
              id="demo-multiple-checkbox"
              multiple
              value={[row?.groups]}
              onChange={(e) => handleChandeGroups(e.target.value)}
              renderValue={() => row?.groups?.map(x => x.name)?.join(', ')}            
              MenuProps={MenuProps}
              sx={{height: 36}}
              readOnly={edit}
              >
              {groups.map((group) => (
                <MenuItem key={group?.id} value={group?.id}>
                  <Checkbox checked={row?.groups?.indexOf(group) > -1} />
                  <ListItemText primary={[group?.name, ' ',group?.id]} />
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
              {global.config.conf.delete[window.localStorage.getItem("lang")]}
             </Button>
          </Box>
        </td>
      </TableRow>
      <TableRow>
        <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box sx={{ margin: 1 }}>
              <Typography variant="h6" gutterBottom component="div">
              {global.config.conf.requests[window.localStorage.getItem("lang")]}
              </Typography>
              <Table size="small" aria-label="purchases">
                <TableHead>
                  <TableRow>
                    <TableCell>{global.config.conf.eduProgramId[window.localStorage.getItem("lang")]}</TableCell>
                    <TableCell>{global.config.conf.eduProgramName[window.localStorage.getItem("lang")]}</TableCell>
                    <TableCell>{global.config.conf.interview[window.localStorage.getItem("lang")]}</TableCell>
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
              {global.config.conf.groups[window.localStorage.getItem("lang")]}
              </Typography>
              <Table size="small" aria-label="purchases">
                <TableHead>
                  <TableRow>
                    <TableCell>{global.config.conf.name[window.localStorage.getItem("lang")]}</TableCell>
                    <TableCell>{global.config.conf.eduProgramName[window.localStorage.getItem("lang")]}</TableCell>
                    <TableCell>{global.config.conf.startDate[window.localStorage.getItem("lang")]}</TableCell>
                    <TableCell>{global.config.conf.endDate[window.localStorage.getItem("lang")]}</TableCell>
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

export default function StudentTable() {
    const [selected] = React.useState([]);
    const [rows, setRows] = React.useState([{}]);

    const handleClickAdd = () => {
      setRows((rows) => [...rows, {isNew: true}]);
    };

    React.useEffect(() => {
    fetch(global.config.conf.address.denis + 'Student')
        .then((response) => response.json())
        .then((json) => setRows(json))
        .catch(() => console.log('err'))},[]);
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
            <TableCell sx={{ m: 1, width: 450 }}>{global.config.conf.fullName[window.localStorage.getItem("lang")]}</TableCell>
            <TableCell align="right" sx={{ m: 1, width: 111 }}>{global.config.conf.birthDate[window.localStorage.getItem("lang")]}</TableCell>
            <TableCell align="right">{global.config.conf.snils[window.localStorage.getItem("lang")]}</TableCell>
            <TableCell align="right">{global.config.conf.docNumber[window.localStorage.getItem("lang")]}</TableCell>
            <TableCell align="right">{global.config.conf.docSeries[window.localStorage.getItem("lang")]}</TableCell>
            <TableCell align="right">{global.config.conf.nationality[window.localStorage.getItem("lang")]}</TableCell>
            <TableCell align="right">{global.config.conf.requests[window.localStorage.getItem("lang")]}</TableCell>
            <TableCell align="right">{global.config.conf.groups[window.localStorage.getItem("lang")]}</TableCell>
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