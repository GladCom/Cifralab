import * as React from "react";
import PropTypes from "prop-types";
import Box from "@mui/material/Box";
import Collapse from "@mui/material/Collapse";
import IconButton from "@mui/material/IconButton";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import { TablePagination } from "@mui/material";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import Typography from "@mui/material/Typography";
import Paper from "@mui/material/Paper";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import KeyboardArrowUpIcon from "@mui/icons-material/KeyboardArrowUp";
import TableRow from "@mui/material/TableRow";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import TableSortLabel from "@mui/material/TableSortLabel";
import Toolbar from "@mui/material/Toolbar";
import Checkbox from "@mui/material/Checkbox";
import Tooltip from "@mui/material/Tooltip";
import FormControlLabel from "@mui/material/FormControlLabel";
import Switch from "@mui/material/Switch";
import DeleteIcon from "@mui/icons-material/Delete";
import FilterListIcon from "@mui/icons-material/FilterList";
import StudentCard from "../common/StudentCard.jsx";
import Input from "@mui/joy/Input";
import { visuallyHidden } from "@mui/utils";
import { alpha } from "@mui/material/styles";
import {
  GridRowModes,
  DataGrid,
  GridToolbarContainer,
  GridToolbarExport,
  GridActionsCellItem,
  GridRowEditStopReasons,
} from "@mui/x-data-grid";
import axios from "axios";
import style from "./style/Tables.css"

function EnhancedTableToolbar(props) {
  const { numSelected } = props;

  return (
    <Toolbar
      sx={{
        pl: { sm: 2 },
        pr: { xs: 1, sm: 1 },
        ...(numSelected > 0 && {
          bgcolor: (theme) =>
            alpha(
              theme.palette.primary.main,
              theme.palette.action.activatedOpacity
            ),
        }),
      }}
    >
      {numSelected > 0 ? (
        <Typography
          sx={{ flex: "1 1 100%" }}
          color="inherit"
          variant="subtitle1"
          component="div"
        >
          {numSelected} selected
        </Typography>
      ) : (
        <Typography
          sx={{ flex: "1 1 100%" }}
          variant="h6"
          id="tableTitle"
          component="div"
        >
          Requests
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
  const [isNew, setIsNew] = React.useState(true);
  const [Row, setRow] = React.useState({});
  const [open, setOpen] = React.useState(false);
  const [edit, setEdit] = React.useState(true);
  const [editSave, setEditSave] = React.useState("Edit");
  const [birthDate, setBirthDate] = React.useState(row?.birthDate);

  const handleDelete = (id) => {
    console.log(id);
    axios.delete("http://localhost:5137/Request/" + id);
    window.location.reload();
  };

  const handleEdit = (row) => {
    console.log(isNew);
    if (edit) setEditSave("Save");
    else {
      setEditSave("Edit");

      axios.post("http://localhost:5137/Request", row);
      console.log(row);
      setIsNew(false);
    }
    console.log("test");
    setEdit(!edit);
  };

  return (
    <React.Fragment>
      <TableRow sx={{ "& > *": { borderBottom: "unset" } }}>
        <TableCell></TableCell>
        <TableCell component="th" scope="row">
          <Input
            value={row?.fullName}
            readOnly={edit}
            onChange={(e) => setRow((row.fullName = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.birthDate}
            readOnly={edit}
            onChange={(e) => setRow((row.birthDate = e.target.value))}
            width={180}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.educationProgram}
            readOnly={edit}
            onChange={(e) => setRow((row.educationProgram = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.entranceExamination}
            readOnly={edit}
            onChange={(e) => setRow((row.entranceExamination = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.interview}
            readOnly={edit}
            onChange={(e) => setRow((row.interview = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.email}
            readOnly={edit}
            onChange={(e) => setRow((row.email = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.phone}
            readOnly={edit}
            onChange={(e) => setRow((row.phone = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.createdAt}
            readOnly={edit}
            onChange={(e) => setRow((row.createdAt = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.studentEducation}
            readOnly={edit}
            onChange={(e) => setRow((row.studentEducation = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.studentStatus}
            readOnly={edit}
            onChange={(e) => setRow((row.studentStatus = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.financingType}
            readOnly={edit}
            onChange={(e) => setRow((row.financingType = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.orderOfAdmission}
            readOnly={edit}
            onChange={(e) => setRow((row.orderOfAdmission = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.orderOfExpulsion}
            readOnly={edit}
            onChange={(e) => setRow((row.orderOfExpulsion = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.scopeOfActivityLv1}
            readOnly={edit}
            onChange={(e) => setRow((row.scopeOfActivityLv1 = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.scopeOfActivityLv2}
            readOnly={edit}
            onChange={(e) => setRow((row.scopeOfActivityLv2 = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.disability}
            readOnly={edit}
            onChange={(e) => setRow((row.disability = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.jobResult}
            readOnly={edit}
            onChange={(e) => setRow((row.jobResult = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.speciality}
            readOnly={edit}
            onChange={(e) => setRow((row.speciality = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.jobCV}
            readOnly={edit}
            onChange={(e) => setRow((row.jobCV = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.address}
            readOnly={edit}
            onChange={(e) => setRow((row.address = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.educationContract}
            readOnly={edit}
            onChange={(e) => setRow((row.educationContract = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.documentType}
            readOnly={edit}
            onChange={(e) => setRow((row.documentType = e.target.value))}
          />
        </TableCell>
        <TableCell align="center">
          <Input
            value={row?.student}
            readOnly={edit}
            onChange={(e) => setRow((row.student = e.target.value))}
          />
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
            <Button
              size="sm"
              variant="soft"
              color="danger"
              onClick={(e) => handleDelete(row?.id)}
            >
              Delete
            </Button>
          </Box>
        </td>
      </TableRow>
    </React.Fragment>
  );
}

export default function RequestTable() {
  const [selected, setSelected] = React.useState([]);
  const [rows, setRows] = React.useState([{}]);
  const handleClickAdd = () => {
    console.log(111);
    setRows((rows) => [...rows, {}]);
  };
  React.useEffect(() => {
    fetch("http://localhost:5137/Request")
      .then((response) => response.json())
      .then((json) => setRows(json))
      .catch(() => console.log(12345));
  }, []);
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
              <TableCell align="center">Full Name</TableCell>
              <TableCell align="center">Birth Date</TableCell>
              <TableCell align="center">Education Program</TableCell>
              <TableCell align="center">Entrance Examination</TableCell>
              <TableCell align="center">Interview</TableCell>
              <TableCell align="center">Email</TableCell>
              <TableCell align="center">Phone</TableCell>
              <TableCell align="center">Created At</TableCell>
              <TableCell align="center">Student Education</TableCell>
              <TableCell align="center">Student Status</TableCell>
              <TableCell align="center">Financing Type</TableCell>
              <TableCell align="center">Order Of Admission</TableCell>
              <TableCell align="center">Order Of Expulsion</TableCell>
              <TableCell align="center">Scope Of Activity Lv.1</TableCell>
              <TableCell align="center">Scope Of Activity Lv.2</TableCell>
              <TableCell align="center">Disability</TableCell>
              <TableCell align="center">Job Result</TableCell>
              <TableCell align="center">Speciality</TableCell>
              <TableCell align="center">JobCV</TableCell>
              <TableCell align="center">Address</TableCell>
              <TableCell align="center">Education Contract</TableCell>
              <TableCell align="center">Document Type</TableCell>
              <TableCell align="center">Student</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {rows?.map((row) => (
              <Row key={row?.id} row={row} isNew={row.isNew} />
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
}
