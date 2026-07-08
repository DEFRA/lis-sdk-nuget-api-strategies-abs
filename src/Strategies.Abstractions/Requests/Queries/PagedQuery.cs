// <copyright file="PagedQuery.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests.Queries;

using System.ComponentModel;

public class PagedQuery
{
    [Description("The page number to retrieve")]
    public int PageNumber { get; set; }

    [Description("The number of items to return per page")]
    public int PageSize { get; set; }

    [Description("The property to order by")]
    public string? OrderBy { get; set; } = string.Empty;

    [Description("Order by descending when set to true")]
    public bool? OrderByDescending { get; set; } = false;
}
