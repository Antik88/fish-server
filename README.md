## Как запустить проект:
### Через терминал cmd
  - Клонировать репозиторий: `git clone https://github.com/Antik88/fish-server.git`
  - Перейти в директорию с проектом: `cd fish-server\Wpf_Mvc_Proj`
  - Выполнить команду для запуска приложения: `dotnet run`
  - Сервер будет доступен на `http://localhost:5154`
### Использую VisualStudio
  - Клонировать репозиторий: `git clone https://github.com/Antik88/fish-server.git`
  - Открыть директорию с проектом
  - Дважды нажать на файл `Wpf_Mvc_Proj.sln`
  - В открывшейся VisualStudio запустить проект
### База данных
Для того чтобы можно было протестировать как приложение работает с БД нужно:
  - Восстановить базу данных MySql из файла `fish.sql` который находиться в корне проекта
  - Изменить строку `DefaultConnection` в файле `appsettings.json` на свою 
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=fish;User=root;Password=Password;"
  },
```
