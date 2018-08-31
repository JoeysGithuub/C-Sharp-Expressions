using System;
using System.Collections.Generic;


namespace expressions
{
    class Program
    {
        public class Bug
        {
            /*

                You can declare a typed public property, make it read-only,
                and initialize it with a default value all on the same
                line of code in C#. Readonly properties can be set in the
                class' constructors, but not by external code.
            */

            private string name;
            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    this.name = value;
                }
            }
            public string Species { get; } = "";
            public ICollection<string> Predators { get; } = new List<string>();
            public ICollection<string> Prey { get; } = new List<string>();

            // Convert this readonly property to an expression member
            public string FormalName => $"{this.Name} the {this.Species}";

            public Bug(string species, List<string> predators, List<string> prey)
            {
                this.Species = species;
                this.Predators = predators;
                this.Prey = prey;
            }

            // Class constructor
            public Bug(string name, string species, List<string> predators, List<string> prey)
            {
                this.Name = name;
                this.Species = species;
                this.Predators = predators;
                this.Prey = prey;
            }

            // Convert this method to an expression member
            public string PreyList => string.Join(",", this.Prey);

            public string PredatorList => string.Join(",", this.Predators);

            public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}" : $"{this.Name} is still hungry.";
        }

        static void Main(string[] args)
        {
            List<string> Pred = new List<string>(){
        "hello", "there", "mate"
    };
            List<string> PreyForPred = new List<string>(){
        "another", "hello", "there"
    };
            Bug Ant = new Bug("BigAnt", Pred, PreyForPred)
            {
                Name = "Ant"
            };
            
            System.Console.WriteLine(Ant.FormalName);
            System.Console.WriteLine(Ant.PredatorList);
            System.Console.WriteLine(Ant.PreyList);
        }
    }
}