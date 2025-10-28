import React from 'react';
import { Layout, EntityTable } from '../shared/layout/index';
import config from '../../storage/catalog-configs/students';

const StudentsPage = () => {
  return (
    <Layout>
      <EntityTable config={config} title="Обучающиеся" />
    </Layout>
  );
};

export default StudentsPage;
