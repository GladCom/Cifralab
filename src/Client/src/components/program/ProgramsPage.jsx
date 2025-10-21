import React from 'react';
import { Layout, EntityTable } from '../shared/layout/index.js';
import config from '../../storage/catalog-configs/educationPrograms.js';

const ProgramsPage = () => {
  return (
    <Layout>
      <EntityTable config={config} title="Программы" />
    </Layout>
  );
};

export default ProgramsPage;
