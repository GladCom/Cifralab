import * as React from 'react';
import Card from '@mui/joy/Card';
import CardActions from '@mui/joy/CardActions';
import CardContent from '@mui/joy/CardContent';
import Checkbox from '@mui/joy/Checkbox';
import Divider from '@mui/joy/Divider';
import FormControl from '@mui/joy/FormControl';
import FormLabel from '@mui/joy/FormLabel';
import Input from '@mui/joy/Input';
import Typography from '@mui/joy/Typography';
import Button from '@mui/joy/Button';
import InfoOutlined from '@mui/icons-material/InfoOutlined';
import CreditCardIcon from '@mui/icons-material/CreditCard';
import Modal from '@mui/material/Modal';
import AddIcon from '@mui/icons-material/Add';
import FullFeaturedCrudGrid from './StudentGroupsDataGrid.jsx';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/DeleteOutlined';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Close';
import Box from '@mui/material/Box';
import {
  GridRowModes,
  DataGrid,
  GridToolbarContainer,
  GridActionsCellItem,
  GridRowEditStopReasons,
} from '@mui/x-data-grid';
import { randomId } from '@mui/x-data-grid-generator';

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

function EditToolbar(props) {
  const { setRows, setRowModesModel } = props;

  const handleClick = () => {
    const id = randomId();
    setRows((oldRows) => [...oldRows, { id, name: '', age: '', isNew: true }]);
    setRowModesModel((oldModel) => ({
      ...oldModel,
      [id]: { mode: GridRowModes.Edit, fieldToFocus: 'name' },
    }));
  };

  return (
    <GridToolbarContainer>
      <Button color="primary" startIcon={<AddIcon />} onClick={handleClick}>
        Add record
      </Button>
    </GridToolbarContainer>
  );
}

