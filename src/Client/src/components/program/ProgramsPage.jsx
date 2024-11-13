import React from 'react';
import { Layout, EntityTable } from '../shared/layout/index.js';
import config from '../../storage/catalogConfigs/educationPrograms.js'

const ProgramsPage = () => {
    return (
        <Layout title="Программы">
            <EntityTable config={config} />
        </Layout>
    );
};

export default ProgramsPage;