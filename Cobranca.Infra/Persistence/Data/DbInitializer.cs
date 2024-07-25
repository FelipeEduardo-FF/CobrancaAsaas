﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Cobrancas.Domain.Models;

namespace Cobrancas.Infra.Persistence.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this._modelBuilder = modelBuilder;
        }

        internal void seed()
        {
            _modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "8305f33b-5412-47d0-b4ab-17cf6867f2e2",
                    Name = "Cliente",
                    NormalizedName = "CLIENTE"
                },
                new IdentityRole
                {
                    Id = "f4a49772-eb64-4a49-9647-0269fb9045cd",
                    Name = "Adm",
                    NormalizedName = "ADM"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            _modelBuilder.Entity<User>().HasData
            (
                new 
                {
                    Id = "95433ac4-2fe9-468f-b80d-b05ec3724d1d",
                    Email = "felipeteste@gmail.com.br",
                    Name="Felipe",
                    EmailConfirmed = true,
                    LockoutEnabled=false,
                    TwoFactorEnabled=false,
                    PhoneNumberConfirmed =false,
                    AccessFailedCount =0,
                    UserName = "felipeteste@gmail.com.br",
                    NormalizedEmail = "FELIPETESTE@GMAIL.COM.BR",
                    NormalizedUserName = "FELIPETESTE@GMAIL.COM.BR",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                    SecurityStamp = Guid.NewGuid().ToString("D"), 
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                }
            );

            _modelBuilder.Entity<IdentityUserRole<string>>().HasData
            (
                new IdentityUserRole<string>
                {
                    RoleId = "f4a49772-eb64-4a49-9647-0269fb9045cd",
                    UserId = "95433ac4-2fe9-468f-b80d-b05ec3724d1d"
                }
            );
        }
    }
}
