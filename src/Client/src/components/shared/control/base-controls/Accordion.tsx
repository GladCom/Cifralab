import { useState, type HTMLAttributes, type ReactNode } from 'react';
import IconArrow from '@/assets/arrow-icon.svg';
import styled from 'styled-components';

interface IProps {
  children: ReactNode;
  wrapperProps?: HTMLAttributes<HTMLDivElement>;
  bodyProps?: HTMLAttributes<HTMLDivElement>;
  buttonProps?: HTMLAttributes<HTMLButtonElement>;
  imageProps?: HTMLAttributes<HTMLImageElement>;
}

interface IMainLayoutProps {
  isView: boolean;
}
interface IArrowIconProps {
  isOpen: boolean;
}

const MainLayout = styled.div<IMainLayoutProps>`
  display: flex;
  flex-direction: row;
  gap: 8px;
  padding: 12px 16px;
  border-radius: 10px;
  max-height: ${(props) => (props.isView ? '100%' : '10%')};
  box-sizing: content-box;
  overflow-y: hidden;
  flex-shrink: 0;
  transition: max-height 0.5s ease-in-out;

  & > Card {
    overflow: hidden;
    border-radius: inherit;
  }
`;

const AccButton = styled.button`
  display: flex;
  align-items: flex-end;
  height: 18px;
  border: none;
  background: none;
  cursor: pointer;
`;

//TODO: исправить на интерфейс
const ArrowIcon = styled.img<IArrowIconProps>`
  width: 16px;
  height: 16px;
  aspect-ratio: 1;
  rotate: ${(props) => (props.isOpen ? '-90deg' : '0deg')};
  transition: max-height 0.3s ease-in-out;
`;

const Accordion = (props: IProps) => {
  const [isView, setIsView] = useState(false);
  const handlerBtnArrow = () => {
    setIsView((v) => !v);
  };

  return (
    <MainLayout {...props.wrapperProps} className="accordion" isView={isView}>
      <AccButton {...props.buttonProps} onClick={handlerBtnArrow}>
        <ArrowIcon {...props.imageProps} isOpen={isView} src={IconArrow} alt="Стрелка для открытия аккордеона" />
      </AccButton>
      <div {...props.bodyProps}>{props.children}</div>
    </MainLayout>
  );
};

export default Accordion;
