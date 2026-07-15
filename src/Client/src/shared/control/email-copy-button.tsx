import React from 'react';
import { Button, Tooltip } from 'antd';
import { CopyOutlined } from '@ant-design/icons';
import { useNotifications } from '../../notification/use-notifications';

export interface EmailCopyButtonProps {
  email: string;
}

export const EmailCopyButton: React.FC<EmailCopyButtonProps> = ({ email }) => {
  const { showSuccess, showError } = useNotifications();

  const handleCopy = async () => {
    try {
      await navigator.clipboard.writeText(email);
      showSuccess('E-mail скопирован', `Адрес "${email}" скопирован в буфер обмена`);
    } catch (error) {
      /* eslint-disable-next-line no-console */
      console.error('Ошибка копирования e-mail:', error);
      showError('Не удалось скопировать e-mail', error);
    }
  };

  return (
    <Tooltip title="Скопировать e-mail">
      <Button
        type="text"
        size="small"
        icon={<CopyOutlined />}
        onClick={handleCopy}
        onMouseEnter={(e) => (e.currentTarget.style.color = styles.hover.color)}
        onMouseLeave={(e) => (e.currentTarget.style.color = styles.default.color)}
        style={styles.default}
      />
    </Tooltip>
  );
};

// 🎨 Локальные стили компонента
const styles = {
  default: {
    color: '#999',
    transition: 'color 0.2s ease',
  },
  hover: {
    color: '#1677ff',
  },
};
