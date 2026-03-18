using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__service_2026.Interfaces
{
    public interface IService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddItemAsync(T item);
        Task UpdateItemAsync(int id, T item);
        Task DeleteItemAsync(int id);
    }
}
/*
 * מטרת הקובץ (IService - Generic Interface):
 * זהו ממשק התשתית לכל השירותים במערכת. 
 * הוא מגדיר את פעולות ה-CRUD הבסיסיות שכל Service חייב לממש.
 * שינוי קריטי: כל הפונקציות הוגדרו כ-Task א-סינכרוני כדי לאפשר עבודה יעילה מול ה-Repository 
 * ומסד הנתונים, בהתאם לדרישה מס' 22 בהוראות המורה.
 */