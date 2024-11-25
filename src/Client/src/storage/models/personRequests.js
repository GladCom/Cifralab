import String from '../../components/shared/business/common/String.jsx';
import EducationProgramSelect from '../../components/shared/business/selects/EducationProgramSelect.jsx';
import EducationTypeSelect from '../../components/shared/business/selects/EducationTypeSelect.jsx';
import StatusEntrancExamsSelect from '../../components/shared/business/selects/StatusEntrancExamsSelect.jsx';
import ScopeOfActivitySelect from '../../components/shared/business/selects/ScopeOfActivitySelect.jsx';
import CheckBox from '../../components/shared/business/common/CheckBox.jsx';
import BirthDate from '../../components/shared/business/BirthDate.jsx';
import Address from '../../components/shared/business/Address.jsx';
import Email from '../../components/shared/business/Email.jsx';
import PhoneNumber from '../../components/shared/business/PhoneNumber.jsx';
import DateTimeView from '../../components/shared/business/DateTimeView.jsx';

const model = {
    family: { 
        name: 'Фамилия', 
        type: String,
    },
    name: { 
        name: 'Имя', 
        type: String,
    },
    patron: { 
        name: 'Отчество', 
        type: String,  
    },
    dateOfCreate: {
        name: 'Дата и время заявки', 
        type: DateTimeView, 
        formParams: {
            rules: [
                {
                    required: false,
                },
            ],
        },
        params: {
            show: {
                form: true,
            }
        },
    },
    educationProgramId : { 
        name: 'Программа', 
        type: EducationProgramSelect,  
    },
    typeEducationId : { 
        name: 'Уровень образования', 
        type: EducationTypeSelect, 
    },
    iT_Experience: { 
        name: 'Опыт в IT', 
        type: String,
    },
    speciality: { 
        name: 'Специальность', 
        type: String,  
    },                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
    projects: { 
        name: 'Проекты', 
        type: String, 
    },
    statusEntrancExams: { 
        name: 'Тестовое задание', 
        type: StatusEntrancExamsSelect,
    },
    birthDate: { 
        name: 'Дата рождения', 
        type: BirthDate, 
    },
    address: { 
        name: 'Место проживания',  
        type: Address, 
    },
    phone: { 
        name: 'Телефон', 
        type: PhoneNumber, 
    },
    email: { 
        name: 'E-mail', 
        type: Email,  
    },
    scopeOfActivityLevelOneId: { 
        name: 'Сфера деятельности уровень 1', 
        type: ScopeOfActivitySelect, 
    },
    scopeOfActivityLevelTwoId: { 
        name: 'Сфера деятельности уровень 2', 
        type: ScopeOfActivitySelect,  
    },
    agreement: { 
        name: 'Согласие на обработку перс. даннных', 
        type: CheckBox, 
    },
};

export default model;