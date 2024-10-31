// ReSharper disable UnusedMember.Global

using Celeste.Mod;

namespace CelesteDeathTracker
{
    public class DeathTrackerSettings : EverestModuleSettings
    {
        private string _displayFormat = "$C ($B)";

        public bool AutoRestartChapter { get; set; } = false;

        [SettingMaxLength(48)]
        public string DisplayFormat
        {
            get => _displayFormat;
            set => _displayFormat = value.Contains("{0}") || value.Contains("{1}")
                ? string.Format(value, "$C", "$B")
                : value;
        }

        [SettingRange(0, 105)]
        public int DisplayYPosition { get; set; } = 16;

        public bool FixedYPosition { get; set; } = false;

        public VisibilityOption DisplayVisibility { get; set; } = VisibilityOption.AfterDeathAndInMenu;

        public enum VisibilityOption
        {
            Disabled,
            AfterDeath,
            InMenu,
            AfterDeathAndInMenu,
            Always
        }

        public string Patata = "holi";

        public ExportToFileSubmenu ExportToFileMenu { get; set; } = new ExportToFileSubmenu();
    }

    [SettingSubMenu]
    public class ExportToFileSubmenu
    {
        public bool ExportToFile { get; set; } = false;

        public bool ExportSameFormatAsDisplay { get; set; } = true;
        
        public string _exportToFileFormat = "$C ($B)";
    }
}
