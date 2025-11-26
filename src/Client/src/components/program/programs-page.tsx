import { Layout, EntityTable } from '../shared/layout/index';
import config from '../../storage/catalog-config/education-program';

const ProgramsPage = () => {
  return (
    <Layout>
      <EntityTable config={config} title="Программы" />
    </Layout>
  );
};

export default ProgramsPage;
