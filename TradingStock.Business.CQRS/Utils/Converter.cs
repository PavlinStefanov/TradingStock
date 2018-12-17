using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TradingStock.Business.CQRS.Events;

namespace TradingStock.Business.CQRS.Utils
{
    public static class Converter
    {
        public static Action<object> Convert<T>(Action<T> myActionT)
        {
            if (myActionT == null) return null;
            return new Action<object>(o => myActionT((T)o));
        }

        public static dynamic ChangeTo(dynamic source, Type dest)
        {

            return System.Convert.ChangeType(source, dest);
        }

        public static object ToType<T>(this object obj, T type)
        {

            //create instance of T type object:
            var tmp = Activator.CreateInstance(Type.GetType(type.ToString()));

            //loop through the properties of the object you want to covert:          
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                try
                {

                    //get the value of property and try 
                    //to assign it to the property of T type object:
                    tmp.GetType().GetProperty(pi.Name).SetValue(tmp,
                                              pi.GetValue(obj, null), null);
                }
                catch { }
            }

            //return the T type object:         
            return tmp;
        }
        public static object ToListOfType<T>(this List<T> list, Type t)
        {

            //define system Type representing List of objects of T type:
            var genericType = typeof(List<>).MakeGenericType(t);

            //create an object instance of defined type:
            var l = Activator.CreateInstance(genericType);

            //get method Add from from the list:
            MethodInfo addMethod = l.GetType().GetMethod("Add");

            //loop through the calling list:
            foreach (T item in list)
            {

                //convert each object of the list into T object 
                //by calling extension ToType<T>()
                //Add this object to newly created list:
                addMethod.Invoke(l, new object[] { item.ToType(t) });
            }

            //return List of T objects:
            return l;
        }

        public static IEnumerable<I> ForAll<T, I>(IList<T> lst) where T : I
        {
            foreach (I item in lst) yield return item;
        }

        public static string AsJsonString(this byte[] data)
        {
            return Encoding.ASCII.GetString(data);
        }
        public static List<Event> AsListEvents(this string jsonData)
        {
            return JsonConvert.DeserializeObject<List<Event>>(jsonData);
        }

        public static EventData ToEventData(this IEvent @event)
        {
            string jsonData = JsonConvert.SerializeObject(new { EventId = @event.Id, @event.Version, @event.TimeStamp }, Formatting.Indented);

            return new EventData(
                @event.Id,
                @event.GetType().ToString(),
                true,
                Encoding.ASCII.GetBytes(jsonData),
                @event.Metadata
                );
        }
    }
}
