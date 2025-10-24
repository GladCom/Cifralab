import { memo } from 'react';
import BaseComponent from '../base-components/base-component';

const String = memo((props) => <BaseComponent {...props} />);
String.displayName = 'String';

export default String;
