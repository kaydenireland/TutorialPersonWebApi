using System;
using System.Collections.Generic;

namespace PersonWebAPI.Models;

public partial class Person
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
