import {
  useGetGroupsQuery,
  useGetGroupsPagedQuery,
  useGetGroupByIdQuery,
  useAddGroupMutation,
  useEditGroupMutation,
  useRemoveGroupMutation,
} from '../service/groups-api';

export {
  useGetGroupsQuery as useGetAllAsync,
  useGetGroupsPagedQuery as useGetAllPagedAsync,
  useGetGroupByIdQuery as useGetOneByIdAsync,
  useAddGroupMutation as useAddOneAsync,
  useEditGroupMutation as useEditOneAsync,
  useRemoveGroupMutation as useRemoveOneAsync,
};
