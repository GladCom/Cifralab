import Info from './Info';
import EditableInfo from './EditableInfo';
import Edit from './Edit';
import Form from './Form';
import Filter from './Filter';
import Modal from './Modal';

const renderByMode = {
  info: Info,
  editableInfo: EditableInfo,
  form: Form,
  filter: Filter,
  edit: Edit,
  modal: Modal,
};

export default renderByMode;
