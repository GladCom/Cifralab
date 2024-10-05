import { 
  useGetKindDocumentRiseQualificationQuery,
  useGetKindDocumentRiseQualificationPagedQuery,
  useGetKindDocumentRiseQualificationByIdQuery,
  useAddKindDocumentRiseQualificationMutation,
  useEditKindDocumentRiseQualificationMutation,
  useRemoveKindDocumentRiseQualificationMutation,
} from '../services/kindDocumentRiseQualificationApi';

export {
  useGetKindDocumentRiseQualificationQuery as getAllAsync,
  useGetKindDocumentRiseQualificationPagedQuery as getAllPagedAsync,
  useGetKindDocumentRiseQualificationByIdQuery as getOneByIdAsync,
  useAddKindDocumentRiseQualificationMutation as addOneAsync,
  useEditKindDocumentRiseQualificationMutation as editOneAsync,
  useRemoveKindDocumentRiseQualificationMutation as removeOneAsync,
}