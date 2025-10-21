import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/requestStatus.js';

const RequestStatusPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Статусы заявки" />
    </Layout>
  );
};

export default RequestStatusPage;
