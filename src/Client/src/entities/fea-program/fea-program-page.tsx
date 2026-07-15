import { feaProgramConfig } from '../../storage/catalog-config/fea-program';
import { Catalog } from '../../features/shared/catalog-provider/catalog';
import { Layout } from '../../features/shared/layout/layout';

export const FEAProgramPage = () => {
  return (
    <Layout>
      <Catalog config={feaProgramConfig} title="ВЭД программы" />
    </Layout>
  );
};
