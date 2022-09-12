﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.DataDto
{
    public static class PaginationExtension
    {
        public static async Task<ReunionesCollection<T>> GetPagedAsync<T>(
            this IQueryable<T> query,
            int page, 
            int take)
        {
            var orginalPages = page;
            page--;
            if (page > 0)
                page = page * take;

            var result = new ReunionesCollection<T>
            {
                Items = await query.Skip(page).Take(take).ToListAsync(),
                Total = await query.CountAsync(),
                Page = orginalPages
            };

            if(result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }
            return result;
        }
    }
}
