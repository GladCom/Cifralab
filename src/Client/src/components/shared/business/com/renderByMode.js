import Info from './Info.jsx';
import EditableInfo from './EditableInfo.jsx';
import Edit from './Edit.jsx';
import Form from './Form.jsx';
import Filter from './Filter.jsx';
import Modal from './Modal.jsx';

const renderByMode = {
    info: Info,
    editableInfo: EditableInfo,
    form: Form,
    filter: Filter,
    edit: Edit,
    modal: Modal,
};

export default renderByMode;