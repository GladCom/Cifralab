import React from 'react';
import Layout from '../shared/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import { config } from '../../storage/catalogConfigs/personrequests.js'

const PersonRequestsPage = () => {
    return (
        <Layout title="Заявки">
            <Catalog config={config} />
        </Layout>
    );
};

export default PersonRequestsPage;