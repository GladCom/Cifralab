import React from 'react';
import { Layout, EntityTable } from '../shared/layout/index';
import config from '../../storage/catalog-configs/groups';

const GroupsPage = () => {
  return (
    <Layout>
      <EntityTable config={config} title="Группы" />
    </Layout>
  );
};

export default GroupsPage;
