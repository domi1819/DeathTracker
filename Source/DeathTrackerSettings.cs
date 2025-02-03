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

        // Options added for file exporting
        public ExportToFileSubmenu ExportToFileOptions { get; set; } = new ExportToFileSubmenu();
    }

    [SettingSubMenu]
    public class ExportToFileSubmenu
    {
		[SettingSubText("Decides if 'deathTrackerOutput.txt' is created in the path folder.\nDefault location is the Celeste install folder.")]
		public bool ExportToFile { get; set; } = false;

        [SettingMaxLength(200)]
        [SettingSubText("You can change the path with this option.\nDefault value is ./ that works as the installation folder.")]
        public string Path { get; set; } = "./";

		public bool ExportSameFormatAsDisplay { get; set; } = true;

		private string _exportFormat = "$C ($B)";

		[SettingMaxLength(48)]
		[SettingSubText("This option only works if above option is ON.\nUsing $N will be replaced with a new line in the output file.")]
		public string ExportFormat
		{
			get => _exportFormat;
			set => _exportFormat = value.Contains("{0}") || value.Contains("{1}")
				? string.Format(value, "$C", "$B")
				: value;
		}

	}
}
