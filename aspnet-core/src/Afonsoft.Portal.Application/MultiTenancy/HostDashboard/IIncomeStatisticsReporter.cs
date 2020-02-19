using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Afonsoft.Portal.MultiTenancy.HostDashboard.Dto;

namespace Afonsoft.Portal.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}