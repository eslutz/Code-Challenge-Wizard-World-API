using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WizardWorld.Models;
using WizardWorld.Services;

namespace WizardWorld;

internal class Program
{
    private const string _baseURL = "https://wizard-world-api.herokuapp.com";

    static async Task Main(string[] args)
    {
        var client = new HttpService();

        var wizards = JsonSerializer.Deserialize<List<Wizard>>(await client.GetAsync(new Uri($"{_baseURL}/Wizards")));
        if (wizards is not null)
        {
            var topElixirCounts = GetTopElixirs(wizards);
            if (topElixirCounts is not null)
            {
                Elixir[] topElixirs;
                if (topElixirCounts.Length >= 3)
                {
                    topElixirs = topElixirCounts.Select(x => x.Key).Take(3).ToArray();
                }
                else
                {
                    topElixirs = topElixirCounts.Select(x => x.Key).ToArray();
                }
                for (int i = 0; i < topElixirs.Length; i++)
                {
                    topElixirs[i] = JsonSerializer.Deserialize<Elixir>(await client.GetAsync(new Uri($"{_baseURL}/Elixirs/{topElixirCounts[i].Key.Id}")))!;
                }
                Console.WriteLine(CreateHeader("Top Three Elixirs"));
                for (int i = 0; i < topElixirs.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {topElixirCounts[i].Value} wizards have the elixir \"{topElixirCounts[i].Key.Name}\".");
                }

                Console.WriteLine($"\nThe top elixir \"{topElixirs[0].Name}\" has the side effect of \"{topElixirs[0].SideEffects}\".");

                var elixirs = JsonSerializer.Deserialize<List<Elixir>>(await client.GetAsync(new Uri($"{_baseURL}/Elixirs")));
                if (elixirs is not null)
                {
                    var sameIngredient = GetSimilarIngredientElixirs(topElixirs[0], elixirs);
                    Console.WriteLine(CreateHeader($"\nElixirs That Share an Ingredient With \"{topElixirs[0].Name}\""));
                    for (int i = 0; i < sameIngredient.Count(); i++)
                    {
                        Console.WriteLine(String.Format("{0,-3} {1}", $"{i + 1}.", sameIngredient[i].Name));
                    }
                }
                else
                {
                    Console.WriteLine(CreateHeader($"\nThere Are No Elixirs To Compare With \"{topElixirs[0].Name}\""));
                }
            }
            else
            {
                Console.WriteLine(CreateHeader("\nThere Are No Wizards To Gather Elixirs From"));
            }
        }
        else
        {
            Console.WriteLine(CreateHeader("\nThere Are No Wizards To Gather Elixirs From"));
        }


        var spells = JsonSerializer.Deserialize<List<Spell>>(await client.GetAsync(new Uri($"{_baseURL}/Spells")));
        if (spells is not null)
        {
            var spellTypes = GetSpellTypes(spells);
            Console.WriteLine(CreateHeader("\nSpell Types and Number of Spells With That Type"));
            var index = 1;
            foreach (var spell in spellTypes)
            {
                Console.WriteLine(String.Format("{0,-3} {1,-30} {2}", $"{index}.", spell.Key, $"x {spell.Value}"));
                index++;
            }
        }
        else
        {
            Console.WriteLine(CreateHeader("\nThere Are No Spells To Collect Spell Types From"));
        }
    }

    private static string CreateHeader(string headerValue)
    {
        var sb = new StringBuilder();
        sb.AppendLine(headerValue);
        sb.Append(new string('*', headerValue.Length));
        return sb.ToString();
    }

    private static KeyValuePair<Elixir, int>[] GetTopElixirs(List<Wizard> wizards)
    {
       var elixirs = new Dictionary<Elixir, int>();

        if (wizards.Any())
        {
            foreach (var wizard in wizards)
            {
                foreach (var elixir in wizard.Elixirs)
                {
                    if (elixirs.Any(x => x.Key.Id == elixir.Id))
                    {
                        var key = elixirs.Where(x => x.Key.Id == elixir.Id).Select(x => x.Key).First();
                        elixirs[key]++;
                    }
                    else
                    {
                        elixirs[elixir] = 1;
                    }
                }
            }
            var topElixirs = (from elixir in elixirs orderby elixir.Value descending, elixir.Key.Name select elixir).ToArray();

            return topElixirs;
        }

        return new KeyValuePair<Elixir, int>[] { new KeyValuePair<Elixir, int>(new Elixir(), 0) };
    }

    private static List<Elixir> GetSimilarIngredientElixirs(Elixir baseElixir, List<Elixir> elixirs)
    {
        var samesies = new List<Elixir>();

        foreach(var ingredient in baseElixir.Ingredients)
        {
            foreach(var elixir in elixirs)
            {
                if (elixir.Ingredients.Any(x => x.Id == ingredient.Id) && !(samesies.Any(x => x.Id == elixir.Id) || baseElixir.Id == elixir.Id))
                {
                    samesies.Add(elixir);
                }
            }

        }

        return samesies.OrderBy(x => x.Name).ToList();
    }

    private static Dictionary<string, int> GetSpellTypes(List<Spell> spells)
    {
        var spellTypes = new Dictionary<string, int>();

        foreach(var spell in spells)
        {
            if(spell.Type is not null)
            {
                if (!spellTypes.ContainsKey(spell.Type))
                {
                    spellTypes[spell.Type] = 1;
                }
                else
                {
                    spellTypes[spell.Type]++;
                }
            }
        }

        return spellTypes.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
    }
}
