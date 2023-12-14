# Sea Battle
##В данном проекте содержиться исходный код всего приложения.
Файлы gameLog.txt и lastGame.txt - текстовые файлы, содержащие журнал с отчетами о матчах и сохранение последней игры соответственно.  
Внутри папки SeaBattle содержатся файлы с кодом программы:
- FormSeaBattle.Designer.cs - файл с кодом дизайнера основной формы
- FormSeaBattle.cs - файл с кодом самой основной формы
- MatchesLogForm.Designer.cs - файл с кодом дизайнера формы для показа журнала матчей
- MatchesLogForm.cs - файл с кодом самой формы для показа журнала матчей
- MyDB.cs - файл с кодом для конфигурации подключения к базе данных и работы с ней
- Program.cs - основной код приложения (запускает главную форму)
- ShowDataBaseForm.Designer.cs - файл с кодом дизайнера формы для показа содержимого базы данных
- ShowDataBaseForm.cs - файл с кодом самой формы для показа содержимого базы данных
- KP_dbDataSet.Designer.cs .xsd .xss .xsc - файлы с кодом конфигурации заполнения элемента DataGridView
- SeaBattleAI.cs - файл с кодом абстрактного класса SeaBattleAI()
- SeaBattleAIClassicModuleRandomSide.cs - файл с кодом класса SeaBattleAIClassicModuleRandomSide() - Поиск от самого большого до самого маленького кораблей
- SeaBAttleAIRandom.cs - файл с кодом класса SeaBAttleAIRandom() - случайный обстрел поля
- SeaBattleAILongesLineFinding.cs - файл с кодом класса SeaBattleAILongesLineFinding() - поиск самой длинной "чистой линии"
- SeaBattleLogger.cs - файл с кодом класса SeaBattleLogger() - класс логирования игры
- SeaBattleField.cs - файл с кодом класса SeaBattleField() - класс для поля игры
