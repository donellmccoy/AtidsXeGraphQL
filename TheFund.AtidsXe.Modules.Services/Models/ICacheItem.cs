using System;

namespace TheFund.AtidsXe.Modules.Services.Models
{
    public interface ICacheItem
    {
        string ReferenceJson { get; }
        DateTime CreatedDate { get; }
    }
}