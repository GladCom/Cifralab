import { kindOrderConfig } from '../../storage/catalog-config/kind-order';
import { Catalog } from '../shared/catalog-provider/catalog';
import { Layout } from '../shared/layout/layout';

export const KindOrderPage = () => {
  return (
    <Layout>
      <Catalog config={kindOrderConfig} title="Вид приказа" />
    </Layout>
  );
};
