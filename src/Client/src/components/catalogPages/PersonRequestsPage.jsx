import React from 'react';
import Layout from '../shared/layout/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/personRequests.js'

const PersonRequestsPage = () => {
    return (
        <Layout title="Заявки">
            <Catalog config={config} />
        </Layout>
    );
};

export default PersonRequestsPage;