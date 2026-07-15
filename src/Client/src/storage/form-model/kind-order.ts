import { StringControl } from '../../features/shared/control/string-control';
import { FormModel } from './types';

export const kindOrderFormModel: FormModel = {
  name: {
    name: 'Тип приказа',
    type: StringControl,
    formParams: {
      key: 'nameKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
};
