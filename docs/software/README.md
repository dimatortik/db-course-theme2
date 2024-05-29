# Реалізація інформаційного та програмного забезпечення
  
## SQL-Скрипт для створення початкового наповнення бази даних

```sql
<!-- @include: ./sql/db.sql -->
```

## RESTfull сервіс для управління даними

### ApiController для створення та виводу змін в файлі датасету
```csharp
<!-- @include: ./restfullApi/controller.cs -->
```

### Підключення до бази даних та конфігурації для створення моделей
```csharp
<!-- @include: ./restfullApi/dbContext.cs -->
```

### Cервіс для створення та виводу змін в файлі датасету
```csharp
<!-- @include: ./restfullApi/updateDatafileService.cs -->
```
### Сервіс для логуванні змін у файлі
```csharp
<!-- @include: ./restfullApi/changeTrackerService.cs -->
```
### DTO для запиту на зміну в файлі датасету
```csharp
<!-- @include: ./restfullApi/updateRequest.cs -->
```
### DTO для відповіді на зміну в файлі датасету
```csharp
<!-- @include: ./restfullApi/updateResponse.cs -->
```

### DTO для перевірки на зміни в файлі датасету
```csharp
<!-- @include: ./restfullApi/updateForChangeCheck.cs -->
```
