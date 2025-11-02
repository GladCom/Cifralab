import { useState } from 'react';
import { AutoComplete } from 'antd';
import { ControlByModeMap, DisplayMode, EditableControlProps, FormParams } from './multi-mode-control/types';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { Rule } from 'antd/es/form';
import { DefaultEditableViewControl, DefaultViewControl } from './multi-mode-control/default-controls';

const mails = ['mail.ru', 'gmail.com', 'ya.ru', 'icloud.com', 'disk.ru', 'list.ru'];

const FormItemControl: React.FC<EditableControlProps> = ({ value, onChange, formParams }) => {
  const { key } = formParams;
  const [options, setOptions] = useState<{ label: string; value: string }[]>([]);

  const handleChange = (inputValue: string) => {
    setOptions(() => {
      if (!inputValue || inputValue.includes('@')) {
        return [];
      }
      return mails.map((domain) => ({
        label: `${inputValue}@${domain}`,
        value: `${inputValue}@${domain}`,
      }));
    });
  };

  return (
    <AutoComplete
      key={key}
      onSearch={handleChange}
      allowClear
      onChange={onChange}
      defaultValue={value}
      options={options}
    />
  );
};

const EditorControl: React.FC<EditableControlProps> = ({ value, onChange, formParams }) => {
  const { key } = formParams;
  const [options, setOptions] = useState<{ label: string; value: string }[]>([]);

  const handleChange = (inputValue: string) => {
    setOptions(() => {
      if (!inputValue || inputValue.includes('@')) {
        return [];
      }
      return mails.map((domain) => ({
        label: `${inputValue}@${domain}`,
        value: `${inputValue}@${domain}`,
      }));
    });
  };

  return (
    <AutoComplete
      key={key}
      onSearch={handleChange}
      allowClear
      onChange={onChange}
      defaultValue={value}
      options={options}
      style={{ minWidth: '250px' }}
    />
  );
};

const controlMap: ControlByModeMap = {
  [DisplayMode.VIEW]: DefaultViewControl,
  [DisplayMode.EDITABLE_VIEW]: DefaultEditableViewControl,
  [DisplayMode.EDITOR]: EditorControl,
  [DisplayMode.FORM_ITEM]: FormItemControl,
};

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить email',
  },
  {
    type: 'email',
    message: 'Некорректно заполнен email',
  },
];

const formParams: FormParams = {
  key: 'email',
  name: 'E-mail',
  rules,
};

export const Email: React.FC<MultimodeControlProps> = (props) => {
  return <MultimodeControl {...props} placeholder={'введите e-mail'} controlMap={controlMap} formParams={formParams} />;
};
