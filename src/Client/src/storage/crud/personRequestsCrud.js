import { 
    useGetPersonRequestsQuery,
    useGetPersonRequestsPagedQuery,
    useGetPersonRequestByIdQuery,
    useAddPersonRequestMutation,
    useEditPersonRequestMutation,
    useRemovePersonRequestMutation,
  } from '../services/requestsApi.js';
  
  export {
    useGetPersonRequestsQuery as useGetAllAsync,
    useGetPersonRequestsPagedQuery as useGetAllPagedAsync,
    useGetPersonRequestByIdQuery as useGetOneByIdAsync,
    useAddPersonRequestMutation as useAddOneAsync,
    useEditPersonRequestMutation as useEditOneAsync,
    useRemovePersonRequestMutation as useRemoveOneAsync,
  }