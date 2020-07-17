// <copyright file="ApplicationDbContext.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace CommanLayer
{
    using CommanLayer.Model;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Dbset for Quantity table
        /// </summary>
        public DbSet<Quantity> Quantities { get; set; }

        /// <summary>
        /// Dbset for Comparison table
        /// </summary>
        public DbSet<Compare> Comparisons { get; set; }

    }
}