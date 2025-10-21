import React from 'react';
import Layout from '../shared/layout/Layout';
import Catalog from '../shared/catalogProvider/Catalog';
import config from '../../storage/catalog-configs/requestStatus';

const RequestStatusPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Статусы заявки" />
    </Layout>
  );
};

export default RequestStatusPage;
