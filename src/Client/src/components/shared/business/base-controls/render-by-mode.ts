import Info from './info';
import EditableInfo from './editable-info';
import Edit from './edit';
import Form from './form';

const renderByMode = {
  info: Info,
  editableInfo: EditableInfo,
  form: Form,
  edit: Edit,
};

export default renderByMode;
