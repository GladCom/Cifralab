import './style.css';
import { HTMLAttributes, ReactNode, useState } from 'react';
import IconArrow from '@assets/arrow-icon.svg';
import { clsx } from 'clsx';

interface Props {
  children: ReactNode;
  wrapperProps?: HTMLAttributes<HTMLDivElement>;
  bodyProps?: HTMLAttributes<HTMLDivElement>;
  buttonProps?: HTMLAttributes<HTMLButtonElement>;
  imageProps?: HTMLAttributes<HTMLImageElement>;
}

export const Accordion: React.FC<Props> = ({ buttonProps, wrapperProps, imageProps, bodyProps, children }) => {
  const [isOpen, setIsOpen] = useState(false);

  const toggleAccordion = () => {
    setIsOpen((prev) => !prev);
  };

  return (
    <div {...wrapperProps} className={clsx('accordion', { accordionOpen: isOpen }, wrapperProps?.className)}>
      <button
        type="button"
        {...buttonProps}
        className={clsx('button', buttonProps?.className)}
        onClick={toggleAccordion}
      >
        <img
          src={IconArrow}
          alt="Стрелка"
          {...imageProps}
          className={clsx('icon', { iconOpen: isOpen }, imageProps?.className)}
        />
      </button>

      <div {...bodyProps} className={clsx(bodyProps?.className)}>
        {children}
      </div>
    </div>
  );
};
