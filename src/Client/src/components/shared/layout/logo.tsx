import logo from '../../../assets/images/cyfraLogo.png';

const logoStyle = {
  height: '80%',
};

export const Logo = () => {
  return <img src={logo} style={logoStyle} alt="Логотип Академии цифра" />;
};
