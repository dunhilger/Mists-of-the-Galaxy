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

#### Создание страниц

Для создания страницы нужно ввести и инициализировать переменную типа List\<IMenuItem\>, которая будет хранить список команд. Так, например, создадим первую страницу меню. Список команд следующий:
 
    var mainMenuCommands = new List<IMenuItem>
            {
                new MenuItem("Новая игра", true, _noAction),
                new MenuItem("Продолжить", false, _noAction),
                new MenuItem("Настройки", true, n => n.NavigateToNextPage(page_2)),
                new MenuItem("Выход", true, n => n.CloseMenu()),
            };
 
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
