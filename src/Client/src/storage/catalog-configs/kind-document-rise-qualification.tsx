import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
} from '../crud/kind-document-rise-qualification-crud';
import kindDocumentRiseQualificationModel from '../models/kind-document-rise-qualification';

export default {
  detailsLink: 'kindDocumentRiseQualification',
  hasDetailsPage: false,
  serverPaged: false,
  properties: kindDocumentRiseQualificationModel,
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
      title: 'Вид документа повышения квалификации',
      dataIndex: 'name',
      key: 'name',
    },
  ],
  dataConverter: (data) => data,
};
