using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.DBCore.Contexts;
using Students.Models;
using System.Collections.Immutable;

namespace Students.APIServer.Services.EducationFormService
{
    public class EducationFormService : IEducationFormService
    {
        private readonly StudentContext context;
        public EducationFormService(StudentContext context)
        {
            this.context = context;
        }


        /// <summary>
        /// Список форм обучения
        /// </summary>
        /// <returns>Список форм обучения</returns>
        public async Task<List<EducationForm>> GetAll()
        {
            var educationForms = await context.EducationForms.ToListAsync();
            return educationForms;
        }

        /// <summary>
        /// Получить форму обучения по Id
        /// </summary>
        /// <param name="id">Id формы обучения</param>
        /// <returns>Форма обучения</returns>
        public async Task<EducationForm?> GetFormById(Guid id)
        {
            var form = await context.EducationForms.FindAsync(id);
            return form;
        }

        /// <summary>
        /// Новая форма обучения
        /// </summary>
        /// <param name="requestForm">Форма обучения</param>
        /// <returns>Форма обучения</returns>
        public async Task<EducationForm> Create(EducationForm requestForm)
        {
            await context.EducationForms.AddAsync(requestForm);
            await context.SaveChangesAsync();
            return requestForm;
        }

        /// <summary>
        /// Обновить форму обучения
        /// </summary>
        /// <param name="id">Id формы обучения</param>
        /// <param name="requestForm">Форма обучения</param>
        /// <returns>Форма обучения</returns>
        public async Task<EducationForm?> Update(Guid id, EducationForm requestForm)
        {
            var form = await context.EducationForms.FindAsync(id);
            if (form == null)
                return null;
            form.Name = requestForm.Name;
            await context.SaveChangesAsync();
            return form;
        }

        /// <summary>
        /// Удалить форму обучения
        /// </summary>
        /// <param name="id">Id формы обучения</param>
        /// <returns>Removed form</returns>
        public async Task<EducationForm?> Delete(Guid id)
        {
            var form = await context.EducationForms.FindAsync(id);
            if (form == null)
                return null;
            context.EducationForms.Remove(form);
            context.SaveChanges();
            return form;
        }
    }
}
