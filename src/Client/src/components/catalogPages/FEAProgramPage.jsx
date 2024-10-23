import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/feaProgram.js'

const FEAProgramPage = () => {
    return (
        <Layout title="ВЭД программы">
            <Catalog config={config} />
        </Layout>
    );
};

export default FEAProgramPage;