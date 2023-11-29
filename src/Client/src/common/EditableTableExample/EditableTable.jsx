import React, { useState } from "react";
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
import TableSortLabel from '@mui/material/TableSortLabel';
import Toolbar from '@mui/material/Toolbar';
import Button from '@mui/material/Button';
import FormControl from '@mui/material/FormControl';
import InputLabel from '@mui/material/InputLabel';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import Checkbox from '@mui/material/Checkbox';
import Tooltip from '@mui/material/Tooltip';
import FormControlLabel from '@mui/material/FormControlLabel';
import Switch from '@mui/material/Switch';
import DeleteIcon from '@mui/icons-material/Delete';
import FilterListIcon from '@mui/icons-material/FilterList';
import classNames from "classnames";

const Input = ({
  name,
  error,
  validation,
  childHasError,
  columnDataArr,
  value,
  classes,
  tableName,
  ...props
}) => {
  const [hasError, setError] = useState(false);
  const handleOnChange = e => {
    const hasError = validation(e, columnDataArr);
    if (!hasError) {
      childHasError(true);
      setError(true);
    } else {
      childHasError(false);
      setError(false);
    }
    props.onChange(e);
  };

  return (
    <>
      <div
        className={classNames(
          classes.inputWrapperDiv,
          `inputWrapperDiv${tableName}`
        )}
      >
        <input
          className={classNames(classes.input, `input${tableName}`)}
          name={name}
          value={value || ""}
          onChange={handleOnChange}
        />
        <p className={classNames(classes.error, `error${tableName}`)}>
          {hasError && error}
        </p>
      </div>
    </>
  );
};

const OurSelect = ({
  name,
  value,
  selectMessage,
  options,
  classes,
  tableName,
  ...props
}) => {
  const handleSelect = e => {
    props.onChange(e);
  };
  return (
    <FormControl
      className={classNames(
        classes.selectFormControl,
        `selectFormControl_${tableName}`
      )}
    >
      <InputLabel
        className={classNames(
          classes.selectInputLabel,
          `selectInputLabel_${tableName}`
        )}
        htmlFor={name}
      >
        {selectMessage}
      </InputLabel>
      <Select
        className={classNames(classes.select, `select_${tableName}`)}
        value={value || ""}
        onChange={handleSelect}
        inputProps={{
          name: name,
          id: name
        }}
      >
        {(options || []).map(item => {
          return (
            <MenuItem
              className={classNames(
                classes.selectMenuItem,
                `selectMenutItem_${tableName}`
              )}
              key={item.value}
              value={item.value}
            >
              {item.label}
            </MenuItem>
          );
        })}
      </Select>
    </FormControl>
  );
};
const EditableRow = ({
  fieldsArr = [],
  editData = {},
  allRowsData,
  tableName,
  classes = {},
  editingIndex,
  isEditing,
  selectClasses,
  inputClasses,
  ...props
}) => {
  let initializeObj = {};
  fieldsArr.forEach(item => {
    initializeObj[item.name] = "";
  });
  const [rowHasError, setRowHasError] = useState(false);
  const [rowData, setRowData] = useState(
    editData ? Object.assign({}, initializeObj, editData) : initializeObj
  );
  const handleSave = () => {
    props.handleSave(rowData);
  };
  const handleOnChange = e => {
    const updatedData = Object.assign({}, rowData, {
      [e.target.name]: e.target.value
    });
    setRowData(updatedData);
  };
  const handleCancel = () => {
    if (isEditing) {
      props.handleCancel(editingIndex);
    } else {
      props.handleCancel();
    }
  };
  return (
    <TableRow
      className={classNames(classes.tableBodyRow, `tableBodyRow_${tableName}`)}
    >
      {fieldsArr.map((item, i) => {
        return (
          <TableCell
            className={classNames(
              classes.tableBodyCell,
              `tableBodyCell_${tableName}`
            )}
            key={i}
          >
            {item.type === "select" ? (
              <OurSelect
                tableName={tableName}
                classes={{
                  ...selectClasses
                }}
                name={item.name}
                onChange={handleOnChange}
                options={item.options}
                value={rowData[item.name]}
                childHasError={bool => setRowHasError(bool)}
                error={item.error}
                selectMessage={item.selectMessage}
                validation={item.validation}
              />
            ) : (
              <Input
                columnDataArr={(allRowsData || []).map(
                  obj => obj.rowData[item.name]
                )}
                tableName={tableName}
                classes={{ ...inputClasses }}
                type={item.type}
                name={item.name}
                onChange={handleOnChange}
                value={rowData[item.name]}
                item={item.name}
                childHasError={bool => setRowHasError(bool)}
                error={item.error}
                validation={item.validation}
              />
            )}
          </TableCell>
        );
      })}
      <TableCell
        className={classNames(
          classes.tableBodyCell,
          `tableBodyCell_${tableName}`
        )}
      >
        <Button
          className={classNames(classes.saveBtn, `saveBtn${tableName}`)}
          disabled={rowHasError}
          type="button"
          onClick={handleSave}
        >
          Save
        </Button>

        <Button
          className={classNames(classes.cancelBtn, `cancelBtn${tableName}`)}
          onClick={handleCancel}
        >
          Cancel
        </Button>
      </TableCell>
    </TableRow>
  );
};

