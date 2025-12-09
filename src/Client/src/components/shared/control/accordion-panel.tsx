import { ReactNode, useState } from 'react';
import { Flex } from 'antd';

export const AccordionPanel = () => {
  const [accordion] = useState<ReactNode[]>([]);
  return (
    <Flex>
      {accordion.map((item, i) => (
        <div key={i}>{item}</div>
      ))}
    </Flex>
  );
};
