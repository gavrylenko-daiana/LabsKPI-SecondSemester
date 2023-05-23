using System;
using System.Linq;

namespace Lab4
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;

        public Time()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
        }

        public Time(int hour)
        {
            Hour = hour;
            Minute = 0;
            Second = 0;
        }

        public Time(int hour, int minute) : this(hour)
        {
            Minute = minute;
            Second = 0;
        }

        public Time(int hour, int minute, int second) : this(hour, minute)
        {
            Second = second;
        }

        public int Hour
        {
            get => _hour;
            private set => _hour = value >= 0 ? value % 24 : 0;
        }

        public int Minute
        {
            get => _minute;
            private set
            {
                if (value >= 0)
                {
                    Hour += value / 60;
                    _minute = value % 60;
                }
                else
                {
                    Hour += value / 60 - 1;
                    _minute = 60 + value % 60;
                }
            }
        }

        public int Second
        {
            get => _second;
            private set
            {
                if (value >= 0)
                {
                    Minute += value / 60;
                    _second = value % 60;
                }
                else
                {
                    Minute += value / 60 - 1;
                    _second = 60 + value % 60;
                }
            }
        }

        public Time GetTimeRemainingUntilEndOfTheDay() => new Time(24 - _hour, 0 - _minute, 0 - _second); // повертає залишковий час до кінця дня

        public override string ToString() // отримання рядкового представлення часу
        {
            string[] printable =
            {
                _hour.ToString().PadLeft(2, '0'),
                _minute.ToString().PadLeft(2, '0'),
                _second.ToString().PadLeft(2, '0')
            };

            return $"{printable[0]}:{printable[1]}:{printable[2]}";
        }

        public static Time? Parse(string str) // конвертує числа з рядку в цілі числа
        {
            string[] substrings = str.Split(new[] {' ', ',', '.', ':', ';', '/'}, StringSplitOptions.RemoveEmptyEntries);
            int[] nums = new int[substrings.Length];
            
            for (int i = 0; i < substrings.Length; i++)
            {
                nums[i] = int.Parse(substrings[i]);
            }

            return nums.Length switch
            {
                3 => new Time(nums[0], nums[1], nums[2]),
                2 => new Time(nums[0], nums[1]),
                1 => new Time(nums[0]),
                _ => null
            };
        }

        public static Time operator +(Time time1, Time time2) // додає два об'єкти
        {
            return new Time(time1.Hour + time2.Hour, time1.Minute + time2.Minute, time1.Second + time2.Second);
        }

        public static Time operator +(Time time, int minutes) // додає певну кількість хвилин до об'єкту 
        {
            return new Time(time.Hour, time.Minute + minutes, time.Second);
        }

        public static Time operator -(Time time1, Time time2) // віднімає один об'єкт від іншого об'єкту
        {
            return new Time(time1.Hour - time2.Hour, time1.Minute - time2.Minute, time1.Second - time2.Second);
        }

        public static Time operator -(Time time, int minutes) // віднімає певну кількість хвилин від об'єкту
        {
            return new Time(time.Hour, time.Minute - minutes, time.Second);
        }
    }
}
