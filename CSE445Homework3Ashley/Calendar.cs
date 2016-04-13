using System;

    public class Calendar
    {
        private Day[] days;
        private int count;
        private string[] time_array;

        public Calendar()
        {
            count = 7;
            days = new Day[count];
            for (int i = 0; i < count; i++ )
            {
                days[i] = new Day();
            }
                time_array = new String[30];
            time_array[0] = "06:00AM";
            time_array[1] = "06:30AM";
            time_array[2] = "07:00AM";
            time_array[3] = "07:30AM";
            time_array[4] = "08:00AM";
            time_array[5] = "08:30AM";
            time_array[6] = "09:00AM";
            time_array[7] = "09:30AM";
            time_array[8] = "10:00AM";
            time_array[9] = "10:30AM";
            time_array[10] = "11:00AM";
            time_array[11] = "11:30AM";
            time_array[12] = "12:00PM";
            time_array[13] = "12:30PM";
            time_array[14] = "01:00PM";
            time_array[15] = "01:30PM";
            time_array[16] = "02:00PM";
            time_array[17] = "02:30PM";
            time_array[18] = "03:00PM";
            time_array[19] = "03:30PM";
            time_array[20] = "04:00PM";
            time_array[21] = "04:30PM";
            time_array[22] = "05:00PM";
            time_array[23] = "05:30PM";
            time_array[24] = "06:00PM";
            time_array[25] = "06:30PM";
            time_array[26] = "07:00PM";
            time_array[27] = "07:30PM";
            time_array[28] = "08:00PM";
            time_array[29] = "08:30PM";
        }

        public Calendar(int num)
        {
            count = num;
            days = new Day[count];
            for (int i = 0; i < count; i++)
            {
                days[i] = new Day();
            }
            time_array = new String[30];
            time_array[0] = "06:00AM";
            time_array[1] = "06:30AM";
            time_array[2] = "07:00AM";
            time_array[3] = "07:30AM";
            time_array[4] = "08:00AM";
            time_array[5] = "08:30AM";
            time_array[6] = "09:00AM";
            time_array[7] = "09:30AM";
            time_array[8] = "10:00AM";
            time_array[9] = "10:30AM";
            time_array[10] = "11:00AM";
            time_array[11] = "11:30AM";
            time_array[12] = "12:00PM";
            time_array[13] = "12:30PM";
            time_array[14] = "01:00PM";
            time_array[15] = "01:30PM";
            time_array[16] = "02:00PM";
            time_array[17] = "02:30PM";
            time_array[18] = "03:00PM";
            time_array[19] = "03:30PM";
            time_array[20] = "04:00PM";
            time_array[21] = "04:30PM";
            time_array[22] = "05:00PM";
            time_array[23] = "05:30PM";
            time_array[24] = "06:00PM";
            time_array[25] = "06:30PM";
            time_array[26] = "07:00PM";
            time_array[27] = "07:30PM";
            time_array[28] = "08:00PM";
            time_array[29] = "08:30PM";
        }

        public int getCount()
        {
            return count;
        }

        public void setCount(int num)
        {
            count = num;
            days = new Day[count];
        }

        public Day[] getDays()
        {
            return days;
        }

        public String[] getTimeArray()
        {

            return time_array;
        }
    }

