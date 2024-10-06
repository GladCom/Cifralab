import React from 'react';
import Layout from '../shared/Layout.jsx';
import Catalog from '../shared/catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/financingType.js'

const FinancingTypePage = () => {
    return (
        <Layout title="Типы финансирования">
            <Catalog config={config} />
        </Layout>
    );
};

export default FinancingTypePage;