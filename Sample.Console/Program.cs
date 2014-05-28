using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using numl;
using numl.Model;
using numl.Supervised.DecisionTree;

namespace Sample.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Tennis.GetData();
            var descriptor = Descriptor.Create<Tennis>();
            var treeGenerator = new DecisionTreeGenerator(descriptor);
            treeGenerator.SetHint(false);
            var model = Learner.Learn(data, 0.80, 1000, treeGenerator);
            System.Console.WriteLine(model);
            System.Console.ReadKey();

            var t = new Tennis
            {
                Outlook = Outlook.Overcast,
                Temperature = Temperature.Low,
                Windy = true
            };
            var result = model.Model.Predict(t);
            System.Console.WriteLine(result.Play);
           


        }
    }
}
