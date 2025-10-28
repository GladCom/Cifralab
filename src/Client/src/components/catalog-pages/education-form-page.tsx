import Catalog from '../shared/catalog-provider/catalog';
import config from '../../storage/catalog-configs/education-form';
import { Layout } from '../shared/layout';

const EducationFormPage = () => {
  return (
    <Layout>
      <Catalog config={config} title="Формы образования" />
    </Layout>
  );
};

export default EducationFormPage;
