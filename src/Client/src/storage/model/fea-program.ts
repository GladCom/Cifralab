import { StringControl } from '../../components/shared/control/string-control';
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
