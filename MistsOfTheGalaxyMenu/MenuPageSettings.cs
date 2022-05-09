namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Класс управления настройками режима работы меню
    /// </summary>
    public class MenuPageSettings
    {
        /// <summary>
        /// Режим навигации
        /// </summary>
        public NavigationMode NavigationMode { get; set; } 

        /// <summary>
        /// Режим работы с неактивной командой меню
        /// </summary>
        public DisabledItemSelectionMode DisabledItemSelectionMode { get; set; }

        /// <summary>
        /// Создание экземпляра <see cref="MenuPageSettings"/>
        /// </summary>
        /// <param name="navigationMode">Режим навигации меню</param>
        /// <param name="disabledItemSelectionMode">Режим работы с неактивной командой меню</param>
        public MenuPageSettings(NavigationMode navigationMode, DisabledItemSelectionMode disabledItemSelectionMode)
        {
            NavigationMode = navigationMode;
            DisabledItemSelectionMode = disabledItemSelectionMode;
        }
    }
}
