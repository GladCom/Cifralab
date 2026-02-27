import { personRequestConfig } from '../../storage/catalog-config/person-request';
import { EntityTable } from '../shared/layout/entity-table';
import { Layout } from '../shared/layout/layout';

export const PersonRequestsPage = () => {
  return (
    <Layout>
      <EntityTable config={personRequestConfig} title="Заявки" />
    </Layout>
  );
};
