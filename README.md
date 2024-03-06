# NeuroMaze - игра-нейроинтерфейс на Unity 2D C#
## Что это такое?
  NeuroMaze - Это тренажер для развития управления концентрацией с помощью шлема ЭЭГ NeuroPlay и программы NeuroPlayPro.
  Обрабатывая альфа- и бета-ритмы нашего мозга приложение NeuroPlayPro показывает вашу концентрацию в текущий момент времени, а NeuroMaze использует эти показатели для управления.
   Проект разработан в качестве демонстрации возможностей переферийного устройства - нейрошлема.
## Что реализовано в рамках проекта:
### Функциональные возможности
1. Создай лабиринт по своим размерам
2. Управляй стрелочкой вручную или с помощью нейрошлема
3. Посмотри результаты своих стренировок
### Технические
1. Разработана [библиотека генерации 2D лабиринтов](https://github.com/LuisanArgoose/MazeLib) с сид-словом и метаданными об окружающих ячейках
2. Реализовано подключение к API приложения NeuroPlayPro для снятия показателей головного мозга
3. Реализовано локальное сохранение результатов игр с помощью сериализации


