import {
  useGetscopeOfActivityQuery,
  useGetscopeOfActivityPagedQuery,
  useGetscopeOfActivityByIdQuery,
  useAddscopeOfActivityMutation,
  useEditscopeOfActivityMutation,
  useRemovescopeOfActivityMutation,
  useGetScopeOfActivitySearchQuery,
} from '../service/scope-of-activity-api';

export {
  useGetscopeOfActivityQuery as useGetAllAsync,
  useGetscopeOfActivityPagedQuery as useGetAllPagedAsync,
  useGetscopeOfActivityByIdQuery as useGetOneByIdAsync,
  useAddscopeOfActivityMutation as useAddOneAsync,
  useEditscopeOfActivityMutation as useEditOneAsync,
  useRemovescopeOfActivityMutation as useRemoveOneAsync,
  useGetScopeOfActivitySearchQuery as useSearchAsync,
};
