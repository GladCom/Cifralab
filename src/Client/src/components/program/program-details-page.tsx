import { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, RoutingWarningModal, DetailsPageHeader } from '../shared/layout/index';
import { useParams, useBlocker } from 'react-router-dom';
import { Row, Col, Button } from 'antd';
import config from '../../storage/catalog-config/education-program';
import { DetailsPageData } from '../shared/layout/details-page-data';
import { EducationProgram } from '../../storage/service/types';

const ProgramDetailsPage = () => {
  const { id } = useParams();
  const [programData, setProgramData] = useState<EducationProgram>();
  const [initialData, setInitialData] = useState<EducationProgram>();
  const [isChanged, setIsChanged] = useState(false);
  const [isSaveInProgress] = useState(false);
  const { formModel, crud } = config;
  const { useGetOneByIdAsync, useEditOneAsync } = crud;
  const { data, isLoading, isFetching } = useGetOneByIdAsync(id);

  const [editProgram] = useEditOneAsync();

  useEffect(() => {
    if (!isLoading && !isFetching) {
      const newData = { ...data };
      delete newData.id;
      setProgramData(newData);
      setInitialData(newData);
    }
  }, [isLoading, isFetching, data]);

  let blocker = useBlocker(
    ({ currentLocation, nextLocation }) => isChanged && currentLocation.pathname !== nextLocation.pathname,
  );

  const onSave = useCallback(() => {
    editProgram({ id, item: programData });
    setIsChanged(false);
  }, [id, programData, editProgram]);

  const onCancel = useCallback(() => {
    setProgramData(initialData);
    setIsChanged(false);
  }, [initialData]);

  if (!programData) {
    return <Loading />;
  }

  const title = `Программы - ${programData?.name}`;

  return isLoading || isFetching ? (
    <Loading />
  ) : (
    <Layout>
      <DetailsPageHeader title={title} />
      <h2 style={{ padding: '3vh' }}>{programData?.name}</h2>
      <DetailsPageData items={formModel} data={programData} editData={setProgramData} setIsChanged={setIsChanged} />
      <hr />
      <Row>
        <Col>
          <Button onClick={onSave} style={{ marginRight: '10px' }}>
            Сохранить
          </Button>
        </Col>
        <Col>
          <Button onClick={onCancel} disabled={isSaveInProgress}>
            Отмена
          </Button>
        </Col>
      </Row>
      <RoutingWarningModal show={blocker.state === 'blocked'} blocker={blocker} />
    </Layout>
  );
};

export default ProgramDetailsPage;
