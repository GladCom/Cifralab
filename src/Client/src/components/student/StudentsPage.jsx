import React from 'react';
import { Layout, EntityTable } from '../shared/layout/index.js';
import config from '../../storage/catalogConfigs/students.js'


const StudentsPage = () => {

    return (
        <Layout title="Студенты">
            <EntityTable config={config} />
        </Layout>
    );
};

export default StudentsPage;