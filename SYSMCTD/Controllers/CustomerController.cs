using Microsoft.AspNetCore.Mvc;
using SYSMCTD.Interfaces;
using SYSMCTD.Models;
using System.Linq.Expressions;

namespace SYSMCTD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customers> _repository;
        public CustomerController(IRepository<Customers> CustomerRepository)
        {
            _repository = CustomerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var Customer = await _repository.Get();
            return Ok(Customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customers Customer)
        {
            Expression<Func<Customers, bool>> predicate = c => c.Name == Customer.Name;
            var exist = await _repository.Get(predicate);
            if(exist != null)
            {
                throw new Exception("customer exist.");
            }
            var newCustomer = await _repository.Create(Customer);
            return Ok(newCustomer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customers Customer)
        {
            var editedCustomers = await _repository.Edit(Customer);
            return Ok(editedCustomers);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var Customer = await _repository.Delete(id);
            return Ok(Customer);
        }
    }
}
