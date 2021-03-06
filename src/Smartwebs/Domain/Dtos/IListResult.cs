﻿using System.Collections.Generic;

namespace Smartwebs.Domain.Dtos
{
    public interface IListResult<T>
    {
        /// <summary>
        ///     List of items.
        /// </summary>
        IReadOnlyList<T> Items { get; set; }
    }
}