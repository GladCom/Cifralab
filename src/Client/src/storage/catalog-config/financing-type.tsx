import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
  useSearchAsync,
} from '../crud/financing-type-crud';
import { financingTypeFormModel } from '../form-model/financing-type';

export default {
  detailsLink: 'financingType',
  hasDetailsPage: false,
  serverPaged: false,
  properties: financingTypeFormModel,
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
      title: 'Тип финансирования',
      dataIndex: 'sourceName',
      key: 'sourceName',
    },
  ],
  dataConverter: (data) => data,
};