const Row = ({
  data,
  handleEditRow,
  classes,
  tableName,
  handleDeleteRow,
  isAdding,
  isEditing
}) => {
  return (
    <TableRow
      className={classNames(classes.tableBodyRow, `tableBodyRow_${tableName}`)}
    >
      {Object.keys(data).map(key => {
        return (
          <TableCell
            className={classNames(
              classes.tableBodyCell,
              `tableBodyCell_${tableName}`
            )}
          >
            {data[key]}
          </TableCell>
        );
      })}
      <TableCell
        className={classNames(
          classes.tableBodyCell,
          `tableBodyCell_${tableName}`
        )}
      >
        <Button
          disabled={isAdding || isEditing}
          className={classNames(classes.editBtn, `editBtn_${tableName}`)}
          onClick={handleEditRow}
        >
          Edit
        </Button>

        <Button
          disabled={isAdding || isEditing}
          className={classNames(classes.deleteBtn, `deleteBtn_${tableName}`)}
          onClick={handleDeleteRow}
        >
          Delete
        </Button>
      </TableCell>
    </TableRow>
  );
};

class EditableTable extends React.Component {
  state = {
    allRowsData: (this.props.defaultData || []).map(item => ({
      isEditing: false,
      rowData: item
    })),
    isAdding: false,
    isEditing: false,
    editingIndex: null
  };

  handleSave = row => {
    if (this.state.isEditing) {
      const arr = this.state.allRowsData.map((item, i) => {
        if (i === this.state.editingIndex) {
          return {
            isEditing: false,
            rowData: row
          };
        } else return item;
      });
      this.setState(
        { allRowsData: arr, editingIndex: null, isEditing: false },
        this.setToParent
      );
    } else {
      this.setState(
        {
          allRowsData: [
            ...this.state.allRowsData,
            { isEditing: false, rowData: row }
          ],
          isAdding: false
        },
        this.setToParent
      );
    }
  };
  setToParent = () => {
    const formatedData = this.state.allRowsData.map(
      ({ rowData }, i) => rowData
    );
    this.props.getData(formatedData);
  };
  handleCancel = index => {
    if (this.state.isEditing) {
      const arr = this.state.allRowsData.map((item, i) => {
        if (i === index) {
          return {
            isEditing: false,
            rowData: item.rowData
          };
        } else return item;
      });
      this.setState({ allRowsData: arr, editingIndex: null, isEditing: false });
    } else {
      this.setState({ isAdding: false });
    }
  };

  handleDeleteRow = index => {
    const arr = this.state.allRowsData.filter((item, i) => i !== index);
    this.setState(
      {
        allRowsData: arr
      },
      this.setToParent
    );
  };
  handleEditRow = index => {
    const arr = this.state.allRowsData.map((item, i) => {
      if (i === index) {
        return {
          isEditing: true,
          rowData: item.rowData
        };
      } else return item;
    });
    this.setState({ allRowsData: arr, editingIndex: index, isEditing: true });
  };

