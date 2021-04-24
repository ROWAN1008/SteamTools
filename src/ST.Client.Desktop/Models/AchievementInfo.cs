﻿using System.Application.Services;
using System.Globalization;
using System.Threading.Tasks;
using static System.Application.SteamApiUrls;

namespace System.Application.Models
{
    public class AchievementInfo
    {
        public int AppId { get; set; }

        public string? Id { get; set; }

        public float Percent { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? IconNormal { get; set; }

        public string? IconLocked { get; set; }

        public bool IsHidden { get; set; }

        public bool IsAchieved { get; set; }

        public bool IsChecked { get; set; }

        public long UnlockTimeUnix { get; set; }

        public DateTime UnlockTime { get; set; }

        public string IconUrl => string.Format(
            STEAMAPP_ICON_URL,
            AppId,
            IsAchieved ? IconNormal : IconLocked);

        public Task<string?> IconStream => IHttpService.Instance.GetImageAsync(IconUrl, ImageChannelType.SteamAchievementIcon);

        public int Permission { get; set; }

        public bool IsProtection => (Permission & 3) != 0;

        public override string ToString()
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                "{0}: {1}",
                Name ?? Id ?? base.ToString(),
                Permission);
        }
    }
}