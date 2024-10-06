import { 
  useGetGroupsQuery,
  useGetGroupsPagedQuery,
  useGetGroupByIdQuery,
  useAddGroupMutation,
  useEditGroupMutation,
  useRemoveGroupMutation,
} from '../services/groupsApi.js';

export {
  useGetGroupsQuery as getAllAsync,
  useGetGroupsPagedQuery as getAllPagedAsync,
  useGetGroupByIdQuery as getOneByIdAsync,
  useAddGroupMutation as addOneAsync,
  useEditGroupMutation as editOneAsync,
  useRemoveGroupMutation as removeOneAsync,
}