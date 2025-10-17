namespace DateModifier
{
    public class DateModifier
    {
        public DateModifier() { }

        public int ModifyDates(string date1S, string date2S)
        {
            string[] date1Info = date1S.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int year = int.Parse(date1Info[0]), month = int.Parse(date1Info[1]), day = int.Parse(date1Info[2]);

            DateTime date1 = new DateTime(year, month, day);

            string[] date2Info = date2S.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            year = int.Parse(date2Info[0]);
            month = int.Parse(date2Info[1]);
            day = int.Parse(date2Info[2]);

            DateTime date2 = new DateTime(year, month, day);
            TimeSpan differance = date2 - date1;

            int diffInDays = Math.Abs(differance.Days);
            return diffInDays;
        }
    }
}