  render() {
    const {
      fieldsArr = [],
      classes = {},
      tableName,
      addRowBtnText,
      initWithoutHead
    } = this.props;
    const { allRowsData = [], isAdding, editingIndex, isEditing } = this.state;
    let headRow = [
      ...fieldsArr.map(item => ({ label: item.label, name: item.name })),
      { label: "Actions", name: "actions" }
    ];
    const showHeader =
      initWithoutHead && !allRowsData.length && !isAdding ? false : true;
    return (
      <>
        <Table className={classNames(classes.table, `table_${tableName}`)}>
          {showHeader && (
            <TableHead className={classNames(classes.tableHead)}>
              <TableRow
                className={classNames(
                  classes.tableHeadRow,
                  `tableHeadRow_${tableName}`
                )}
              >
                {headRow.map(({ label, name }, i) => (
                  <TableCell
                    className={classNames(
                      classes.tableHeadCell,
                      classes[`tableHeadCell${name}`],
                      `tableHeadCell_${tableName} tableHeadCell_${name}`
                    )}
                    key={i}
                  >
                    {label}
                  </TableCell>
                ))}
              </TableRow>
            </TableHead>
          )}
          <TableBody
            className={classNames(classes.tableBody, `tableBody_${tableName}`)}
          >
            {!!allRowsData.length &&
              allRowsData.map(({ isEditing, rowData }, i) => {
                return isEditing ? (
                  <EditableRow
                    tableName={tableName}
                    isEditing={isEditing}
                    editingIndex={editingIndex}
                    selectClasses={{
                      selectFormControl: classes.selectFormControl,
                      selectInputLabel: classes.selectInputLabel,
                      select: classes.select,
                      selectMenuItem: classes.selectMenuItem
                    }}
                    inputClasses={{
                      inputWrapperDiv: classes.inputWrapperDiv,
                      input: classes.input,
                      error: classes.error
                    }}
                    classes={{
                      tableBodyRow: classes.tableBodyRow,
                      tableBodyCell: classes.tableBodyCell,
                      tableCellRow: classes.tableCellRow,
                      saveBtn: classes.saveBtn,
                      cancelBtn: classes.cancelBtn
                    }}
                    allRowsData={this.state.allRowsData}
                    editData={rowData}
                    handleSave={this.handleSave}
                    handleCancel={this.handleCancel}
                    fieldsArr={fieldsArr}
                  />
                ) : (
                  <Row
                    key={i}
                    tableName={tableName}
                    classes={{
                      tableBodyRow: classes.tableBodyRow,
                      tableBodyCell: classes.tableBodyCell,
                      tableCellRow: classes.tableCellRow,
                      editBtn: classes.editBtn,
                      deleteBtn: classes.deleteBtn
                    }}
                    isAdding={isAdding}
                    isEditing={this.state.isEditing}
                    handleEditRow={() => this.handleEditRow(i)}
                    handleDeleteRow={() => this.handleDeleteRow(i)}
                    data={rowData}
                  />
                );
              })}
            {isAdding && (
              <EditableRow
                tableName={tableName}
                allRowsData={this.state.allRowsData}
                selectClasses={{
                  selectFormControl: classes.selectFormControl,
                  selectInputLabel: classes.selectInputLabel,
                  select: classes.select,
                  selectMenuItem: classes.selectMenuItem
                }}
                inputClasses={{
                  inputWrapperDiv: classes.inputWrapperDiv,
                  input: classes.input,
                  error: classes.error
                }}
                classes={{
                  tableBodyRow: classes.tableBodyRow,
                  tableBodyCell: classes.tableBodyCell,
                  saveBtn: classes.saveBtn,
                  cancelBtn: classes.cancelBtn,
                  tableCellRow: classes.tableCellRow
                }}
                handleSave={this.handleSave}
                handleCancel={this.handleCancel}
                fieldsArr={fieldsArr}
              />
            )}
          </TableBody>
        </Table>
        <div>
          <Button
            className={classNames(classes.addBtn, `addBtn_${tableName}`)}
            disabled={isAdding || isEditing}
            onClick={() => this.setState({ isAdding: true })}
          >
            {addRowBtnText || "Add Row"}
          </Button>
        </div>
      </>
    );
  }
}

const styles = () => ({
  table: {},
  tableHead: {},
  tableHeadRow: {},
  tableHeadCell: {},
  tableBody: {},
  tableBodyRow: {},
  tableBodyCell: {},
  inputWrapperDiv: {},
  input: {},
  error: {},
  selectFormControl: {},
  selectInputLabel: {},
  select: {},
  selectMenuItem: {},
  saveBtn: {},
  cancelBtn: {},
  addBtn: {},
  deleteBtn: {},
  editBtn: {}
});

export default EditableTable;
