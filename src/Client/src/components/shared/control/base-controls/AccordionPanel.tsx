import React, { ReactNode, useState } from 'react';
import { Flex } from 'antd';

interface IProps {}

const AccordionPanel: React.FC<IProps> = ({}) => {
  const [selectedAccrodion, setSelectedAccrodion] = useState<ReactNode | null>(null);
  const [accordion, setAccordion] = useState<ReactNode[]>([]);
  return (
    <Flex>
      {accordion.map((item, i) => (
        <div key={i}>{item}</div>
      ))}
    </Flex>
  );
};

export default AccordionPanel;
