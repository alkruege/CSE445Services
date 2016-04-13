using System;

public class Day
{
    private int date;
    private Event[] schedule;
    private String name;

	public Day()
	{
        date = 0;
        //scheduling in half hour increments from 6am-9pm
        schedule = new Event[30];
        for (int i = 0; i < 30; i++ )
        {
            schedule[i] = new Event();
        }
            name = "empty";
	}

    public Day(int d)
    {
        date = d;
        schedule = new Event[30];
        for (int i = 0; i < 30; i++)
        {
            schedule[i] = new Event();
        }
        name = "initialized";
    }

    public void setDate(int d)
    {
        date = d;
    }

    public int getDate()
    {
        return date;
    }

    public Event[] getSchedule()
    {
        return schedule;
    }
}
