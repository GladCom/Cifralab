import { memo } from 'react';
import BaseControl from '../base-components/base-component';

const String = memo((props) => <BaseControl {...props} />);
String.displayName = 'String';

export default String;
