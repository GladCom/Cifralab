import { useMemo } from 'react';
import { ChangeSymbol, MultimodeWrapperControlProps } from '../../multi-mode-control/default-control-wrappers';
import { Button, Form, Space } from 'antd';
import { EditOutlined } from '@ant-design/icons';
import { DisplayMode } from '../../multi-mode-control/types';

export const ViewSelectControlWrapper: React.FC<MultimodeWrapperControlProps> = (props) => {
  const { Control, value, formParams, crud } = props;
  const { labelKey } = formParams;
  const { useGetOneByIdAsync } = crud;
  const { data: dataById } = useGetOneByIdAsync(value);
  const displayValue = labelKey ? dataById?.[labelKey] : undefined;

  return <Control {...props} value={displayValue || 'ERROR!!!'} />;
};

export const EditableViewSelectControlWrapper: React.FC<MultimodeWrapperControlProps> = (props) => {
  const { Control, isChanged, value, formParams, crud, setDisplayMode } = props;
  const { labelKey } = formParams;
  const { useGetOneByIdAsync } = crud;
  const { data: dataById } = useGetOneByIdAsync(value);
  const displayValue = labelKey ? dataById?.[labelKey] : undefined;

  return (
    <Space>
      {isChanged && <ChangeSymbol />}
      <Control {...props} value={displayValue || 'ERROR!!!'} />
      <Button
        color="default"
        variant="link"
        icon={<EditOutlined />}
        onClick={() => setDisplayMode(DisplayMode.EDITOR)}
      />
    </Space>
  );
};

export const EditorSelectControlWrapper: React.FC<MultimodeWrapperControlProps> = (props) => {
  const { Control, value, onChange, placeholder, formParams, controlParams, crud } = props;
  const { key, labelKey } = formParams;
  const { displayOptions } = controlParams;
  const { editorMode } = displayOptions;
  const { useGetOneByIdAsync, useGetAllAsync } = crud;
  const { data: dataById } = useGetOneByIdAsync(value);
  const { data: allData } = useGetAllAsync();

  const options = useMemo(() => {
    if (!labelKey) {
      console.error('EditorFormItemSelectControl: labelKey is required but not provided');
      return [];
    }

    //  TODO: добавить типизацию для d.
    return (allData || []).map((d) => ({
      value: d.id,
      label: String(d[labelKey] ?? ''),
    }));
  }, [allData, labelKey]);

  return (
    editorMode && (
      <Control
        key={key}
        value={value}
        formParams={formParams}
        //  TODO: возможно как-то криво.
        defaultValue={labelKey ? dataById?.[labelKey] : undefined}
        placeholder={placeholder}
        onChange={onChange}
        options={options}
      />
    )
  );
};

export const FormItemSelectControlWrapper: React.FC<MultimodeWrapperControlProps> = (props) => {
  const { Control, value, onChange, placeholder, formParams, controlParams, crud } = props;
  const { key, labelKey, name, normalize, hasFeedback, rules } = formParams;
  const { displayOptions } = controlParams;
  const { formItemMode } = displayOptions;
  const { useGetOneByIdAsync, useGetAllAsync } = crud;
  const { data: dataById } = useGetOneByIdAsync(value);
  const { data: allData } = useGetAllAsync();

  const options = useMemo(() => {
    if (!labelKey) {
      console.error('EditorFormItemSelectControl: labelKey is required but not provided');
      return [];
    }

    //  TODO: добавить типизацию для d.
    return (allData || []).map((d) => ({
      value: d.id,
      label: String(d[labelKey] ?? ''),
    }));
  }, [allData, labelKey]);

  return (
    formItemMode && (
      <Form.Item
        key={key}
        name={key}
        label={name}
        initialValue={value}
        rules={rules}
        normalize={normalize}
        hasFeedback={hasFeedback}
      >
        <Control
          key={key}
          value={value}
          formParams={formParams}
          //  TODO: возможно как-то криво.
          defaultValue={labelKey ? dataById?.[labelKey] : undefined}
          placeholder={placeholder}
          onChange={onChange}
          options={options}
        />
      </Form.Item>
    )
  );
};
