import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalog-configs/kindEducationProgram.js';

const KindEducationProgramPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Вид программы" />
    </Layout>
  );
};

export default KindEducationProgramPage;
