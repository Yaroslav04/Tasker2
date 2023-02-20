using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.Engine
{
    public static class PeriodParser
    {
        public static bool IsPeriod(PeriodClass _period, DateTime _date)
        {
            var periodDate = _period.StartDate.Date;
            var periodType = _period.Period;
            var inputDate = _date;

            if (periodType == null) return false;

            if (periodDate < IsWorkingDayConverter(_period.IsWorkingDayAdjustment, inputDate)) return false; 

       
            if (!IsBetweenStartEndDay(_period, IsWorkingDayConverter(_period.IsWorkingDayAdjustment, inputDate)))
            {
                return false;
            }

            //одноразово
            if (periodType == EnumManager.EPeriodPeriod[0])
            {
                if (periodDate == inputDate)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //кожен день
            if (periodType == EnumManager.EPeriodPeriod[1])
            {
                return true;
            }

            //кожен будній день
            if (periodType == EnumManager.EPeriodPeriod[2])
            {
                if (inputDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    return false;
                }
                else if (inputDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            //вихідні дні
            if (periodType == EnumManager.EPeriodPeriod[3])
            {
                if (inputDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    return true;
                }
                else if (inputDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //день тижня
            if (periodType == EnumManager.EPeriodPeriod[4])
            {
                if (inputDate.DayOfWeek == periodDate.DayOfWeek)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //день місяця
            if (periodType == EnumManager.EPeriodPeriod[5])
            {
                inputDate = IsWorkingDayConverter(_period.IsWorkingDayAdjustment, inputDate);

                if (periodDate.Day == 28 | periodDate.Day == 29 | periodDate.Day == 30 | periodDate.Day == 31)
                {
                    if (DateTime.DaysInMonth(inputDate.Year, inputDate.Month) < periodDate.Day)
                    {
                        return true;
                    }
                }

                if (inputDate.Day == periodDate.Day)
                {
                    return true;
                }

                return false;
            }

            //день в квартал
            if (periodType == EnumManager.EPeriodPeriod[6])
            {
                DayOfMonth(_period, IsWorkingDayConverter(_period.IsWorkingDayAdjustment, inputDate), 3);
            }

            //день в півріччя
            if (periodType == EnumManager.EPeriodPeriod[7])
            {
                DayOfMonth(_period, IsWorkingDayConverter(_period.IsWorkingDayAdjustment, inputDate), 6);
            }

            //день в рік
            if (periodType == EnumManager.EPeriodPeriod[8])
            {
                DayOfMonth(_period, IsWorkingDayConverter(_period.IsWorkingDayAdjustment, inputDate), 12);
            }

            return false;        
        }

        static bool IsBetweenStartEndDay(PeriodClass _period, DateTime _date)
        {
            if (_date >= _period.StartDate.Date & _date <= _period.EndDate.Date)
            {
                return true;
            }
            return false;
        }

        static bool DayOfMonth(PeriodClass _period, DateTime _date, int _month)
        {
            if (MonthConverter(_period.StartDate.Month + _month) == _date.Month)
            {
                if (_period.StartDate.Day == 28 | _period.StartDate.Day == 29 | _period.StartDate.Day == 30 | _period.StartDate.Day == 31)
                {
                    if (DateTime.DaysInMonth(_date.Year, _date.Month) < _period.StartDate.Day)
                    {
                        return true;
                    }
                }

                if (_date.Day == _period.StartDate.Day)
                {
                    return true;
                }
            }   
            
            return false;
        }

        public static int MonthConverter(int _month)
        {
            if (_month > 12)
            {
                return _month - 12;
            }
            return _month;
        }

        public static DateTime IsWorkingDayConverter(bool _convert, DateTime _date)
        {
            if (_convert)
            {
                if (_date.DayOfWeek == DayOfWeek.Saturday)
                {
                     return _date.AddDays(-1);
                }

                if (_date.DayOfWeek == DayOfWeek.Wednesday)
                {
                    return _date.AddDays(-2);
                }

                return _date;
            }

            return _date;
        }
    }
}
