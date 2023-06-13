using Klir.TechChallenge.Web.Api.DTO;
using Klir.TechChallenge.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Services
{
    public interface ICheckoutService
    {
        decimal CalculateTotalPrice();
    }
}
