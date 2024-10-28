import { 
  useGetKindDocumentRiseQualificationQuery,
  useGetKindDocumentRiseQualificationPagedQuery,
  useGetKindDocumentRiseQualificationByIdQuery,
  useAddKindDocumentRiseQualificationMutation,
  useEditKindDocumentRiseQualificationMutation,
  useRemoveKindDocumentRiseQualificationMutation,
} from '../services/kindDocumentRiseQualificationApi';

export {
  useGetKindDocumentRiseQualificationQuery as useGetAllAsync,
  useGetKindDocumentRiseQualificationPagedQuery as useGetAllPagedAsync,
  useGetKindDocumentRiseQualificationByIdQuery as useGetOneByIdAsync,
  useAddKindDocumentRiseQualificationMutation as useAddOneAsync,
  useEditKindDocumentRiseQualificationMutation as useEditOneAsync,
  useRemoveKindDocumentRiseQualificationMutation as useRemoveOneAsync,
}