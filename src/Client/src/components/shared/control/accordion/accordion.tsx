import './style.css';
import { HTMLAttributes, ReactNode, useState } from 'react';
import IconArrow from '@assets/arrow-icon.svg';

interface Props {
  children: ReactNode;
  wrapperProps?: HTMLAttributes<HTMLDivElement>;
  bodyProps?: HTMLAttributes<HTMLDivElement>;
  buttonProps?: HTMLAttributes<HTMLButtonElement>;
  imageProps?: HTMLAttributes<HTMLImageElement>;
}

export const Accordion: React.FC<Props> = ({ buttonProps, wrapperProps, imageProps, bodyProps, children }) => {
  const [isView, setIsView] = useState(false);

  const handlerBtnArrow = () => {
    setIsView((v) => !v);
  };

  const wrapperClass = `accordion ${isView ? 'accordionOpen' : ''} ${wrapperProps?.className || ''}`;
  const iconClass = `icon ${isView ? 'iconOpen' : ''} ${imageProps?.className || ''}`;
  const buttonClass = `button ${buttonProps?.className || ''}`;

  return (
    <div {...wrapperProps} className={wrapperClass}>
      <button type="button" {...buttonProps} className={buttonClass} onClick={handlerBtnArrow}>
        <img src={IconArrow} alt="Стрелка" {...imageProps} className={iconClass} />
      </button>
      <div {...bodyProps}>{children}</div>
    </div>
  );
};
