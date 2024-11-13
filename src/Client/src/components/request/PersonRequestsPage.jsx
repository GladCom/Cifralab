import React from 'react';
import { Layout, EntityTable } from '../shared/layout/index.js';
import config from '../../storage/catalogConfigs/personRequests.js'

const PersonRequestsPage = () => {
    return (
        <Layout title="Заявки">
            <EntityTable config={config} />
        </Layout>
    );
};

export default PersonRequestsPage;