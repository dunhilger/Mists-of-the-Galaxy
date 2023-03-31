# Mists-of-the-Galaxy-Menu

## Описание

Меню поддерживает возможность создания кастомной структуры и схемы навигации по страницам, добавления опциональных команд, а также создания пользовательских тем цветового оформления.
 

## Использование

В качестве примера будет построено четырехстраничное меню для консольной игры. Страницы следущие:

1. Главная страница(переход на 2 страницу)

2. Страница выбора настроек(переход на 3 и 4 страницу)

3. Страница выбора режима сложности игры(возврат на 2 старницу)

4. Страница выбора цветовой темы оформления меню(возврат на 1 страницу)

#### Создание команд

Команды меню могут быть: 

* Опциональными - MenuItemOptional(при активации могут быть отмечены индикатором "√") 
* Неопциональными - MenuItem

Создание команды выглядит следующим образом:

    new MenuItemOptional(param1, param2, param3)
    
либо
    
    new MenuItem(param1, param2, param3)
    
где param1 - название команды, param2 - булево свойство доступности команды, param3 - делегат, ссылающийся на заданное действие при активации команды.

#### Создание страниц и структуры меню

Для создания страницы нужно объявить и инициализировать переменную типа List\<IMenuItem\>, которая будет хранить список команд. Так, например, создадим первую страницу меню. Список команд следующий:
 
    var mainMenuCommands = new List<IMenuItem>
            {
                new MenuItem("Новая игра", true, _noAction),
                new MenuItem("Продолжить", false, _noAction),
                new MenuItem("Настройки", true, n => n.NavigateToNextPage(page_2)),
                new MenuItem("Выход", true, n => n.CloseMenu()),
            };
            
 Описание команд данной страницы:
 
 1. Начало новой игровой сессии, команда доступна - ее можно активировать, команда ничего не выполняет - вместо действия установлена заглушка
 2. Продолжение игровой сессии, команда неактивна - активировать ее нельзя, команда ничего не выполняет
 3. Настройки игры, команда доступна, выполняет навигацию на страницу 2
 4. Выход из меню, команда доступна, выполняет закрытие меню 
 
 Затем инициализируем переменную page_1 типа MenuPageItemList, и в качестве параметра передадим список команд, созданный выше:
 
    var page_1 = new MenuPageItemList(mainMenuCommands);
 
 Аналогично будет создана страница 2:
 
    var mainSettings = new List<IMenuItem>
            {
                new MenuItem("Уровень сложности", true, n => n.NavigateToNextPage(page_3)),
                new MenuItem("Тема", true, n => n.NavigateToNextPage(page_4)),
            };
            var page_2 = new MenuPageItemList(mainSettings);
 
 Страница 3:
 
    var selectGameMode = new List<IMenuItem>
            {
                new MenuItemOptional("Простой", true, _noAction),
                new MenuItemOptional("Средний", true, _noAction),
                new MenuItemOptional("Сложный", true, _noAction),
                new MenuItem("Назад", true, n => n.TurnToPreviousPage()),
            };
            var page_3 = new MenuPageItemList(selectGameMode);
 
 Страница 4:
 
    var selectMenuTheme = new List<IMenuItem>
            {
                new MenuItemOptional("Светлая", true, d => d.SetTheme(lightTheme)),
                new MenuItemOptional("Темная", true, d => d.SetTheme(darkTheme)),
                new MenuItem("На главную", true, n => n.TurnToMainPage()),
            };
            var page_4 = new MenuPageItemList(selectMenuTheme);

#### Создание меню

Для создания меню объявим переменную menu типа Menu и в качестве параметра передадим первую(корневую) страницу структуры меню page_1

    var menu = new Menu(page_1);
    
Меню поддерживает необязательный параметр темы оформления. Такая тема будет применена по умолчанию

    var menu = new Menu(page_1, defaultTheme);
    
Затем нужно вызвать метод DisplayMenu и в качестве параметра передать в него объект menu

    DisplayMenu(Menu);
    
Готовое меню в консоли будет выглядеть следующим образом:

* страница 1

![image](https://user-images.githubusercontent.com/55708187/228007062-f30c6cfa-a076-4a6d-a446-76c31174ac3d.png)

* страница 2

![image](https://user-images.githubusercontent.com/55708187/228007234-50810f8b-1c2d-4da3-bdf1-1a06768ddbe8.png)

* страница 3

![image](https://user-images.githubusercontent.com/55708187/228007360-ae2529b8-c112-4add-a327-928201673d2e.png)

* страница 4

![image](https://user-images.githubusercontent.com/55708187/228007463-a7d36084-ce4e-497e-a07a-21f7fab31c59.png)

Для навигации используются клавиши:

* PgUp/Home/клавиши 4 и 8 на допклавиатуре - навигация курсора вверх
* PgDn/End/клавиши 2 и 6 на допклавиатуре - навигация курсора вниз
* Backspace - возврат на предыдущую страницу
* Enter - активация команды меню, обозначенной курсором

#### Создание темы меню

На странице 4 меню предложены 2 темы: lightTheme и darkTheme. Для создания своей темы нужно объявить переменную, например, myTheme типа 
MenuTheme и задать значения для свойств объекта темы:

    var myTheme = new MenuTheme()
            {
                // Цвет рамки
                FrameColor = ConsoleColor.DarkGreen,
                // Цвет шрифта
                TextColor = ConsoleColor.Blue,
                // Цвет курсора
                CursorColor = ConsoleColor.DarkRed,
                // Цвет фона недоступной команды
                DisabledBackgroundColor = ConsoleColor.White,
                // Цвет шрифта недоступной команды
                DisabledTextColor = ConsoleColor.Magenta
                
            };
            
Полученная стилизация:
            
![image](https://user-images.githubusercontent.com/55708187/229156835-f4900749-9bd7-455a-a09e-3a95f53f0c2a.png)

#### Изменение режимов работы меню

Меню поддерживает следующие виды режимов работы:
1. Режим навигации курсора:
* Циклический(LoopOn) - курсор, при достижении последней команды на странице, и последующем нажатии PgDn, перемещается на первую команду,
                        также работает в обратном направлении
* Нециклический(LoopOff) - курсор, при достижении последней команды на странице, и последующем нажатии PgDn, остается на текущей позиции
2. Режим работы с неактивными командами
* Выбор(Select) - позволяет устанавливать курсор на неактивные команды меню
* Пропуск(Skip) - позволяет курсору "проскакивать" неактивные команды меню

Установить режимы работы меню можно при создании экземпляра класса Menu

    var menu = new Menu(page_1)
            {
                DisabledItemSelectionMode = DisabledItemSelectionMode.Select,
                NavigationMode = NavigationMode.LoopOn
            };

