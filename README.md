# XMLTask

## Запуск решения

1. Скачать репоситорий.
2. Открыть решение в VS.
3. Добавить в startup настройки два проекта DataProcessor, FileParser.
4. Запустить проекты.

Добавлять файлы Xml нужно через FileParser/XMLs и в appsettings.json указывать название файлов.

База данных находиться в DataProcessor\bin\Debug\net8.0, дефолтное название local.db. В базе уже находяться дынные и проект не будет добавлять данные с существующими PackageID.