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
import FullFeaturedCrudGrid from '../common/StudentGroupsDataGrid.jsx';

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

export default function StudentCard() {
  const [open, setOpen] = React.useState(false);
  const [student, setStudent] = React.useState({fullName:1, id:2});
  const [name, setName] = React.useState("");
  const handleOpen = () => setOpen(true);
  const cancelChanges = () => setOpen(false);
  const handleClose = () => 
  {
    setOpen(false);
  }
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
          <Input  endDecorator={<CreditCardIcon />} />
        </FormControl>
        <FormControl>
          <FormLabel>Birthdate</FormLabel>
          <Input endDecorator={<CreditCardIcon />} />
        </FormControl>
        <FormControl>
          <FormLabel>SNILS</FormLabel>
          <Input endDecorator={<InfoOutlined />} />
        </FormControl>
        <FormControl>
          <FormLabel>Document Series</FormLabel>
          <Input endDecorator={<InfoOutlined />} />
        </FormControl>
        <FormControl>
          <FormLabel>Document Number</FormLabel>
          <Input endDecorator={<InfoOutlined />} />
        </FormControl>
        <FormControl>
          <FormLabel>Nationality</FormLabel>
          <Input endDecorator={<InfoOutlined />} />
        </FormControl>
        <FormControl>
          <FormLabel>Full name document</FormLabel>
          <Input placeholder="Enter full name document" />
        </FormControl>
        <FormControl sx={{ gridColumn: '1/-1' }}>
          <FormLabel>Groups</FormLabel>
          <FullFeaturedCrudGrid/>
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