import { 
    useGetscopeOfActivityQuery,
    useGetscopeOfActivityPagedQuery,
    useGetscopeOfActivityByIdQuery,
    useAddscopeOfActivityMutation,
    useEditscopeOfActivityMutation,
    useRemovescopeOfActivityMutation,
  } from '../services/scopeOfActivityApi';
  
  export {
    useGetscopeOfActivityQuery as getAllAsync,
    useGetscopeOfActivityPagedQuery as getAllPagedAsync,
    useGetscopeOfActivityByIdQuery as getOneByIdAsync,
    useAddscopeOfActivityMutation as addOneAsync,
    useEditscopeOfActivityMutation as editOneAsync,
    useRemovescopeOfActivityMutation as removeOneAsync,
  }