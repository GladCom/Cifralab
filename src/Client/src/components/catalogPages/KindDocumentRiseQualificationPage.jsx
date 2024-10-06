import React from 'react';
import Layout from '../shared/Layout.jsx';
import Catalog from '../shared/catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/kindDocumentRiseQualification.js'

const KindDocumentRiseQualificationPage = () => {
    return (
        <Layout title="Вид документа повышения квалификации">
            <Catalog config={config} />
        </Layout>
    );
};

export default KindDocumentRiseQualificationPage;