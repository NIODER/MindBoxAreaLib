# MindBoxAreaLib
Тестовое на вакансию .net full-stack / back-end

# Описание библиотеки

Библиотека представляет из себя набор классов, унаследованных от интерфейса `IFigure`, что объединяет под собой интерфейсы `IAreaCalculatable` и `IPerimeterCalculatable`. Этот интерфейс заставляет любую фигуру реализовывать две функции: `CanCreate` и `CreateInstance` с одинаковым надобом параметров: список точек, по которым строится фигура, и её дополнительные параметры. `CanCreate` показывает, можно ли по указанному надору параметров создать фигуру этого класса, CreateInstance эту фигуру создает. 

Также есть статический класс фабрики для создания инстансев IFigure, не вдаваясь в подробности реализации фигуры, по точкам и параметрам. Он работает через рефлексию, там я немного накрутил, возможно стоило сделать простую фабрику. Но у такого подхода есть большой плюс - для добавления новых фигур, пересобирать библиотеку необязательно, можно просто реализовать `IFIgure` и добавить класс в пространство `AreaLib.Figures`.
Также была идея сделать класс с маппингами и отдельный интерфейс `IAreaCalculator`, чтобы можно было инжектить разные способы вычисления площади.
В рабочем проекте для такой задачи я бы скорее всего просто использовал фабрику.

# MSSQL

Есть три скрипта: создание примерных таблиц, заполнение примерными данными и выбор, он в скрипте `select_prod-category.sql`, используется left join.
