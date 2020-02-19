using Abp.Runtime.Validation;

namespace Afonsoft.Portal.MultiTenancy.HostDashboard.Dto
{
    public class GetDashboardDataInput : DashboardInputBase, IShouldNormalize
    {
        public ChartDateInterval IncomeStatisticsDateInterval { get; set; }
        public void Normalize()
        {
            TrimTime();
        }

        private void TrimTime()
        {
            StartDate = StartDate.Date;
            StartDate = StartDate.Date;
        }
    }
}