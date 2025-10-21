import React from 'react';
import Layout from '../shared/layout/Layout';
import Catalog from '../shared/catalogProvider/Catalog';
import config from '../../storage/catalog-configs/kindDocumentRiseQualification';

const KindDocumentRiseQualificationPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Вид документа повышения квалификации" />
    </Layout>
  );
};

export default KindDocumentRiseQualificationPage;
