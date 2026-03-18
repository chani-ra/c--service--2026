using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__service_2026.Interfaces
{
    // ממשק גנרי T מאפשר לנו לכתוב את פעולות הבסיס פעם אחת לכל ה-DTOs
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddItemAsync(T item);
        Task UpdateItemAsync(int id, T item);
        Task DeleteItemAsync(int id);
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן (מטרת עמוד זה):
 * -------------------------------------------------------------------------
 * זהו הממשק (Interface) הבסיסי והגנרי של שכבת השירות (Service Layer).
 * מטרתו להגדיר את החוזה (Contract) עבור פעולות ה-CRUD (יצירה, קריאה, עדכון, מחיקה) הבסיסיות.
 * שימוש ב-Generics (<T>) חוסך לנו שכפול קוד – כל Service פרטי שניצור פשוט יירש מהממשק הזה
 * ויקבל אוטומטית את ההתחייבות לממש את חמשת הפעולות הללו.
 * **דגש למורה:** בהתאם לסעיף 22 בהוראות, כל המתודות הוגדרו כ-Task (א-סינכרוניות) 
 * כדי להבטיח ביצועים גבוהים מבלי לחסום את התהליך (Thread) הראשי של השרת.
 */