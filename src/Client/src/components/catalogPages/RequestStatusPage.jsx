import React from 'react';
import Layout from '../shared/Layout';
import Catalog from '../shared/catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/requestStatus.js'

const RequestStatusPage = () => {
    return (
        <Layout title="Статусы заявки">
            <Catalog config={config} />
        </Layout>
    );
};

export default RequestStatusPage;