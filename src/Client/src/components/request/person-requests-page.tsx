import React from 'react';
import { Layout, EntityTable } from '../shared/layout/index';
import config from '../../storage/catalog-configs/personRequests';

const PersonRequestsPage = () => {
  return (
    <Layout>
      <EntityTable config={config} title="Заявки" />
    </Layout>
  );
};

export default PersonRequestsPage;
