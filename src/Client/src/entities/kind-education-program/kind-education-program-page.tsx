import { kindEducationProgramConfig } from '../../storage/catalog-config/kind-education-program';
import { Catalog } from '../../features/shared/catalog-provider/catalog';
import { Layout } from '../../features/shared/layout/layout';

export const KindEducationProgramPage = () => {
  return (
    <Layout>
      <Catalog config={kindEducationProgramConfig} title="Вид программы" />
    </Layout>
  );
};
