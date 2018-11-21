using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BabysitterKata.Models;

namespace BabysitterKata.Controllers
{
    public class CalculationController : ApiController
    {
        [HttpPost, Route("api/calculation")]
        public int GetCalculation(CalculationViewModel calculationVm)
        {
            return CalculateTotalPay(calculationVm.Family, calculationVm.StartTime, calculationVm.EndTime);
        }

        /**
         * starts no earlier than 5:00PM
         * leaves no later than 4:00AM
         * only babysits for one family per night
         * gets paid for full hours (no fractional hours)
         * should be prevented from mistakes when entering times 
         * (e.g. end time before start time, or outside of allowable work hours)
         * The job pays different rates for each family (based on bedtimes, kids and pets, etc...)
         * Family A pays $15 per hour before 11pm, and $20 per hour the rest of the night
         * Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
         * Family C pays $21 per hour before 9pm, then $15 the rest of the night
         * The time ranges are the same as the babysitter (5pm through 4am)
         */
        private int CalculateTotalPay(string family, string startTime, string endTime)
        {
            var totalPay = 0;

            switch (family)
            {
                case "A":
                    var cutOff1 = 23;
                    var firstHours = cutOff1 - int.Parse(startTime);
                    var lastHours = 0;

                    if (int.Parse(endTime) >= cutOff1)
                    {
                        lastHours = int.Parse(endTime) - cutOff1;
                    }

                    totalPay = 15 * firstHours + 20 * lastHours;
                    break;
                case "B":
                    cutOff1 = 22;
                    var cutOff2 = 24;
                    firstHours = cutOff1 - int.Parse(startTime);
                    var secondHours = 0;
                    lastHours = 0;

                    if (int.Parse(endTime) >= cutOff2)
                    {
                        secondHours = cutOff2 - cutOff1;
                        lastHours = int.Parse(endTime) - cutOff2;
                    }
                    else if (int.Parse(endTime) >= cutOff1)
                    {
                        secondHours = cutOff2 - cutOff1;
                    }

                    totalPay = 12 * firstHours + 8 * secondHours + 16 * lastHours;
                    break;
                case "C":
                    cutOff1 = 21;
                    firstHours = cutOff1 - int.Parse(startTime);
                    lastHours = 0;

                    if (int.Parse(endTime) >= cutOff1)
                    {
                        lastHours = int.Parse(endTime) - cutOff1;
                    }

                    totalPay = 21 * firstHours + 15 * lastHours;
                    break;
            }

            return totalPay;
        }
    }
}
