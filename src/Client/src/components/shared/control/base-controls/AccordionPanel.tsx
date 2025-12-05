import React, { ReactNode, useState } from 'react';
import { Flex } from 'antd';

interface IProps {}

export const AccordionPanel: React.FC<IProps> = ({}) => {
  const [accordion] = useState<ReactNode[]>([]);
  return (
    <Flex>
      {accordion.map((item, i) => (
        <div key={i}>{item}</div>
      ))}
    </Flex>
  );
};
