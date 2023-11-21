using Students.Models;

namespace Students.APIServer.Services.EducationFormService
{
    public interface IEducationFormService
    {
        Task<List<EducationForm>> GetAll();
        Task<EducationForm> GetFormById(Guid id);
        Task<EducationForm> Create(EducationForm requestForm);
        Task<EducationForm?> Update(Guid id, EducationForm requestForm);
        Task<EducationForm?> Delete(Guid id);
    }
}
