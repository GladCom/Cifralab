import React from 'react';
import Layout from '../shared/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/financingType.js'

const FinancingTypePage = () => {
    return (
        <Layout title="Типы финансирования">
            <Catalog config={config} />
        </Layout>
    );
};

export default FinancingTypePage;