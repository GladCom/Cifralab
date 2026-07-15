import { requestStatusConfig } from '../../storage/catalog-config/request-status';
import { Catalog } from '../../features/shared/catalog-provider/catalog';
import { Layout } from '../../features/shared/layout/layout';

export const RequestStatusPage = () => {
  return (
    <Layout>
      <Catalog config={requestStatusConfig} title="Статусы заявки" />
    </Layout>
  );
};
