import { kindEducationProgramConfig } from '../../storage/catalog-config/kind-education-program';
import { Catalog } from '../shared/catalog-provider/catalog';
import { Layout } from '../shared/layout/layout';

export const KindEducationProgramPage = () => {
  return (
    <Layout>
      <Catalog config={kindEducationProgramConfig} title="Вид программы" />
    </Layout>
  );
};
