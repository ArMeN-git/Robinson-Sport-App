﻿using Microsoft.AspNetCore.Identity;

namespace RobinsonSportApp.Data.Entities.Identity;

public class UserLogin : IdentityUserLogin<int>
{
    public User User { get; set; }
}
