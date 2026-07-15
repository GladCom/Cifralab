import { StringControl } from '../../features/shared/control/string-control';
import { FormModel } from './types';

export const kindDocumentRiseQualificationFormModel: FormModel = {
  name: {
    name: 'Вид документа повышения квалификации',
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
