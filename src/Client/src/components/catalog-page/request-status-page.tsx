import { requestStatusConfig } from '../../storage/catalog-config/request-status';
import { Catalog } from '../shared/catalog-provider/catalog';
import { Layout } from '../shared/layout/layout';

export const RequestStatusPage = () => {
  return (
    <Layout>
      <Catalog config={requestStatusConfig} title="Статусы заявки" />
    </Layout>
  );
};
