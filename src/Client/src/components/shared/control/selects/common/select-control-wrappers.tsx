import { useMemo } from 'react';
import { ChangeSymbol, MultimodeWrapperControlProps } from '../../multi-mode-control/default-control-wrappers';
import { Button, Form, Space } from 'antd';
import { EditOutlined } from '@ant-design/icons';
import { DisplayMode, MultimodeControlValue } from '../../multi-mode-control/types';

export const ViewSelectControlWrapper: React.FC<MultimodeWrapperControlProps> = (props) => {
  const { Control, value, formParams, crud } = props;
  const { labelKey } = formParams;
  const { useGetOneByIdAsync } = crud;
  const { data: dataById } = useGetOneByIdAsync(value);
  const displayValue = labelKey ? dataById?.[labelKey] : undefined;

  return <Control {...props} value={displayValue || 'Данные отсутствуют'} />;
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
      <Control {...props} value={displayValue || 'Данные отсутствуют'} />
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
  const {
    Control,
    value,
    defaultValue,
    onChange,
    placeholder,
    formParams,
    controlParams,
    setValue,
    setDisplayMode,
    crud,
  } = props;
  const { key, labelKey, rules, normalize, hasFeedback } = formParams;
  const { displayOptions } = controlParams;
  const { editorMode } = displayOptions;
  const { useGetOneByIdAsync, useGetAllAsync } = crud;
  const { data: dataById } = useGetOneByIdAsync(value);
  const { data: allData } = useGetAllAsync();

  const options = useMemo(() => {
    if (!labelKey) {
      /* eslint-disable-next-line no-console */
      console.error('EditorFormItemSelectControl: labelKey is required but not provided');
      return [];
    }

    //  TODO: добавить типизацию для d.
    return (allData || []).map((d) => ({
      value: d.id,
      label: String(d[labelKey] ?? ''),
    }));
  }, [allData, labelKey]);

  const onSubmit = (formValue: { [key: string]: MultimodeControlValue }) => {
    const newValue = formValue[key];
    if (newValue !== undefined) {
      setValue(newValue);
      setDisplayMode(DisplayMode.EDITABLE_VIEW);
    } else {
      /* eslint-disable-next-line no-console */
      console.error(`Field "${key}" not found in form values. Available fields: ${Object.keys(formValue).join(', ')}`);
      // TODO: показать уведомление пользователю
    }
  };

  return (
    editorMode && (
      <Form layout="inline" name="editModeForm" clearOnDestroy onFinish={(values) => onSubmit(values)}>
        <Form.Item
          key={key}
          name={key}
          //label={name}
          initialValue={defaultValue}
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
        <Form.Item>
          <Space>
            <Button type="primary" htmlType="submit">
              Сохранить
            </Button>
            <Button htmlType="button" onClick={() => setDisplayMode(DisplayMode.EDITABLE_VIEW)}>
              Отмена
            </Button>
          </Space>
        </Form.Item>
      </Form>
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
      /* eslint-disable-next-line no-console */
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
