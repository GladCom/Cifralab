import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
  useSearchAsync,
} from '../crud/request-status-crud';
import { requestStatusFormModel } from '../form-model/request-status';

export default {
  detailsLink: 'statusRequest',
  hasDetailsPage: false,
  serverPaged: false,
  formModel: requestStatusFormModel,
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
      title: 'Статус заявки',
      dataIndex: 'name',
      key: 'name',
    },
  ],
  dataConverter: (data) => data,
};
