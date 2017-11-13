using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.ui
{
    public class TileManager
    {
        private const string TASK_NAME = "RetirementCountdownClockBackgroundTask";
        private const string TASK_ENTRY_POINT = "Retirement_Countdown_Clock_Runtime_Component.uk.co.vsf.retirement.task.TileUpdateTimer";

        private static TileManager _instance;
        private RetirementDateRepository _retirementDateRepository = RetirementDateRepositoryImpl.Instance();

        public static TileManager Instance()
        {
            if(_instance == null)
            {
                _instance = new TileManager();
            }

            return _instance;
        }

        public async void RegisterLiveTileUpdates()
        {
            if (this._retirementDateRepository.IsRetirementDateStored())
            {
                var backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();
                UnRegisterIfExists();

                if ((int)backgroundAccessStatus == 1 ||
                    (int)backgroundAccessStatus == 2 ||
                    (int)backgroundAccessStatus == 4 ||
                    (int)backgroundAccessStatus == 5)
                {
                    RegisterTask();

                    // finally - run the Tile Update
                    LiveTile tile = new LiveTile();
                    tile.Update();
                }
            }
        }

        private void RegisterTask()
        {
            BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder();
            taskBuilder.Name = TASK_NAME;
            taskBuilder.TaskEntryPoint = TASK_ENTRY_POINT;
            taskBuilder.SetTrigger(new TimeTrigger(15, false));
            taskBuilder.Register();
        }

        private void UnRegisterIfExists()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == TASK_NAME)
                {
                    task.Value.Unregister(true);
                }
            }
        }

        public void RemoveLiveTileUpdates()
        {
            UnRegisterIfExists();
            LiveTile tile = new LiveTile();
            tile.Reset();
        }
    }
}
