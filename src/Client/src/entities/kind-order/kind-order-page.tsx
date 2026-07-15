import { kindOrderConfig } from '../../storage/catalog-config/kind-order';
import { Catalog } from '../../features/shared/catalog-provider/catalog';
import { Layout } from '../../features/shared/layout/layout';

export const KindOrderPage = () => {
  return (
    <Layout>
      <Catalog config={kindOrderConfig} title="Вид приказа" />
    </Layout>
  );
};
