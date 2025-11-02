import React from 'react';
import { Layout } from '../shared/layout';
import config from '../../storage/catalog-configs/request-status';
import Catalog from '../shared/catalog-provider/catalog';

const RequestStatusPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Статусы заявки" />
    </Layout>
  );
};

export default RequestStatusPage;
