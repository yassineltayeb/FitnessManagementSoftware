﻿namespace Service.ViewModels.CoachClass;

public class GetCoachClassRequestViewModel
{
    public string? searchTerm { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}