import React from 'react';
import { Layout, EntityTable } from '../shared/layout/index';
import config from '../../storage/catalog-configs/education-programs';

const ProgramsPage = () => {
  return (
    <Layout>
      <EntityTable config={config} title="Программы" />
    </Layout>
  );
};

export default ProgramsPage;
