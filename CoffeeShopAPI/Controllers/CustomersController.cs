﻿using Microsoft.AspNetCore.Mvc;
using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.Models.Customers;
using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomersService _customersService;

        public CustomersController(ILogger<CustomersController> logger, ICustomersService customersService)
        {
            _logger = logger;
            _customersService = customersService;
        }

        [HttpGet("get", Name = "GetCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            try
            {
                var result = await _customersService.Get();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch Customers");
                return BadRequest();
            }
        }

        [HttpGet("get-by-adapter", Name = "GetCustomersByAdapter")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomersByAdapter()
        {
            try
            {
                var result = await _customersService.GetByAdapter();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch Customers");
                return BadRequest();
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<CustomerDto>> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            try
            {
                var customer = await _customersService.CreateCustomer(request.Type, request.Name, request.Email);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}