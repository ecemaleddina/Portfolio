using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Identity;

namespace Portfolio.Classes
{
    public static class SeedData
    {
        public async static Task GenerateFirstUser(UserManager<User> userManager)
        {
            if (await userManager.FindByNameAsync("Camaladdin") is null)
            {
                var user = new User
                {
                    UserName = "Camaladdin",
                    Email = "ecemaleddin49@gmail.com"
                };
                await userManager.CreateAsync(user, "Cemaleddin@64");
            }
        }
    }

}
