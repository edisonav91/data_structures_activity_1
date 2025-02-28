using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClass1;

public class Time
{
    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;

    public Time()
    {
        _hour = 0;
        _minute = 0;
        _second = 0;
        _millisecond = 0;
    }
    public Time(int hour)
    {
        _hour = ValidateHour(hour);
        _minute = 0;
        _second = 0;
        _millisecond = 0;
    }
    public Time(int hour, int minute)
    {
        _hour = ValidateHour(hour);
        _minute = ValidateMinute(minute);
        _second = 0;
        _millisecond = 0;
    }
    public Time(int hour, int minute, int second)
    {
        _hour = ValidateHour(hour);
        _minute = ValidateMinute(minute);
        _second = ValidateSecond(second);
        _millisecond = 0;
    }
    public Time(int hour, int minute, int second, int millisecond)
    {
        _hour = ValidateHour(hour);
        _minute = ValidateMinute(minute);
        _second = ValidateSecond(second);
        _millisecond = ValidateMillisecond(millisecond);
    }

    public int Hour
    {
        get => _hour;
        set => _hour = ValidateHour(value);
    }
    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidateMillisecond(value);
    }
    public int Minute
    {
        get => _minute;
        set => _minute = ValidateMinute(value);
    }
    public int Second
    {
        get => _second;
        set => _second = ValidateSecond(value);
    }

    public int ToMilliseconds()
    {
        return ((_hour * 3600 + _minute * 60 + _second) * 1000) + _millisecond;
    }
    public int ToMinutes()
    {
        return (_hour * 60) + _minute;
    }
    public int ToSeconds()
    {
        return (_hour * 3600) + (_minute * 60) + _second;
    }
       public Time Add(Time t)
    {
        int totalMilliseconds = this.ToMilliseconds() + t.ToMilliseconds();
        int newHour = (totalMilliseconds / (3600 * 1000)) % 24;
        totalMilliseconds %= (3600 * 1000);
        int newMinute = totalMilliseconds / (60 * 1000);
        totalMilliseconds %= (60 * 1000);
        int newSecond = totalMilliseconds / 1000;
        int newMillisecond = totalMilliseconds % 1000;

        return new Time(newHour, newMinute, newSecond, newMillisecond);
    }
    public bool IsOtherDay(Time t)
    {
        return (this.ToMilliseconds() + t.ToMilliseconds()) >= (24 * 3600 * 1000);
    }
    public override string ToString()
    {
        int displayHour = (_hour == 0 || _hour == 12) ? 12 : _hour % 12;
        string ampm = _hour < 12 ? "AM" : "PM";
        return $"{displayHour:D2}:{_minute:D2}:{_second:D2}.{_millisecond:D3} {ampm}";
    }
    private int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentException($"The hour: {hour}, incorrect must be between 0 and 23.");
        }

        return hour;
    }

    private int ValidateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentException($"The minute: {minute}, incorrect must be between 0 and 59.");
        }

        return minute;
    }
    private int ValidateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new ArgumentException($"The second: {second}, incorrect must be between 0 and 59.");
        }

        return second;
    }

    private int ValidateMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new ArgumentException($"The millisecond: {millisecond},incorrect must be between 0 and 999.");
        }

        return millisecond;
    }

}