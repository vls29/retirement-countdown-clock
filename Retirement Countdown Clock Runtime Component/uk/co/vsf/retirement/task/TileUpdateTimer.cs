using NotificationsExtensions;
using NotificationsExtensions.Tiles;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.repository;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace Retirement_Countdown_Clock_Runtime_Component.uk.co.vsf.retirement.task
{
    public sealed class TileUpdateTimer : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            UpdateTile();
        }

        private void UpdateTile()
        {
            LiveTile tile = new LiveTile();
            tile.Update();
        }
    }
}
