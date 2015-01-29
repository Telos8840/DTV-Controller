using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public interface IScheduleServiceAgent
    {
        void SaveXML();
        void SendSchedule(List<Schedule> schedule, int index);
        void CreateXML();
        Schedule GetSchedule(CoreTeams selTeam, List<Schedule> schedules);
        List<Schedule> SetSchedule();
    }
}
