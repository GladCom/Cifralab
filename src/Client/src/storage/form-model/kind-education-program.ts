import { StringControl } from '../../components/shared/control/string-control';
import { FormModel } from './types';

export const kindEducationProgramFormModel: FormModel = {
  name: {
    name: 'Вид программы',
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
