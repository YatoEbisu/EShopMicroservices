﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasConversion(
                orderId => orderId.Value,
                dbId => OrderId.Of(dbId));

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(c => c.CustomerId)
                .IsRequired();

            builder.HasMany(c => c.OrderItems)
                .WithOne()
                .HasForeignKey(c => c.OrderId);

            builder.ComplexProperty(
                c => c.OrderName, nameBuilder =>
                {
                    nameBuilder.Property(n => n.Value)
                        .HasColumnName(nameof(Order.OrderName))
                        .HasMaxLength(100)
                        .IsRequired();
                });

            builder.ComplexProperty(
                c => c.ShippingAddress, addressBuilder =>
                {
                    addressBuilder.Property(a => a.FirstName)
                        .HasMaxLength(50)
                        .IsRequired();

                    addressBuilder.Property(a => a.LastName)
                        .HasMaxLength(50)
                        .IsRequired();

                    addressBuilder.Property(a => a.EmailAddress)
                        .HasMaxLength(50);

                    addressBuilder.Property(a => a.AddressLine)
                        .HasMaxLength(180)
                        .IsRequired();

                    addressBuilder.Property(a => a.Country)
                        .HasMaxLength(50);

                    addressBuilder.Property(a => a.State)
                        .HasMaxLength(50);

                    addressBuilder.Property(a => a.ZipCode)
                        .HasMaxLength(5)
                        .IsRequired();
                });


            builder.ComplexProperty(
                c => c.BillingAddress, addressBuilder =>
                {
                    addressBuilder.Property(a => a.FirstName)
                        .HasMaxLength(50)
                        .IsRequired();

                    addressBuilder.Property(a => a.LastName)
                        .HasMaxLength(50)
                        .IsRequired();

                    addressBuilder.Property(a => a.EmailAddress)
                        .HasMaxLength(50);

                    addressBuilder.Property(a => a.AddressLine)
                        .HasMaxLength(180)
                        .IsRequired();

                    addressBuilder.Property(a => a.Country)
                        .HasMaxLength(50);

                    addressBuilder.Property(a => a.State)
                        .HasMaxLength(50);

                    addressBuilder.Property(a => a.ZipCode)
                        .HasMaxLength(5)
                        .IsRequired();

                });

            builder.ComplexProperty(
                c => c.Payment, paymentBuilder =>
                {
                    paymentBuilder.Property(p => p.CardName)
                        .HasMaxLength(50);

                    paymentBuilder.Property(p => p.CardNumber)
                        .HasMaxLength(24)
                        .IsRequired();

                    paymentBuilder.Property(p => p.Expiration)
                        .HasMaxLength(10);

                    paymentBuilder.Property(p => p.CVV)
                        .HasMaxLength(3);

                    paymentBuilder.Property(p => p.PaymentMethod);
                });

            builder.Property(c => c.Status)
                .HasDefaultValue(OrderStatus.Draft)
                .HasConversion(
                    s => s.ToString(),
                    dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

            builder.Property(c => c.TotalPrice);
        }
    }
}
