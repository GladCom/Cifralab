import { DisplayMode } from '../../components/shared/control/multi-mode-control/types';
import { ScopeOfActivitySelect } from '../../components/shared/control/selects/scope-of-activity-select';
import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
  useSearchAsync,
} from '../crud/scope-of-activity-crud';
import { scopeOfActivityFormModel } from '../form-model/scope-of-activity';

export default {
  detailsLink: 'scopeOfActivity',
  hasDetailsPage: false,
  serverPaged: false,
  properties: scopeOfActivityFormModel,
  crud: {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
    useSearchAsync,
  },
  columns: [
    {
      title: 'Сфера деятельности',
      dataIndex: 'nameOfScope',
      key: 'nameOfScope',
    },
    {
      title: 'Уровень',
      dataIndex: 'level',
      key: 'level',
    },
    {
      title: 'Здарова, Отец',
      dataIndex: 'scopeOfActivityParentId',
      key: 'scopeOfActivityParentId',
    },
  ],
  dataConverter: (data) => {
    return data?.map(({ scopeOfActivityParentId, ...props }) => {
      const parent = <ScopeOfActivitySelect value={scopeOfActivityParentId} displayMode={DisplayMode.VIEW} />;
      return { ...props, scopeOfActivityParentId: parent };
    });
  },
};
