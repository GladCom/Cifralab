import React from 'react';
import Layout from '../shared/Layout.jsx';
import Catalog from '../shared/catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/fEAProgram.js'

const FEAProgramPage = () => {
    return (
        <Layout title="ВЭД программы">
            <Catalog config={config} />
        </Layout>
    );
};

export default FEAProgramPage;