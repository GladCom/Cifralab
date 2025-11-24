import { useState } from 'react';
import { AutoComplete } from 'antd';
import { ControlByModeMap, DisplayMode, FormParams } from './multi-mode-control/types';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { Rule } from 'antd/es/form';
import { DefaultEditableViewControl, DefaultViewControl, MultiControlProps } from './multi-mode-control/default-controls';
import { DtoKeys } from '../../../storage/service/types';

const mails = ['mail.ru', 'gmail.com', 'ya.ru', 'icloud.com', 'disk.ru', 'list.ru', 'yahoo.com'];

const FormItemControl: React.FC<MultiControlProps> = ({ value, onChange, formParams }) => {
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

const EditorControl: React.FC<MultiControlProps> = ({ value, onChange, formParams }) => {
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
  {
    pattern: /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/,
    message: 'Только латиница и стандартный формат email',
  }
];

const formParams: FormParams = {
  key: DtoKeys.EMAIL,
  name: 'E-mail',
  rules,
};

export const Email: React.FC<MultimodeControlProps> = (props) => {
  return <MultimodeControl {...props} placeholder={'введите e-mail'} controlMap={controlMap} formParams={formParams} />;
};
