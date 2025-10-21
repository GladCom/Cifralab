import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/kindDocumentRiseQualification.js';

const KindDocumentRiseQualificationPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Вид документа повышения квалификации" />
    </Layout>
  );
};

export default KindDocumentRiseQualificationPage;
