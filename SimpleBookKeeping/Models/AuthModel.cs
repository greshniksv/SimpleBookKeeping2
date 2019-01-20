using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SimpleBookKeeping.Models
{
    public class AuthModel
    {
        [BindRequired]
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
