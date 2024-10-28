import React, { memo } from 'react';
import BaseComponent from './com/BaseComponent'; 

const String = memo((props) => (
    <BaseComponent
        {...props}
    />
));
String.displayName = 'String';

export default String;
