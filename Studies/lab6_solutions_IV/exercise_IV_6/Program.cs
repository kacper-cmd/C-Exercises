using System;
using System.Collections.Generic;

namespace exercise_IV_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Artist a1 = new Artist("Maryla", "Rodowicz");
            Artist a2 = new Artist("Czesław", "Niemen");
            Artist a3 = new Artist("Janusz", "Panasewicz");
            Artist a4 = new Artist("Grzegorz", "Markowski");

            Performance p1 = new SoloPerformance("Kolorowe jarmarki", a1);
            Performance p2 = new SoloPerformance("Dziwny jest ten świat", a2);
            Performance p3 = new BandPerformance("Nietykalni", "Maryla & Janusz",
                    new List<Artist>() { a1, a3 }
            );
            Performance p4 = new BandPerformance("Autobiografia", "Perfect",
                    new List<Artist>() { a4, a1, a2 }
            );

            Festival f = 
                new Festival(new List<Performance>() { p1, p2, p3, p4 });

            f.GenerateGeneralProgram();
            Console.WriteLine();
            f.GenerateDetailedProgram();

            Console.ReadLine();
        }
    }

    class Festival
    {
        List<Performance> program;

        public Festival(List<Performance> program) { this.program = program; }
        public void GenerateGeneralProgram() {
            Console.WriteLine("====== General program of the festival =======");
            foreach (Performance position in program) 
                Console.WriteLine($"\t{position.GeneralForm}");
        }
        public void GenerateDetailedProgram() {
            Console.WriteLine("====== Detailed program of the festival =======");
            foreach (Performance position in program)
                Console.WriteLine($"\t{position.DetailedForm}");
        }
    }

    class Artist
    {
        string name { get; set; }
        string surname { get; set; }

        public Artist(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public override string ToString()
        {
            return $"{name} {surname}";
        }
    }

    abstract class Performance {
        protected string title;

        // internal access according to UML diagram
        internal string GeneralForm => $"Composition title: {title}";
        //public string GeneralForm { get { return title; } }

        internal abstract string DetailedForm { get; }
    }

    class SoloPerformance : Performance
    {
        Artist performer;

        public SoloPerformance(string title, Artist performer)
        {
            this.title = title;
            this.performer = performer;
        }

        internal override string DetailedForm => $"{GeneralForm}, performed by {performer}";

        /*
        public override string DetailedForm
        {
            get { return $"{title}, performed by {performer}"; }
        }
        */
    }

    class BandPerformance : Performance
    {
        string bandName;
        List<Artist> performers;

        public BandPerformance(string title, string name, List<Artist> performers)
        {
            this.title = title;
            bandName = name;
            this.performers = performers;
        }

        internal override string DetailedForm
        {
            get {
                string tmp = "\n\t\tMembers: ";
                foreach (Artist a in performers)
                    tmp += a + (performers.IndexOf(a) == performers.Count-1? "" : ", ");
                return $"{GeneralForm}, performed by {bandName} {tmp}";
                
            }
        }

    }


}
