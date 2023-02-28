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
            var inputDate = _date.Date;

            if (_period == null) return false;

            if (periodType == null) return false;

            if (!IsBetweenStartEndDay(_period, inputDate))
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
                return DayOfMonth(periodDate, inputDate, 1, _period.IsWorkingDayAdjustment);
            }

            //день в квартал
            if (periodType == EnumManager.EPeriodPeriod[6])
            {
                return DayOfMonth(periodDate, inputDate, 3, _period.IsWorkingDayAdjustment);
            }

            //день в півріччя
            if (periodType == EnumManager.EPeriodPeriod[7])
            {
                return DayOfMonth(periodDate, inputDate, 6, _period.IsWorkingDayAdjustment);
            }

            //день в рік
            if (periodType == EnumManager.EPeriodPeriod[8])
            {
                return DayOfMonth(periodDate, inputDate, 12, _period.IsWorkingDayAdjustment);
            }

            return false;
        }

        static bool DayOfMonth(DateTime _periodDate, DateTime _inputDate, int _month, bool IsWorkingDay)
        {
            DateTime periodDate = _periodDate;
            DateTime inputDate = _inputDate;

            int dif = (inputDate.Year - periodDate.Year) * 12;
           
            if (((inputDate.Month + dif) - periodDate.Month) % _month == 0)
            {

                periodDate = OverMonthConverter(periodDate, inputDate);

                if (IsWorkingDay)
                {
                    if (inputDate.DayOfWeek == DayOfWeek.Friday)
                    {
                        if ((inputDate.AddDays(1).Day == periodDate.Day) | (inputDate.AddDays(2).Day == periodDate.Day))
                        {
                            return true;
                        }
                    }

                    if (inputDate.DayOfWeek == DayOfWeek.Saturday | inputDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        return false;
                    }
                }

                if (inputDate.Day == periodDate.Day)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        static DateTime OverMonthConverter(DateTime _periodDate, DateTime _inputDate)
        {
            if (_periodDate.Day == 28 | _periodDate.Day == 29 | _periodDate.Day == 30 | _periodDate.Day == 31)
            {
                if (DateTime.DaysInMonth(_inputDate.Year, _inputDate.Month) < _periodDate.Day)
                {
                    if (_inputDate.Day == DateTime.DaysInMonth(_inputDate.Year, _inputDate.Month))
                    {
                        return Convert.ToDateTime($"{_inputDate.Day}.{_periodDate.Month}.{_periodDate.Year}").Date;
                    }
                }
            }
            return _periodDate;
        }

        static bool IsBetweenStartEndDay(PeriodClass _period, DateTime _date)
        {
            if (_date >= _period.StartDate.Date & _date <= _period.EndDate.Date)
            {
                return true;
            }
            return false;
        }
    }
}

