import { StringControl } from '../../features/shared/control/string-control';
import { FormModel } from './types';

export const typeEducationFormModel: FormModel = {
  name: {
    name: 'Тип образования',
    type: StringControl,
    formParams: {
      key: 'typeEducationKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
};
