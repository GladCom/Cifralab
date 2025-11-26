import {
  useGetKindDocumentRiseQualificationQuery,
  useGetKindDocumentRiseQualificationPagedQuery,
  useGetKindDocumentRiseQualificationByIdQuery,
  useAddKindDocumentRiseQualificationMutation,
  useEditKindDocumentRiseQualificationMutation,
  useRemoveKindDocumentRiseQualificationMutation,
  useGetKindDocumentRiseQualificationSearchQuery,
} from '../service/kind-document-rise-qualification-api';

export {
  useGetKindDocumentRiseQualificationQuery as useGetAllAsync,
  useGetKindDocumentRiseQualificationPagedQuery as useGetAllPagedAsync,
  useGetKindDocumentRiseQualificationByIdQuery as useGetOneByIdAsync,
  useAddKindDocumentRiseQualificationMutation as useAddOneAsync,
  useEditKindDocumentRiseQualificationMutation as useEditOneAsync,
  useRemoveKindDocumentRiseQualificationMutation as useRemoveOneAsync,
  useGetKindDocumentRiseQualificationSearchQuery as useSearchAsync,
};