export default function StudentCard() {
  const [rows, setRows] = React.useState([]);
  const [rowModesModel, setRowModesModel] = React.useState({});

  const handleRowEditStop = (params, event) => {
    if (params.reason === GridRowEditStopReasons.rowFocusOut) {
      event.defaultMuiPrevented = true;
    }
  };

  const handleEditClick = (id) => () => {
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.Edit } });
  };

  const handleSaveClick = (id) => () => {
    student.groups.push(rows[id]);
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.View } });
  };

  const handleDeleteClick = (id) => () => {
    setRows(rows.filter((row) => row.id !== id));
  };

  const handleCancelClick = (id) => () => {
    setRowModesModel({
      ...rowModesModel,
      [id]: { mode: GridRowModes.View, ignoreModifications: true },
    });

    const editedRow = rows.find((row) => row.id === id);
    if (editedRow.isNew) {
      setRows(rows.filter((row) => row.id !== id));
    }
  };

  const processRowUpdate = (newRow) => {
    const updatedRow = { ...newRow, isNew: false };
    setRows(rows.map((row) => (row.id === newRow.id ? updatedRow : row)));
    return updatedRow;
  };

  const handleRowModesModelChange = (newRowModesModel) => {
    setRowModesModel(newRowModesModel);
  };
  const [open, setOpen] = React.useState(false);
  const [student, setStudent] = React.useState({});
  student.groups = [];
  student.requests = [];
  const handleOpen = () => setOpen(true);
  const cancelChanges = () => setOpen(false);
  const handleClose = () => 
  {
    student.groups.push({id:1});
    console.log(student.groups[1]);
    console.log(student?.fullName)
    setOpen(false);
  }

  const columns = [
    { field: 'name', headerName: 'Name', width: 380, editable: true },
    {
      field: 'educationProgramId',
      headerName: 'EducationProgramId',
      type: 'number',
      width: 380,
      align: 'left',
      headerAlign: 'left',
      editable: true,
    },
    {
      field: 'educationProgram?.name',
      headerName: 'Education Program Name',
      type: 'string',
      width: 380,
      editable: true,
    },
    {
      field: 'actions',
      type: 'actions',
      headerName: 'Actions',
      width: 100,
      cellClassName: 'actions',
      getActions: ({ id }) => {
        const isInEditMode = rowModesModel[id]?.mode === GridRowModes.Edit;

        if (isInEditMode) {
          return [
            <GridActionsCellItem
              icon={<SaveIcon />}
              label="Save"
              sx={{
                color: 'primary.main',
              }}
              onClick={handleSaveClick(id)}
            />,
            <GridActionsCellItem
              icon={<CancelIcon />}
              label="Cancel"
              className="textPrimary"
              onClick={handleCancelClick(id)}
              color="inherit"
            />,
          ];
        }

        return [
          <GridActionsCellItem
            icon={<EditIcon />}
            label="Edit"
            className="textPrimary"
            onClick={handleEditClick(id)}
            color="inherit"
          />,
          <GridActionsCellItem
            icon={<DeleteIcon />}
            label="Delete"
            onClick={handleDeleteClick(id)}
            color="inherit"
          />,
        ];
      },
    },
  ];

  return (
    <div>
      <Button color="primary" startIcon={<AddIcon />} onClick={handleOpen}>Add student</Button>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
            <Card
      variant="outlined"
      sx={{
        maxHeight: 'max-content',
        maxWidth: '100%',
        mx: 'auto',
        // to make the demo resizable
        overflow: 'auto',
        resize: 'horizontal',
      }}
    >
      <Typography level="title-lg" startDecorator={<InfoOutlined />}>
        Add new student
      </Typography>
      <Divider inset="none" />
      <CardContent
        sx={{
          display: 'grid',
          gridTemplateColumns: 'repeat(2, minmax(80px, 1fr))',
          gap: 1.5,
        }}
      >
        <FormControl sx={{ gridColumn: '1/-1' }}>
          <FormLabel>Student name</FormLabel>
          <Input endDecorator={<CreditCardIcon />} onChangeCapture={(e) => student.fullName = (e.target.value)}/>
        </FormControl>
        <FormControl>
          <FormLabel>Birthdate</FormLabel>
          <Input endDecorator={<CreditCardIcon />} onChangeCapture={(e) => student.birthDate = (e.target.value)}/>
        </FormControl>
        <FormControl>  
          <FormLabel>SNILS</FormLabel>
          <Input endDecorator={<InfoOutlined />} onChangeCapture={(e) => student.snils = (e.target.value)}/>
        </FormControl>
        <FormControl>
          <FormLabel>Document Series</FormLabel>
          <Input endDecorator={<InfoOutlined />} onChangeCapture={(e) => student.documentSeries = (e.target.value)}/>
        </FormControl>
        <FormControl>
          <FormLabel>Document Number</FormLabel>
          <Input endDecorator={<InfoOutlined />} onChangeCapture={(e) => student.documentNumber = (e.target.value)}/>
        </FormControl>
        <FormControl>
          <FormLabel>Nationality</FormLabel>
          <Input endDecorator={<InfoOutlined />} onChangeCapture={(e) => student.nationality = (e.target.value)}/>
        </FormControl>
        <FormControl>
          <FormLabel>Full name document</FormLabel>
          <Input placeholder="Enter full name document" onChangeCapture={(e) => student.fullNameDocument = (e.target.value)}/>
        </FormControl>
        <FormControl sx={{ gridColumn: '1/-1' }}>
          <FormLabel>Groups</FormLabel>
          <Box
      sx={{
        height: 200,
        width: '100%',
        '& .actions': {
          color: 'text.secondary',
        },
        '& .textPrimary': {
          color: 'text.primary',
        },
      }}
    >
      <DataGrid
        rows={rows}
        columns={columns}
        editMode="row"
        rowModesModel={rowModesModel}
        onRowModesModelChange={handleRowModesModelChange}
        onRowEditStop={handleRowEditStop}
        processRowUpdate={processRowUpdate}
        slots={{
          toolbar: EditToolbar,
        }}
        slotProps={{
          toolbar: { setRows, setRowModesModel },
        }}
        initialState={{
          pagination: {
            paginationModel: {
              pageSize: 1,
            },
          },
        }}
        pageSizeOptions={[1]}
      />
    </Box>
        </FormControl>
        <FormControl sx={{ gridColumn: '1/-1' }}>
          <FormLabel>Requests</FormLabel>
          <FullFeaturedCrudGrid onChangeCapture={(e) => student.gruops = (e.target.value)}/>
        </FormControl>
        <Checkbox label="Save card" sx={{ gridColumn: '1/-1', my: 1 }} />
        <CardActions >
          <Button variant="solid" color="primary" onClick={handleClose}>
            Save
          </Button>
        </CardActions>
        <CardActions >
          <Button variant="solid" color="primary" onClick={cancelChanges}>
            Cancel
          </Button>
        </CardActions>
      </CardContent>
    </Card>
      </Modal>
    </div>
  );
}