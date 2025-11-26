import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
  useSearchAsync,
} from '../crud/fea-program-crud';
import { feaProgramFormModel } from '../form-model/fea-program';

export default {
  detailsLink: 'feaProgram',
  hasDetailsPage: false,
  serverPaged: false,
  properties: feaProgramFormModel,
  crud: {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
    useSearchAsync,
  },
  columns: [
    {
      title: 'ВЭД программа',
      dataIndex: 'name',
      key: 'name',
    },
  ],
  dataConverter: (data) => data,
};
