import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalog-configs/studentStatus.js';

const StudentStatusPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Статус студента" />
    </Layout>
  );
};

export default StudentStatusPage;
