import * as React from "react";
import Box from "@mui/material/Box";
import Collapse from "@mui/material/Collapse";
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
          Программы обучения
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
  const [editRequest, setEditRequest] = React.useState(true);
  const [editSave, setEditSave] = React.useState("Изменить");
  const [educationForms, setEducationFroms] = React.useState([]);
  const [educationTypes, setEducationTypes] = React.useState([]);

  const handleDelete = (id) => {
    axios.delete("http://localhost:5137/EducationProgram/" + id);
    window.location.reload();
  };

  const handleEdit = (row) => {
    console.log(isNew);
    if (edit) setEditSave("Сохранить");
    else {
      setEditSave("Изменить");
      if (row?.isNew) {
        delete row.isNew;
        axios.post("http://localhost:5137/EducationProgram", row);
      } else axios.put("http://localhost:5137/EducationProgram/" + row.id, row);

      console.log(row);
    }
    setEdit(!edit);
  };

  React.useEffect(() => {
    fetch("http://localhost:5137/EducationForm")
      .then((response) => response.json())
      .then((json) => setEducationFroms(json))
      .catch(() => console.log("err"));
  }, []);

  React.useEffect(() => {
    fetch("http://localhost:5137/EducationType")
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
                onChange={(e) => setRow((row.educationFormId = e.target.value))}
                renderValue={() =>
                  educationForms?.filter((x) => x.id == row.educationFormId)[0]
                    ?.name
                }
                MenuProps={MenuProps}
                sx={{ height: 36, width: "12rem" }}
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
                onChange={(e) => setRow((row.educationTypeId = e.target.value))}
                renderValue={() =>
                  educationTypes?.filter((x) => x.id == row.educationTypeId)[0]
                    ?.name
                }
                MenuProps={MenuProps}
                sx={{ height: 36, width: "12rem" }}
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
          <Input
            value={row?.isNetworkProgram}
            readOnly={edit}
            sx={{ height: 36, width: "8rem" }}
            onChange={(e) => setRow((row.isNetworkProgram = e.target.value))}
          />
        </TableCell>
        <TableCell align="center" title={row?.isDOTProgram}>
          <Input
            value={row?.isDOTProgram}
            readOnly={edit}
            sx={{ height: 36, width: "8rem" }}
            onChange={(e) => setRow((row.isDOTProgram = e.target.value))}
          />
        </TableCell>
        <TableCell align="center" title={row?.isModularProgram}>
          <Input
            value={row?.isModularProgram}
            readOnly={edit}
            sx={{ height: 36, width: "8rem" }}
            onChange={(e) => setRow((row.isModularProgram = e.target.value))}
          />
        </TableCell>
        <TableCell align="center" title={row?.isCollegeProgram}>
          <Input
            value={row?.isCollegeProgram}
            readOnly={edit}
            sx={{ height: 36, width: "8rem" }}
            onChange={(e) => setRow((row.isCollegeProgram = e.target.value))}
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
              Удалить
            </Button>
          </Box>
        </td>
      </TableRow>
    </React.Fragment>
  );
}

export default function EducationProgramTable() {
  const [selected, setSelected] = React.useState([]);
  const [rows, setRows] = React.useState([{}]);

  const handleClickAdd = () => {
    setRows((rows) => [...rows, { isNew: true }]);
  };

  React.useEffect(() => {
    fetch("http://localhost:5137/EducationProgram")
      .then((response) => response.json())
      .then((json) => setRows(json))
      .catch(() => console.log("err"));
  }, []);
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
              <TableCell align="center" sx={{ width: "20rem" }}>
                Наименование
              </TableCell>
              <TableCell align="center" sx={{ width: "10rem" }}>
                Кол-во часов
              </TableCell>
              <TableCell align="center" sx={{ width: "12rem" }}>
                Форма обучения
              </TableCell>
              <TableCell align="center" sx={{ width: "12rem" }}>
                Тип образования
              </TableCell>
              <TableCell align="center" sx={{ width: "8rem" }}>
                Сетевая форма
              </TableCell>
              <TableCell align="center" sx={{ width: "8rem" }}>
                ДОТ программа
              </TableCell>
              <TableCell align="center" sx={{ width: "8rem" }}>
                Модульная программа
              </TableCell>
              <TableCell align="center" sx={{ width: "8rem" }}>
                Колледжная программа
              </TableCell>
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
