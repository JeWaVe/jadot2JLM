using System;
using System.Collections.Generic;
using System.IO;

namespace generator;

class Program
{
    const string page_template = @"\begin{{landscape}}
    \vspace*{{\fill}}
    \begin{{center}}
        {{\fontsize{{40}}{{50}}\selectfont 
        Je m'appelle {0}, j'ai {1} ans\\
        je suis écologiste\\
        et dimanche je vote Jean-Luc~Mélenchon\\
        pour {2}.\\
        }}
    \end{{center}}
    \vspace*{{\fill}}
\end{{landscape}}
\newpage";

    const string[] mesures = new string[] {
            "l'instauration de la règle verte",
            "le 100\\% renouvelable",
            "la cantine bio et gratuite",
            "le bien-être animal",
            "une production alimentaire locale",
            "la sortie de la malbouffe",
            "l'économie circulaire",
            "une consommation durable",
            "abolir l'obsolescence programmée",
            "l'éco-conception obligatoire",
            "la réduction des déchets",
            "garantir le droit à l'eau potable",
            "protéger le cycle de l'eau",
            "préserver les forêts",
            "développer l'ONF",
            "soigner le système de santé",
            "des mobilités durables et accessibles"

        };

    const (int year, string[] firstnames)[] buckets = new (int year, string[] firstnames)[] {
            (1994, new string[] { "Léa", "Manon", "Camille", "Marie", "Chloé", "Thomas", "Alexandre", "Maxime", "Lucas", "Nicolas"}),
            (1984, new string[] { "Elodie", "Julie", "Aurélie", "Marie", "Emilie", "Julien", "Nicolas", "Kevin", "Thomas", "Alexandre"}),
            (1974, new string[] { "Stéphanie", "Céline", "Virginie", "Sandrine", "Aurélie", "Sébastien", "Nicolas", "David", "Christophe", "Julien"})
        };

    static Random random = new Random();

    static (String name, int age) GetPerson()
    {
        var bucket = buckets[random.Next(3)];
        var year = bucket.year;
        var age = 2022 - (year + random.Next(10));
        var firstname = bucket.firstnames[random.Next(10)];
        return (firstname, age);
    }

    static void Main(string[] args)
    {
        using (StreamWriter writer = new StreamWriter("../tex/pages.tex"))
        {
            for (int i = 0; i < 100; ++i)
            {
                var person = GetPerson();
                var mesure = mesures[random.Next(mesures.Length)];
                string page = String.Format(page_template, person.name, person.age, mesure);
                writer.WriteLine(page);
            }
        }
    }
}
