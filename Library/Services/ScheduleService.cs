﻿using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ApplicationDbContext _scheduleContext;

        public ScheduleService(ApplicationDbContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        //Testas ej, men används i tester
        public List<Schedule> GetAllSchedules()
            => _scheduleContext.Schedules.OrderBy(s => s.UserId).ToList();

        public void AddSchedule(Schedule schedule)
        {

            if (schedule != null)
            {
                _scheduleContext.Schedules.Add(schedule);
                _scheduleContext.SaveChanges();
            }
          
        }
        public Schedule? GetScheduleById(int? scheduleId)
            => _scheduleContext.Schedules.Where(s => s.Id == scheduleId).SingleOrDefault();

        public void UpdateSchedule(string oldString, string newString) 
        {
            var scheduleToBeUpdates = _scheduleContext.Schedules.FirstOrDefault(x => x.UserId == oldString);

            if (scheduleToBeUpdates != null)
            {
                scheduleToBeUpdates.UserId = newString;
                _scheduleContext.Schedules.Update(scheduleToBeUpdates);
                _scheduleContext.SaveChanges();
            }
        }
        public void DeleteScheduleByScheduleId(int? scheduleId, Schedule? schedule)
        {
            schedule = GetScheduleById(scheduleId);

            _scheduleContext.Remove(schedule);
            _scheduleContext.SaveChanges();
        }

        //Testas ej, men används i tester
        public Schedule? GetScheduleByUserId(string? userId)
        => _scheduleContext.Schedules.Where(s => s.UserId == userId).FirstOrDefault();
    }
}
