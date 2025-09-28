using System.Runtime.InteropServices.Swift;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Structural.Composite;

public class Composite : IComponent
{
    public List<IComponent> Movies {get; set;}
    public string Category { get; set; }

    public void AddMovie(Movie movie)
    {
        Movies.Add(new Leaf
        {
            movie = movie
        });
    }

    public void AddCategory(string category)
    {
        Movies.Add(new Composite
        {
            Category = category
        });
    }
    public int Count()
    {
        var sum = 0;
        foreach (var m in Movies)
        {
            sum += m.Count();
        }
        return sum;
    }
}