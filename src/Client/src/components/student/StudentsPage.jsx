import Layout from '../shared/Layout.jsx';
import Catalog from '../shared/catalogProvider/Catalog.jsx';
import config from '../../storage/catalogConfigs/students.js'


const StudentsPage = () => {

    return (
        <Layout title="Студенты">
            <Catalog config={config} />
        </Layout>
    );
};

export default StudentsPage;