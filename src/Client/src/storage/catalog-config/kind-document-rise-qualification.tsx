import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
  useSearchAsync,
} from '../crud/kind-document-rise-qualification-crud';
import { kindDocumentRiseQualificationFormModel } from '../form-model/kind-document-rise-qualification';

export default {
  detailsLink: 'kindDocumentRiseQualification',
  hasDetailsPage: false,
  serverPaged: false,
  properties: kindDocumentRiseQualificationFormModel,
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
      title: 'Вид документа повышения квалификации',
      dataIndex: 'name',
      key: 'name',
    },
  ],
  dataConverter: (data) => data,
};
