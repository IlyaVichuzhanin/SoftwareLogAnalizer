using Microsoft.AspNetCore.Mvc;
using SoftwareLogAnalizer.Shared.Model;

namespace SoftwareLogAnalizer.Server.Controllers
{
    public interface IModelController<T>
    {
        public Task<List<T>> Get();
        public Task<ActionResult<T>> Get(int id);

        public Task<ActionResult> Post(T item);

        public Task<ActionResult> Put(T item);

        public Task<ActionResult> Delete(int id);
    }
}
