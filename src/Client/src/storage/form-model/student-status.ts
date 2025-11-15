import { StringControl } from '../../components/shared/control/string-control';
import { FormModel } from './types';

export const studentStatusFormModel: FormModel = {
  name: {
    name: 'Статус студента',
    type: StringControl,
    formParams: {
      key: 'studentStatusKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
};
