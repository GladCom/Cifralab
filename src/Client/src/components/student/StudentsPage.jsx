import Layout from '../shared/Layout.jsx';
import Catalog from '../shared/catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/students.js'


const StudentsPage = () => {

    return (
        <Layout title="Студенты">
            <Catalog config={config} />
        </Layout>
    );
};

export default StudentsPage;