import { 
    useGetPersonRequestsQuery,
    useGetPersonRequestsPagedQuery,
    useGetPersonRequestByIdQuery,
    useAddPersonRequestMutation,
    useEditPersonRequestMutation,
    useRemovePersonRequestMutation,
  } from '../services/requestsApi.js';
  
  export {
    useGetPersonRequestsQuery as getAllAsync,
    useGetPersonRequestsPagedQuery as getAllPagedAsync,
    useGetPersonRequestByIdQuery as getOneByIdAsync,
    useAddPersonRequestMutation as addOneAsync,
    useEditPersonRequestMutation as editOneAsync,
    useRemovePersonRequestMutation as removeOneAsync,
  }