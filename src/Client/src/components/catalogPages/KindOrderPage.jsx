import React from 'react';
import Layout from '../shared/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/kindOrder.js'

const KindOrderPage = () => {
    return (
        <Layout title="Вид приказа">
            <Catalog config={config} />
        </Layout>
    );
};

export default KindOrderPage;