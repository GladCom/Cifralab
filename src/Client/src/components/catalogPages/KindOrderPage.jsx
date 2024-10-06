import React from 'react';
import Layout from '../shared/Layout.jsx';
import Catalog from '../shared/catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/kindOrder.js'

const KindOrderPage = () => {
    return (
        <Layout title="Вид приказа">
            <Catalog config={config} />
        </Layout>
    );
};

export default KindOrderPage;