using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication1;
using Wintellect.PowerCollections;

public class Event : IComparable
{
    private DateTime date;
    private string title;
    private string location;

    public Event(DateTime date, string title, string location)
    {
        this.date = date;
        this.title = title;
        this.location = location;
    }

    public int CompareTo(object obj)
    {
        Event other = obj as Event;
        int compareDate = this.date.CompareTo(other.date);
        int compareTitle = this.title.CompareTo(other.title);
        int compareLocation = this.location.CompareTo(other.location);

        if (compareDate == 0)
        {
            if (compareTitle == 0)
            {
                return compareLocation;
            }
            else
            {
                return compareTitle;
            }
        }
        else
        {
            return compareDate;
        }
    }

    public override string ToString()
    {
        StringBuilder toString = new StringBuilder();
        toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
        toString.Append(" | " + this.title);

        if (this.location != null && this.location != string.Empty)
        {
            toString.Append(" | " + this.location);
        }

        return toString.ToString();
    }
}

private class OrderedBag<T>
{
    internal void Add(Event newEvent)
    {
        throw new NotImplementedException();
    }

    internal View RangeFrom(Event p1, bool p2)
    {
        throw new NotImplementedException();
    }
}

private class MultiDictionary<T1, T2>
{
    private bool p;

    public MultiDictionary(bool p)
    {
        // TODO: Complete member initialization
        this.p = p;
    }

    internal void Add(string p, Event newEvent)
    {
        throw new NotImplementedException();
    }

    internal void Remove(string title)
    {
        throw new NotImplementedException();
    }
}

public class Program
{
    private static StringBuilder output = new StringBuilder();

    public static class Messages
    {
        public static void EventAdded()
        { 
            output.Append("Event added\n"); 
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", x);
            }
        }

        public static void NoEventsFound() 
        { 
            output.Append("No events found\n"); 
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }
    }

    public class EventHolder
    {
        private MultiDictionary<string, Event> title = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> date = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            title.Add(title.ToLower(), newEvent);
            date.Add(newEvent); 
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in title[title])
            {
                removed++;
                this.date.Remove(eventToRemove);
            }

            title.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = date.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }

    private static EventHolder events = new EventHolder();

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();

        if (command[0] == 'A')
        {
            AddEvent(command);
            return true;
        }

        if (command[0] == 'D')
        {
            DeleteEvents(command);
            return true;
        }

        if (command[0] == 'L')
        {
            ListEvents(command);
            return true;
        }

        if (command[0] == 'E')
        {
            return false;
        }

        return false;
    }

    private static void ListEvents(string command)
    {
        int pipeIndex = command.IndexOf('|');
        DateTime date = GetDate(command, "ListEvents");
        string countString = command.Substring(pipeIndex + 1);
        int count = int.Parse(countString);
        events.ListEvents(date, count);
    }

    private static void DeleteEvents(string command)
    {
        string title = command.Substring("DeleteEvents".Length + 1);
        events.DeleteEvents(title);
    }

    private static void AddEvent(string command)
    {
        DateTime date; 
        string title; 
        string location;
        GetParameters(command, "AddEvent", out date, out title, out location);
        events.AddEvent(date, title, location);
    }

    private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
    {
        dateAndTime = GetDate(commandForExecution, commandType);

        int firstPipeIndex = commandForExecution.IndexOf('|');
        int lastPipeIndex = commandForExecution.LastIndexOf('|');

        if (firstPipeIndex == lastPipeIndex)
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
            eventLocation = string.Empty;
        }
        else
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
            eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
        }
    }

    private static DateTime GetDate(string command, string commandType)
    {
        DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
        return date;
    }

    public static void Main(string[] args)
    {
        while (ExecuteNextCommand())
        {
        }

        Console.WriteLine(output);
    }
}