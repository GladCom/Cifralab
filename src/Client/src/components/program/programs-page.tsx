import { educationProgramConfig } from '../../storage/catalog-config/education-program';
import { EntityTable } from '../shared/layout/entity-table';
import { Layout } from '../shared/layout/layout';

export const ProgramsPage = () => {
  return (
    <Layout>
      <EntityTable config={educationProgramConfig} title="Программы" />
    </Layout>
  );
};
