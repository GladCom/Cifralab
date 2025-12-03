// В данном случае, почему-то, импорт React необходим.
import React from 'react';
import { Col, Row, Space } from 'antd';
import { DisplayMode } from '../shared/control/multi-mode-control/types';
import { Student } from '../../storage/service/types';

type StudentFormWrapperProps = {
  children?: React.ReactNode;
  studentData: Student;
  setStudentData: (data: Student) => void;
  setIsChanged: (isChanged: boolean) => void;
};

const rowStyle = {
  alignItems: 'center',
};

export const StudentFormWrapper: React.FC<StudentFormWrapperProps> = (props) => {
  const { children, studentData, setStudentData, setIsChanged } = props;

  return (
    <>
      {React.Children.map(children, (child) => {
        if (!React.isValidElement(child)) {
          return child;
        }
        const { formParams } = child.props;
        const { key } = formParams;
        return (
          <Space direction="vertical" size={0} style={{ display: 'flex', paddingLeft: '3vh' }}>
            <Row style={rowStyle} key={key}>
              <Col span={3}>{formParams.name}</Col>
              <Col span={8}>
                {React.cloneElement(child, {
                  key: key,
                  value: studentData[key],
                  displayMode: DisplayMode.EDITABLE_VIEW,
                  setValue: (value) => {
                    (setStudentData({
                      ...studentData,
                      [key]: value,
                    }),
                      setIsChanged(true));
                  },
                  ...child.props,
                })}
              </Col>
            </Row>
          </Space>
        );
      })}
    </>
  );
};
