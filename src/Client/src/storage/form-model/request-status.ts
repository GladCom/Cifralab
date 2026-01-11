import { StringControl } from '../../components/shared/control/string-control';
import { FormModel } from './types';

export const requestStatusFormModel: FormModel = {
  name: {
    name: 'Статус заявки',
    type: StringControl,
    formParams: {
      key: 'requestStatusKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
};
