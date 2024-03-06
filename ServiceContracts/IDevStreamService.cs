﻿using Entities;
using ServiceContracts.DTO;

namespace ServiceContracts;

/// <summary>
/// Represents business logic for manipulating DevStream entity
/// </summary>
public interface IDevStreamService
{
    /// <summary>
    /// Adds new DevStream
    /// </summary>
    /// <param name="devStreamAddRequest">DevStream to add</param>
    /// <returns>Added DevStream</returns>
    public DevStreamResponse AddDevStream(DevStreamAddRequest? devStreamAddRequest);
}