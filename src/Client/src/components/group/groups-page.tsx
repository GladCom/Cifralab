import { groupConfig } from '../../storage/catalog-config/group';
import { EntityTable } from '../shared/layout/entity-table';
import { Layout } from '../shared/layout/layout';

export const GroupsPage = () => {
  return (
    <Layout>
      <EntityTable config={groupConfig} title="Группы" />
    </Layout>
  );
};
