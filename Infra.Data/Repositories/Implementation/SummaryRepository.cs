namespace Infra.Data.Repositories.Implementation;

using Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

public class SummaryRepository : ISummaryRepository
{
    private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

    public IEnumerable<string> Get()
    {
        return Summaries;
    }
}
