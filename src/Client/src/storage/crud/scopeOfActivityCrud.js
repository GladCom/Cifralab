import { 
    useGetscopeOfActivityQuery,
    useGetscopeOfActivityPagedQuery,
    useGetscopeOfActivityByIdQuery,
    useAddscopeOfActivityMutation,
    useEditscopeOfActivityMutation,
    useRemovescopeOfActivityMutation,
  } from '../services/scopeOfActivityApi';
  
  export {
    useGetscopeOfActivityQuery as useGetAllAsync,
    useGetscopeOfActivityPagedQuery as useGetAllPagedAsync,
    useGetscopeOfActivityByIdQuery as useGetOneByIdAsync,
    useAddscopeOfActivityMutation as useAddOneAsync,
    useEditscopeOfActivityMutation as useEditOneAsync,
    useRemovescopeOfActivityMutation as useRemoveOneAsync,
  }