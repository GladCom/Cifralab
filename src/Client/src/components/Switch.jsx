import * as React from 'react';
import ToggleButton from '@mui/material/ToggleButton';
import ToggleButtonGroup from '@mui/material/ToggleButtonGroup';

export default function SwitchLang() {
  const [alignment, setAlignment] = React.useState('left');

  const handleAlignment = (value) => {
    global.config.conf.currentLoc = value;
    console.log(global.config.conf.currentLoc)
    if (alignment === 'left')
      setAlignment('right');
    else
      setAlignment('left');
    window.localStorage.setItem("lang", global.config.conf.currentLoc)
    console.log(window.localStorage.getItem("lang"));
    window.location.reload();
  };

  return (
    <ToggleButtonGroup
      value={alignment}
      exclusive
      onChange={(e) => handleAlignment(e.target.value)}
      aria-label="text alignment"
    >
      <ToggleButton title='En' value="en_US" aria-label="left aligned">
        En
      </ToggleButton>
      <ToggleButton title='Ru' value="ru_RU" aria-label="centered">
        Ru
      </ToggleButton>
    </ToggleButtonGroup>
  );
}