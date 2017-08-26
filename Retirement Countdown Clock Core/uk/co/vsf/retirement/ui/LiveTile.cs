using NotificationsExtensions;
using NotificationsExtensions.Tiles;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.ui
{
    public class LiveTile
    {
        private const string TITLE = "Retirement Countdown Clock";
        private const string TITLE_SHORT = "R.C.C";
        private const string CALENDAR_DAYS = "Calendar Days";

        private XmlDocument GetTileXml()
        {
            RetirementDate retirementDate = RetirementDateRepositoryImpl.Instance().RetrieveRetirementDate();
            WorkingDaysParameters wdp = WorkingDaysParametersRepositoryImpl.Instance().RetrieveWorkingDaysParameters();

            int daysToRetirement = retirementDate.GetDaysToRetirement();

            TileContent tc = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileWide = BuildWideTile(daysToRetirement),
                    TileMedium = BuildMediumTile(daysToRetirement)
                }
            };

            return tc.GetXml();
        }

        public void Update()
        {
            TileNotification tileNotification = new TileNotification(GetTileXml());
            try {
                TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
            } catch(Exception e)
            {
                // suppress the exception seen in stack traces from Dell Inspiron machines
            }
        }

        public void Reset()
        {
            try {
                TileUpdateManager.CreateTileUpdaterForApplication().Clear();
            } catch (Exception e)
            {
                // suppress the exception seen in stack traces from Dell Inspiron machines
            }
}

        private TileBinding BuildWideTile(int daysToRetirement)
        {
            TileBinding tileWide = new TileBinding()
            {
                DisplayName = TITLE,
                Branding = TileBranding.Name,
                Content = new TileBindingContentAdaptive()
                {
                    Children = {
                        new AdaptiveGroup() {
                            Children = {
                                new AdaptiveSubgroup() {
                                    HintWeight = 1,
                                    Children = {
                                        new AdaptiveText() {
                                            Text = CALENDAR_DAYS,
                                            //HintStyle=AdaptiveTextStyle.Base
                                        }
                                    }
                                }
                            }
                        },
                        new AdaptiveGroup() {
                            

                        }
                    }
                }
            };

            foreach (AdaptiveSubgroup asg in DisplayDays(daysToRetirement))
            {
                IList<ITileAdaptiveChild> ag = ((TileBindingContentAdaptive)tileWide.Content).Children;
                ((AdaptiveGroup)ag[1]).Children.Add(asg);
            }

            return tileWide;
        }

        private TileBinding BuildMediumTile(int daysToRetirement)
        {
            return new TileBinding()
            {
                DisplayName = TITLE_SHORT,
                Branding = TileBranding.Name,
                Content = new TileBindingContentAdaptive()
                {
                    Children = {
                        new AdaptiveGroup() {
                            Children = {
                                new AdaptiveSubgroup() {
                                    HintWeight = 1,
                                    Children = {
                                        new AdaptiveText() {
                                            Text = CALENDAR_DAYS,
                                            HintWrap=true,
                                            HintStyle=AdaptiveTextStyle.CaptionSubtle
                                        },
                                        new AdaptiveText() {
                                            Text = daysToRetirement.ToString()
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        private IList<AdaptiveSubgroup> DisplayDays(int retirementDays)
        {
            IList<AdaptiveSubgroup> children = new List<AdaptiveSubgroup>();

            String days = retirementDays.ToString();
            days = days.PadLeft(5, ' ');
            for (int i = 0; i < days.Length; i++)
            {
                String imageNumber = days[i].ToString();
                children.Add(CreateImageSubgroup(imageNumber));
            }

            return children;
        }

        private AdaptiveSubgroup CreateImageSubgroup(string imageNumber)
        {
            if (" ".Equals(imageNumber, StringComparison.CurrentCultureIgnoreCase))
            {
                imageNumber = "";
            }

            // On a mobile, this looks better if off as it centres the images, but on desktop, it means the images disappear if false...
            bool removeMargin = DeviceType.IsMobile() ? false : true;

            AdaptiveSubgroup asg = new AdaptiveSubgroup()
            {
                HintWeight = 1,
                Children = {
                    new  AdaptiveImage() {
                        Source = $"Assets/numbers/rc{imageNumber}.png",
                        HintRemoveMargin = removeMargin,
                        AlternateText = imageNumber
                    }
                }
            };

            return asg;
        }
    }
}
