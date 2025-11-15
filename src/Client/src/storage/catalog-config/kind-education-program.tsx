import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
} from '../crud/kind-education-program-crud';
import { kindEducationProgramFormModel } from '../form-model/kind-education-program';

export default {
  detailsLink: 'kindEducationProgram',
  hasDetailsPage: false,
  serverPaged: false,
  properties: kindEducationProgramFormModel,
  crud: {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
  },
  columns: [
    {
      title: 'Вид программы',
      dataIndex: 'name',
      key: 'name',
    },
  ],
  dataConverter: (data) => data,
};
