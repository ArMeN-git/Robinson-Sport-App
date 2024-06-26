﻿using RobinsonSportApp.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace RobinsonSportApp.Core.Managers.Subscription.Models;

public class SubscriptionModel
{
    [Required, RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = ErrorMessages.InvalidEmailAddress)]
    public string Email { get; set; }
}
