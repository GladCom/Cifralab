import * as React from "react";
import Box from "@mui/material/Box";
import IconButton from "@mui/material/IconButton";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import Typography from "@mui/material/Typography";
import Paper from "@mui/material/Paper";
import TableRow from "@mui/material/TableRow";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import Toolbar from "@mui/material/Toolbar";
import Tooltip from "@mui/material/Tooltip";
import DeleteIcon from "@mui/icons-material/Delete";
import FilterListIcon from "@mui/icons-material/FilterList";
import Input from "@mui/joy/Input";
import { alpha } from "@mui/material/styles";
import axios from "axios";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import ListItemText from "@mui/material/ListItemText";

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
  const [edit, setEdit] = React.useState(true);
  const [editSave, setEditSave] = React.useState(global.config.conf.edit[window.localStorage.getItem("lang")]);
  const [educationForms, setEducationFroms] = React.useState([]);
  const [educationTypes, setEducationTypes] = React.useState([]);

  const handleDelete = (id) => {
    axios.delete(global.config.conf.address.denis + "EducationProgram/" + id);
    window.location.reload();
  };

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
          axios.post(global.config.conf.address.denis + 'EducationProgram', row)
        }
        else
          axios.put(global.config.conf.address.denis + 'EducationProgram/'+row.id, row);

      console.log(row);
    }
    setEdit(!edit);
  };

  React.useEffect(() => {
    fetch(global.config.conf.address.denis + "EducationForm")
      .then((response) => response.json())
      .then((json) => setEducationFroms(json))
      .catch(() => console.log("err"));
  }, []);

  React.useEffect(() => {
    fetch(global.config.conf.address.denis + "EducationType")
      .then((response) => response.json())
      .then((json) => setEducationTypes(json))
      .catch(() => console.log("err"));
  }, []);

  return (
    <React.Fragment>
      <TableRow sx={{ "& > *": { borderBottom: "unset" } }}>
        <TableCell align="center" component="th" scope="row" title={row?.name}>
          <Input
            value={row?.name}
            readOnly={edit}
            sx={{ height: 36, width: "20rem" }}
            onChange={(e) => setRow((row.name = e.target.value))}
          />
        </TableCell>
        <TableCell align="center" title={row?.hoursCount}>
          <Input
            value={row?.hoursCount}
            readOnly={edit}
            sx={{ height: 36, width: "8rem" }}
            onChange={(e) => setRow((row.hoursCount = e.target.value))}
          />
        </TableCell>
        <TableCell align="center" title={row.educationFormId}>
          <div>
            <FormControl>
              <Select
              labelId="demo-multiple-checkbox-label"
              id="demo-multiple-checkbox"
              value={row.educationFormId}
              onChange={(e) => setRow(row.educationFormId = e.target.value)}
              renderValue={() => educationForms?.filter(x => x.id === row.educationFormId)[0]?.name}
              MenuProps={MenuProps}
              sx={{height: 36}}
              readOnly={edit}
              >
                {educationForms.map((form) => (
                  <MenuItem key={form?.id} value={form?.id}>
                    <ListItemText primary={form?.name} />
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </div>
        </TableCell>
        <TableCell align="center" title={row.educationTypeId}>
          <div>
            <FormControl>
              <Select
              labelId="demo-multiple-checkbox-label"
              id="demo-multiple-checkbox"
              value={row.educationTypeId}
              onChange={(e) => setRow(row.educationTypeId = e.target.value)}
              renderValue={() => educationTypes?.filter(x => x.id === row.educationTypeId)[0]?.name}
              MenuProps={MenuProps}
              sx={{height: 36}}
              readOnly={edit}
              >
                {educationTypes.map((type) => (
                  <MenuItem key={type?.id} value={type?.id}>
                    <ListItemText primary={type?.name} />
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </div>
        </TableCell>
        <TableCell align="center" title={row?.isNetworkProgram}>
          <div>
            <FormControl>
              <Select
                labelId="demo-multiple-checkbox-label"
                id="demo-multiple-checkbox"
                value={row.isNetworkProgram}
                onChange={(e) => setRow((row.isNetworkProgram = e.target.value))}
                MenuProps={MenuProps}
                sx={{ height: 36, width: "7rem" }}
                readOnly={edit}
              >
                <MenuItem value="true">true</MenuItem>
                <MenuItem value="false">false</MenuItem>
              </Select>
            </FormControl>
          </div>
        </TableCell>
        <TableCell align="center" title={row?.isDOTProgram}>
          <div>
            <FormControl>
              <Select
                labelId="demo-multiple-checkbox-label"
                id="demo-multiple-checkbox"
                value={row.isDOTProgram}
                onChange={(e) => setRow((row.isDOTProgram = e.target.value))}
                MenuProps={MenuProps}
                sx={{ height: 36, width: "7rem" }}
                readOnly={edit}
              >
                <MenuItem value="true">true</MenuItem>
                <MenuItem value="false">false</MenuItem>
              </Select>
            </FormControl>
          </div>
        </TableCell>
        <TableCell align="center" title={row?.isModularProgram}>
          <div>
            <FormControl>
              <Select
                labelId="demo-multiple-checkbox-label"
                id="demo-multiple-checkbox"
                value={row.isModularProgram}
                onChange={(e) =>
                  setRow((row.isModularProgram = e.target.value))
                }
                MenuProps={MenuProps}
                sx={{ height: 36, width: "7rem" }}
                readOnly={edit}
              >
                <MenuItem value="true">true</MenuItem>
                <MenuItem value="false">false</MenuItem>
              </Select>
            </FormControl>
          </div>
        </TableCell>
        <TableCell align="center" title={row?.isCollegeProgram}>
          <div>
            <FormControl>
              <Select
                labelId="demo-multiple-checkbox-label"
                id="demo-multiple-checkbox"
                value={row.isCollegeProgram}
                onChange={(e) =>
                  setRow((row.isCollegeProgram = e.target.value))
                }
                MenuProps={MenuProps}
                sx={{ height: 36, width: "7rem" }}
                readOnly={edit}
              >
                <MenuItem value="true">true</MenuItem>
                <MenuItem value="false">false</MenuItem>
              </Select>
            </FormControl>
          </div>
        </TableCell>
        <td>
          <Box sx={{ display: "flex", gap: 1 }}>
            <Button
              size="sm"
              variant="plain"
              color="neutral"
              onClick={() => handleEdit(row)}
            >
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

export default function EducationProgramTable() {
    const [selected] = React.useState([]);
    const [rows, setRows] = React.useState([{}]);

  const handleClickAdd = () => {
    setRows((rows) => [...rows, { isNew: true }]);
  };

  React.useEffect(() => {
    fetch(global.config.conf.address.denis + "/EducationProgram")
      .then((response) => response.json())
      .then((json) => setRows(json))
      .catch(() => console.log("err"));
  }, []);
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
            <TableCell sx={{ m: 1, width: "auto" }}>{global.config.conf.name[window.localStorage.getItem("lang")]}</TableCell>
            <TableCell sx={{ m: 1, width: "auto" }}>{global.config.conf.hoursCount[window.localStorage.getItem("lang")]}</TableCell>
            <TableCell >{global.config.conf.educationForm[window.localStorage.getItem("lang")]}</TableCell>
            <TableCell >{global.config.conf.educationForm[window.localStorage.getItem("lang")]}</TableCell>
            <TableCell >isNetworkProgram</TableCell>
            <TableCell >isDOTProgram</TableCell>
            <TableCell >isModularProgram</TableCell>
            <TableCell >isCollegeProgram</TableCell>
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
