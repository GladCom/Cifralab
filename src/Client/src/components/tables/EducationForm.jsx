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

  const handleDelete = (id) =>
  {
    axios.delete('http://localhost:5137/EducationProgram/'+id);
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
          delete row.isNew;
          axios.post('http://localhost:5137/EducationProgram', row)
        }
        else
          axios.put('http://localhost:5137/EducationProgram/'+row.id, row);

        console.log(row);
    }  
    setEdit(!edit);
  }

  return (
    <React.Fragment>
      <TableRow sx={{ '& > *': { borderBottom: 'unset' } }}>
        <TableCell component="th" scope="row" sx={{ m: 1, width: 450 }}>
          <Input value={row?.name} readOnly={edit} onChange={(e) => setRow(row.name = e.target.value)}/>
        </TableCell>
        <TableCell  >
            <Input value={row?.hoursCount} readOnly={edit} onChange={(e) => setRow(row.hoursCount = e.target.value)}/>
        </TableCell>
        <TableCell sx={{ m: 1, width: 150 }}>
            <Input value={row?.isNetworkProgram} readOnly={edit} onChange={(e) => setRow(row.isNetworkProgram = e.target.value)}sx={{ m: 1, width: 140 }}/>
        </TableCell>
        <TableCell  sx={{ m: 1, width: 70 }}>
            <Input value={row?.isDOTProgram} readOnly={edit} onChange={(e) => setRow(row.isDOTProgram = e.target.value)} sx={{ m: 1, width: 69 }}/>
        </TableCell>
        <TableCell  sx={{ m: 1, width: 130 }}>
            <Input value={row?.isModularProgram} readOnly={edit} onChange={(e) => setRow(row.isModularProgram = e.target.value)} sx={{ m: 1, width: 129 }}/>
        </TableCell>
        <TableCell  sx={{ m: 1, width: 70 }}>
            <Input value={row?.isCollegeProgram} readOnly={edit} onChange={(e) => setRow(row.isCollegeProgram = e.target.value)} sx={{ m: 1, width: 60 }}/>
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

export default function EducationProgramTable() {
    const [selected, setSelected] = React.useState([]);
    const [rows, setRows] = React.useState([{}]);

    const handleClickAdd = () => {
      setRows((rows) => [...rows, {isNew: true}]);
    };

    React.useEffect(() => {
    fetch('http://localhost:5137/EducationProgram')
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
            <TableCell width="50%">Name</TableCell>
            <TableCell >Hours Count</TableCell>
            <TableCell >isNetworkProgram</TableCell>
            <TableCell >isDOTProgram</TableCell>
            <TableCell >isModularProgram</TableCell>
            <TableCell >isCollegeProgram</TableCell>
          </TableRow>q
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