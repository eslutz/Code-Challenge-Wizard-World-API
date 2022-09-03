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
        var topThreeElixirCounts = GetTopElixirs(wizards);
        var topThreeElixirs = topThreeElixirCounts.Select(x => x.Key).ToArray();
        for (int i = 0; i < topThreeElixirs.Length; i++)
        {
            topThreeElixirs[i] = JsonSerializer.Deserialize<Elixir>(await client.GetAsync(new Uri($"{_baseURL}/Elixirs/{topThreeElixirCounts[i].Key.Id}")));
        }
        Console.WriteLine(CreateHeader("Top Three Elixirs"));
        for(int i = 0; i < topThreeElixirs.Length; i++)
        {
            Console.WriteLine($"{i+1}. {topThreeElixirCounts[i].Value} wizards have the elixir \"{topThreeElixirCounts[i].Key.Name}\".");
        }

        Console.WriteLine($"\nThe top elixir \"{topThreeElixirs[0].Name}\" has the side effect of \"{topThreeElixirs[0].SideEffects}\".");

        var elixirs = JsonSerializer.Deserialize<List<Elixir>>(await client.GetAsync(new Uri($"{_baseURL}/Elixirs")));
        var sameIngredient = GetSimilarIngredientElixirs(topThreeElixirs[0], elixirs);
        Console.WriteLine(CreateHeader($"\nElixirs That Share an Ingredient With \"{topThreeElixirs[0].Name}\""));
        for (int i = 0; i < sameIngredient.Count(); i++)
        {
            Console.WriteLine(String.Format("{0,-3} {1}", $"{i + 1}.", sameIngredient[i].Name));
        }


        var spells = JsonSerializer.Deserialize<List<Spell>>(await client.GetAsync(new Uri($"{_baseURL}/Spells")));
        var spellTypes = GetSpellTypes(spells);
        Console.WriteLine(CreateHeader("\nSpell Types and Number of Spells With That Type"));
        var index = 1;
        foreach(var spell in spellTypes)
        {
            Console.WriteLine(String.Format("{0,-3} {1,-30} {2}", $"{index}.", spell.Key, $"x {spell.Value}"));
            index++;
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
        foreach(var wizard in wizards)
        {
            if (wizard.Elixirs is not null)
            {
                foreach (var elixir in wizard.Elixirs)
                {
                    if(elixirs.Any(x => x.Key.Id == elixir.Id))
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
        }

        var topThreeElixirs = (from elixir in elixirs orderby elixir.Value descending, elixir.Key.Name select elixir).Take(3).ToArray();

        return topThreeElixirs;
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
