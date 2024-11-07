# Проект «Управление личными делами»

## Краткое описание программного обеспечения
Данное программное обеспечение представляет собой простое приложение для управления личными задачами, разработанное с использованием Windows Forms на C#. Приложение позволяет пользователю добавлять задачи с такими атрибутами, как описание, приоритет, дедлайн и день недели, а также обновлять, просматривать и удалять задачи. Интерфейс обеспечивает автоматический перенос длинных текстов, чтобы пользователь мог видеть полное описание каждой задачи в удобном и минималистичном формате.

## Основные функции
- **Добавление новых задач** с приоритетами и дедлайнами.
- **Выбор конкретного дня недели** для выполнения задачи.
- **Обновление списка задач** с учетом новых записей.
- **Удаление выбранных задач**.
- **Удобное отображение многострочного текста** в ListBox с автоматическим переносом.

## Информация о технической составляющей программного продукта

### Стек технологий
- **Язык программирования**: C#
- **Фреймворк**: .NET Framework (версия 4.7.2 или выше)
- **GUI**: Windows Forms (WinForms)

### Описание реализации
- Программа построена на базе Windows Forms, содержащей элементы управления для добавления, редактирования и отображения задач.
- **ListBox** с поддержкой пользовательского режима рисования (`OwnerDrawVariable`) используется для динамического определения высоты строк, что позволяет отображать многострочный текст.
- **Объект Task** представляет собой отдельную задачу и включает свойства:
  - **Описание** (Description)
  - **Приоритет** (Priority)
  - **Дедлайн** (Deadline)
  - **День недели** (DayOfWeek)
- При добавлении или удалении задачи список в ListBox обновляется, а каждая строка формируется через метод `ToString()` класса `Task`.
- Обработка событий `MeasureItem` и `DrawItem` позволяет корректно отображать и кастомизировать вывод текста.

## Требования к системе
- **Операционная система**: Windows 7 и выше
- **.NET Framework**: версия 4.7.2 или выше
- **Среда разработки**: Visual Studio 2019 или новее для сборки и запуска исходного кода

## Информация об авторских правах и лицензировании
Настоящее программное обеспечение защищено авторским правом. Все права на него принадлежат Овсепян Анаит Арменовне (ЗФ РАНХиГС), и его части не могут быть воспроизведены или использованы без предварительного письменного согласия правообладателя. 

Программное обеспечение предоставляется без каких-либо явных или неявных гарантий, и разработчик не несет ответственности за любые убытки или повреждения, возникающие в результате его использования. Вы имеете право использовать, копировать и изменять программное обеспечение, при условии предварительной договоренности с разработчиком. Распространять программное обеспечение или его производные без согласия правообладателя запрещено.