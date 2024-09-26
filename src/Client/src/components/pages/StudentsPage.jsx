import Layout from '../shared/Layout';
import Catalog from '../catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/students.js'


const StudentsPage = () => {

    return (
        <Layout title="Студенты">
            <Catalog config={config} />
        </Layout>
    );
};

export default StudentsPage;