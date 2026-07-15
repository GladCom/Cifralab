import { StringControl } from '../../features/shared/control/string-control';
import { FormModel } from './types';

export const financingTypeFormModel: FormModel = {
  sourceName: {
    name: 'Тип финансирования',
    type: StringControl,
    formParams: {
      key: 'sourceNameKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
};
