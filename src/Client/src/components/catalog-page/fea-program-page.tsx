import { feaProgramConfig } from '../../storage/catalog-config/fea-program';
import { Catalog } from '../shared/catalog-provider/catalog';
import { Layout } from '../shared/layout/layout';

export const FEAProgramPage = () => {
  return (
    <Layout>
      <Catalog config={feaProgramConfig} title="ВЭД программы" />
    </Layout>
  );
};
