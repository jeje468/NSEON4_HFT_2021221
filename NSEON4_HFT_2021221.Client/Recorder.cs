using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Client
{
    class Recorder<T>
    {
        List<T> items;

        public Recorder(List<T> items)
        {
            this.items = items;
        }

        public T Create()
        {
            Type t = typeof(T);
            var props = t.GetProperties();
            var obj = Activator.CreateInstance(t);

            foreach (var prop in props)
            {
                if ((prop.PropertyType.Name.Contains("Int") || prop.PropertyType.Name.Contains("String")) && !prop.Name.Equals("Id"))
                {
                    Console.WriteLine("Enter " + prop.Name + ":");

                    string value = Console.ReadLine();

                    var proptype = prop.PropertyType;
                    var methods = proptype.GetMethods();
                    var parser = methods.FirstOrDefault(t => t.Name == "Parse");

                    if (parser != null)
                    {
                        var converted = parser
                            .Invoke(null, new[] { value });
                        prop.SetValue(obj, converted);
                    }
                    else
                    {
                        prop.SetValue(obj, value);
                    }
                }
            }              

            return (T)obj;
        }

        public void Write()
        {
            Type t = typeof(T);
                        
            var props = t.GetProperties();

            foreach (var item in items)
            {
                foreach (var prop in t.GetProperties())
                {
                    if (prop.Name.Equals("Id") || prop.Name.Equals("Name") || prop.Name.Equals("City"))
                    {
                        Console.WriteLine(prop.Name + ": " + prop.GetValue(item));
                    }
                }
            }                        
        }
    }
}
