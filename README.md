# TaskManagerApi

פרויקט דוגמה: ניהול משימות ב-ASP.NET Core (.NET 10), בלי חלוקה לשכבות.
הכול בקונטרולר אחד, Excel (tasks.xlsx) משמש כ-DB, ושליחת מייל דרך SMTP.

## הרצה
1. מלאו ב-appsettings.json את פרטי המייל (ב-Gmail צריך "סיסמת אפליקציה").
2. `dotnet run`
3. בדקו עם הקובץ tasks.http (VS Code עם תוסף REST Client, או Visual Studio).
   אם הפורט שונה מ-5000, עדכנו את host בראש הקובץ.

הקובץ tasks.xlsx נוצר אוטומטית בהוספת המשימה הראשונה. אל תחזיקו אותו פתוח ב-Excel בזמן הרצת הבקשות.

## Endpoints
| שיטה | נתיב | מה עושה |
|---|---|---|
| GET | /api/tasks | כל המשימות |
| POST | /api/tasks | הוספת משימה |
| GET | /api/tasks/search?urgency=High&isDone=false&title=כותרת | חיפוש משימות לפי דחיפות, סטטוס וכותרת (כל הפרמטרים אופציונליים) |
