import { Checkbox } from 'antd';

/**
 * Универсальный чекбокс "В архиве".
 * - работает с BaseComponent и formik-подобной системой;
 * - не имеет локального состояния;
 * - значение управляется родителем;
 * - при клике вызывает setValue().
 */
export const ArchiveCheckbox = ({ value, setValue }) => {
  const handleChange = (e) => {
    const newValue = e.target.checked;
    if (typeof setValue === 'function') {
      setValue(newValue);
    }
  };

  return (
    <Checkbox
      checked={!!value}
      onChange={handleChange}
    />
  );
};
