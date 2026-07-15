import { StringControl } from '../../features/shared/control/string-control';
import { FormModel } from './types';

export const feaProgramFormModel: FormModel = {
  name: {
    name: 'ВЭД программа',
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
