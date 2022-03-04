using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;


namespace SISST.Autenticacion.Models.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(d => d.Id).IsRequired();

            builder.Property(x => x.UserName).IsRequired().HasColumnType("VARCHAR").HasMaxLength(10);
            builder.Property(x => x.PasswordHash).IsRequired().HasColumnType("VARCHAR").HasMaxLength(150);
            builder.Property(x => x.TrabajadorId).IsRequired();

            var usuarios = new List<ApplicationUser>();
            //var t = new Trabajador
            //{
            //    RPE = "ADMIN",
            //    Activo = true,
            //    IdArea = 1,
            //    Nombre = "ADMIN"
            //};
           
            usuarios.Add(
                new ApplicationUser
                {
                    Id=1,
                    UserName = "00000",
                    TrabajadorId = 1,
                    NormalizedUserName = "00000",
                    Email = "sisstproyecto@gmail.com",
                    NormalizedEmail = "SISSTPROYECTO@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEGcRuguJpyW89jqY+u9U0KI02K0AIb4CXKv+nZOuWJ5sdYISusqNYa1FJPUpA0FYIw==",// representa la cadena 4867
                    SecurityStamp = "IVJATBL6BCF73ZUWLQ45EO2UM7TE3OSQ",
                    ConcurrencyStamp = "9c21e30c-ab8d-435e-a370-9f61e76819a8",
                    IsActive=true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UpdatedById=1
                }
                );
            usuarios.Add(
                new ApplicationUser
                {
                    Id = 2,
                    UserName = "4385",
                    TrabajadorId = 2,
                    NormalizedUserName = "4385",
                    Email = "nejacome@ineel.mx",
                    NormalizedEmail = "NEJACOME@INEEL.MX",
                    PasswordHash = "AQAAAAEAACcQAAAAEGHeihe95uQRBpgHXo1FuS8x7YOMhS/cJ3KVW7RlLhmspRlMvMIp6ER3GHpMTzCZfg==",
                    SecurityStamp = "YJUNEA6CTHIGSOOEGYO65QRPKYSVPPEL",
                    ConcurrencyStamp = "dd1b73db-fece-4137-a173-401bb609c5b7",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UpdatedById = 1
                }
                );
            usuarios.Add(
                new ApplicationUser
                {
                    Id = 3,
                    UserName = "5163",
                    TrabajadorId = 3,
                    NormalizedUserName = "5163",
                    Email = "gescobedo@ineel.mx",
                    NormalizedEmail = "GESCOBEDO@INEEL.MX",
                    PasswordHash = "AQAAAAEAACcQAAAAEJXsmlDCv4zB2gY3l37OjaKNAN6qUKJpBEedYTGXnID+GAqPN5vvTm8Kfens0uFuHA==",
                    SecurityStamp = "2UVTWXFBH6DM4ZISCHERKBRINTJA6DUS",
                    ConcurrencyStamp = "320252da-6a52-4c05-93a7-093da71846b5",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UpdatedById = 1
                }
                );
            usuarios.Add(
                new ApplicationUser
                {
                    Id = 4,
                    UserName = "4867",
                    TrabajadorId = 4,
                    NormalizedUserName = "4867",
                    Email = "sr.camacho.ti@gmail.com",
                    NormalizedEmail = "SR.CAMACHO.TI@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEGcRuguJpyW89jqY+u9U0KI02K0AIb4CXKv+nZOuWJ5sdYISusqNYa1FJPUpA0FYIw==",
                    SecurityStamp = "B3PK7KVN5BLZN5JYONIMH7U5D7A72TTU",
                    ConcurrencyStamp = "09cf4154-927f-4996-9504-51f6817fc4b9",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UpdatedById = 1
                }
                );
            usuarios.Add(
                new ApplicationUser
                {
                    Id = 5,
                    UserName = "5071",
                    TrabajadorId = 5,
                    NormalizedUserName = "5071",
                    Email = "honorato@ineel.mx",
                    NormalizedEmail = "HONORATO@INEEL.MX",
                    PasswordHash = "AQAAAAEAACcQAAAAEMF72WbX8s2qGciq30hjqN9yHAtlBS+/UqTUdEtPPxzVrPTHaYpQGER5U20I/0sccw==",
                    SecurityStamp = "NOR7AX6JT4F57SU5D4EX7XOQFVQT72LS",
                    ConcurrencyStamp = "e5578642-b0c0-4a32-95cd-7998b08f1cf7",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UpdatedById = 1
                }
                );
            usuarios.Add(
                new ApplicationUser
                {
                    Id = 6,
                    UserName = "3589",
                    TrabajadorId = 6,
                    NormalizedUserName = "3589",
                    Email = "pmendoza@ineel.mx",
                    NormalizedEmail = "PMENDOZA@INEEL.MX",
                    PasswordHash = "AQAAAAEAACcQAAAAEGE1WSowI60zQBWloIWSstNidtNZOwKc7BrgeJM5ugzU3iAq2UVDupEZaJvZIr3sHw==",
                    SecurityStamp = "UJIRHDBUCDLAHLSDMSB6H7C4G5L33OFY",
                    ConcurrencyStamp = "358b6d68-f770-48b3-8861-6d40f380129e",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UpdatedById = 1
                }
                );
            usuarios.Add(
                new ApplicationUser
                {
                    Id = 7,
                    UserName = "50650",
                    TrabajadorId = 7,
                    NormalizedUserName = "50650",
                    Email = "ohernandez@ineel.mx",
                    NormalizedEmail = "OHERNANDEZ@INEEL.MX",
                    PasswordHash = "AQAAAAEAACcQAAAAEGE1WSowI60zQBWloIWSstNidtNZOwKc7BrgeJM5ugzU3iAq2UVDupEZaJvZIr3sHw==",
                    SecurityStamp = "UJIRHDBUCDLAHLSDMSB6H7C4G5L33OFY",
                    ConcurrencyStamp = "358b6d68-f770-48b3-8861-6d40f380129e",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UpdatedById = 1
                }
                );
            builder.HasData(usuarios);
        }

    }
}
