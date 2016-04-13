using System;

public class Event
{
    private String name;
    private String description;
    private String start_time;
    private String end_time;
    private int day;

    public Event()
    {
        name = "empty";
        start_time = "00:00";
        end_time = "00:00";
        description = "empty";
        day = 0;
    }

    public Event(String n, String desc, String start, String end, int d)
    {
        name = n;
        description = desc;
        start_time = start;
        end_time = end;
        day = d;
    }

    public void setName(String n)
    {
        name = n;
    }

    public void setDescription(String desc)
    {
        description = desc;
    }

    public void setStart(String start)
    {
        start_time = start;
    }

    public void setEnd(String end)
    {
        end_time = end;
    }

    public void setDay(int d)
    {
        day = d;
    }

    public String getName()
    {
        return name;
    }

    public String getDescription()
    {
        return description;
    }

    public String getStart()
    {
        return start_time;
    }

    public String getEnd()
    {
        return end_time;
    }

    public int getDay()
    {
        return day;
    }
}