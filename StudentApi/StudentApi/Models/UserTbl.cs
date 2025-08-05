using System;
using System.Collections.Generic;

namespace StudentApi.Models;

public partial class UserTbl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Age { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
