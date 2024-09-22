import React from 'react';
import PhoneInput from 'react-phone-input-2';
import { SearchOutlined } from '@ant-design/icons';
import 'react-phone-input-2/lib/style.css'

const PhoneFilter = ({ placeholder, onChange }) => {
    return (
        <div className="col-2">
            <PhoneInput
                country={'ru'}
                onlyCountries={['ru']}
                countryCodeEditable={false}
                placeholder={placeholder}
                //defaultMask="+.(...)...-...."
                masks={{ ru: '(...) ...-....' }}
                inputStyle={{ width: '100%', height: '32px' }} // Устанавливаем ширину для соответствия стилям Ant Design
                onChange={(data) => console.log(data)}
            />
        </div>
    );
};

export default PhoneFilter;