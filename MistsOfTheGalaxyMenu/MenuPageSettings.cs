namespace MistsOfTheGalaxyMenu
{
    public class MenuPageSettings
    {
        public NavigationMode NavigationMode { get; } 
        public DisabledItemSelectionMode DisabledItemSelectionMode { get; set; } 

        public MenuPageSettings(NavigationMode navigationMode, DisabledItemSelectionMode disabledItemSelectionMode)
        {
            NavigationMode = navigationMode;
            DisabledItemSelectionMode = disabledItemSelectionMode;
        }
    }
}
