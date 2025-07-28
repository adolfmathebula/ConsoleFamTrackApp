using System;

namespace FamilyTracker.Services
{
    public static class Formatter
    {
        public static string GetFormattedAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;

            int years = today.Year - birthDate.Year;
            int months = today.Month - birthDate.Month;

            if (today.Day < birthDate.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            if (years > 0 && months > 0)
                return $"{years} year{(years > 1 ? "s" : "")} {months} month{(months > 1 ? "s" : "")}";
            else if (years > 0)
                return $"{years} year{(years > 1 ? "s" : "")}";
            else
                return $"{months} month{(months > 1 ? "s" : "")}";
        }
    }
}
