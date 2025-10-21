import React from 'react';
import { Layout, EntityTable } from '../shared/layout/index.js';
import config from '../../storage/catalog-configs/groups.js';

const GroupsPage = () => {
  return (
    <Layout>
      <EntityTable config={config} title="Группы" />
    </Layout>
  );
};

export default GroupsPage;
