
using CLDV6211_Part2_ST10140587.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using CLDV6211_Part2_ST10140587.Data.Static;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using CLDV6211_Part2_ST10140587.Data.Enums;

namespace CLDV6211_Part2_ST10140587.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                    new Product
                    {
                        ProductName = "Sample Product 1",
                        ProductPrice = 29.99,
                        ProductCategory = ProductCategory.Painting,
                        ProductAvailability = "In Stock",
                        ProductImage = "data:image/jpeg;base64,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"
                    },
                    new Product
                    {
                        ProductName = "Sample Product 2",
                        ProductPrice = 49.99,
                        ProductCategory = ProductCategory.Jewelry,
                        ProductAvailability = "Out of Stock",
                        ProductImage = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBwgHBgkIBwgKCgkLDRYPDQwMDRsUFRAWIB0iIiAdHx8kKDQsJCYxJx8fLT0tMTU3Ojo6Iys/RD84QzQ5OjcBCgoKDQwNGg8PGjclHyU3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3N//AABEIAKwAtwMBIgACEQEDEQH/xAAbAAACAwEBAQAAAAAAAAAAAAADBAIFBgABB//EAD4QAAIBAwMBBQUFBgUEAwAAAAECAwAEEQUSITETIkFRYQYycYGRFKGxwdEjQlJi8PEVJDM04QcWcoM1Q4L/xAAZAQADAQEBAAAAAAAAAAAAAAABAgQDAAX/xAAfEQACAgMAAwEBAAAAAAAAAAAAAQIRAyExEjJBIlH/2gAMAwEAAhEDEQA/ALmy9yjXXuUKxHcot17legvUhfsVUjVyHd1rpxQEepJOimPBgxilXj79MrJ60F5V30thCKtXOkn7JamQcSzdPQDp9efpVWjLXalqMfY/Z4ZGDKgUjHkP71Nmbopw1Z9A0TWo7tDDvBlj7rYPGf1pq/vBbR9sQxUEZVRXxu3vp9Puo7q3YF0Odpzg46eNfRdC9qE1a3J25lXh4vHHmOelTOzZxVl1BqglULkFTxkHgH+vCqH2n0K31QtNaBItQA3bBwJfQ58f5vrVsLa1UswE7gLnsuiqPL0FCi1A7THahIwxP+0hMxyCBy/u559enWnhJoScU/h82MUkKFJkaNx1Vhg0qwPlX0fUXs9Qjaxv7nKsDhmnVnRvMKA3NYDVLJ7C8lt5OqnKnBwynoQDVUMqmTyh4ibUI0VjQ60sBHFdg+VFUCiCMV1nA0piOoqgo6R11gOFHQ0DFHWmFCCuryurji3sfco9yKBY+5TFxVi9SZ+xVXK0hjv1ZT0iR36kn0oicOlAb36ZI7lLkd+gEZjNUGtiW0v+1wezuCMHPG7gEVfoKlNDDcRNDMm5GHPofOsJx8jaEvEyUl0fPr1rrO5uFullspNjrySCB9T4fOizez9z9vjgi3SQyHuugyx/lx5/dX0P2W9kDamGa4KRsnKIFywPqccGpZaZWmpKz2L7RdwwjUZBM2QzIUVYw3HuKcA+POJPiDVm1nPKg7QnBxhGJY5/9pA+ifpVqbWO3UuyrCvQs2F+ZJz+FUd/7XaBpxWNdSgaQd4x26NKx9QFwM/I0FbFbTHSjwREBpFwQQDciIZ//Kpn76rNa0iTUbRUWIpdxgshyTkeK5LnyFAT2yu7zB0bQLl8/vXEohX04AB+tGm/7k7Jp7ptN06JeWZU7QqOPGim09HVapmFlR43ZJFZWU4ZWGCD60EmtZ7W6Lq0cX+IXTWtwq8SzW8OxgPAsM8ism1WRkpIllGmeo1E7SgrUjRQoVJDTkUnrSCUzFTUcM4z0qaihoaOBREOrq9ryiEubL3KNcUC0olwaqT/ACTPojORSTY30zOaXC1NPbN48JY7lKt79NGgEd+lD9DJRIonmkVIlBY+uMDGSSfLFcq0vfKjWVz2pk2GFg3ZkhiNvhjmsm9Gq6aKO80DS17Cb2ghguAoVzbgFic97khuMYHAFdqGtezGJ9+rXt0jhOzjgmkbY3oV/eJPPiK+aNNp0SsbGNkaHJ7WKFmKEjrkgeBpi1vr2K47G0icJ2faGO5URqWLY3Zz1zg9PCo+lnikb+f/ALcvL6GSC0uJJYo2/wApLavscE43MHwDtOPH1octrpsN9262kEMsgyVUAjPlx+prAx3uqyWi9lJFaydqSwaRnlfnBYknp148eM1f2s/Y2KmSe4nIkIb7TCEOT/CMGgw0jd2TRBQwKsW91VXb9Kso7rbg5AwcZJ4FZCyuQY1bZ48Bc/iKbF0zJuYgDpheg9K5BZpmuFlD7tjqe6yt0YetfMvafSf8KvsQr/lZhuhJOdvmnyP5VrvtuzG8jLeR5/tSevR/4hpMylsyQftYzjrjqPpn7q0xvxdGeSCaMOK9xUQeM1MGq0SHIKYjoaLRkFNYGEQ00ppQUwhoihK6vM11cGi1tGolyaXtH7nWpXEnrVN6Jq2KSmoJXjtUlqduzdaIuaXB79MPS49+lbOHFNccggoxDDJB8jXAV4azZqumWuL2+vLjathOrMzdo05CLkDkfDp8qQkub1o0k+y26b3AKmQyEDcQWIweM5PFWWpzXj3MweC2ZEfC75TiTL493kDzODj50mWvXMrKLZVj9wiNnD93w8hzipdot6gkTXiTMJr0G32rtaNBhjnpzngfDz8qnaveW8G68eSWQS47RydoHJAUdOnOevhSaLdh4dz9mrt+3jgh27DjPB8efIVMr2twkBnmlaMd55GyPTgDyrmtBNJZzzXEiKBI0khyFU5LDzPPT41ZJdQW8ireanFvA/0reEysB5buMfeKoLQSbRDFJJHEeZCrYaT9BWg09baONVjHJ5UKvdPr06+vNImcxiK900sFi1DDdFS5jMefh/apw3BjmMMhfhgGB5yD5HxFFMUVzHtltgy47yswyB681WRwm3chHaSDcQock9mfEZPO0/HqPXgioz8kbQu0bqVKEqQRjGK5ae1rvaxcNtIVip5HoP8AmlFFWxdpEclTJpR1oaCirTCnCmEFBWjrTAo9NdXprq44sYowiUKepdqaBK5pnMTwA1JWobNUd1Z2NQVjQFPfr0tQ0P7auO+liK8xioK3crV6dpmlW1tE+oqJrhwCUdiFUnwAB/GspTUVs1jFy4fO/aGxunmiuLVVQEHe27G5un1wfvqjmttR29VCr0Hae96+lfQvad7dw6rEkMIz2ca8bT6D+utY+R8pxzUvnbsrjGolKYLkzBO16+9t/Ami2E8VpevZmGWVyAS6pkKD4nFGlkUOGVcEevNGhOwO4LBpT3mPUnA6+lM2MNLdtFjYCMdAU6+o8/nRYL68d2C2k77uf9wqLkDrwKhtzhWCsg6Bm5HqPKjRW+wlreWOQOMNDLhGPzPB60qOYTTdc1DUYnaxjhuVjba7JfMCDjr06U7bXGotcbJ7f+Zh9oVgp48doPyzSOgaZZ6VDst+0t4523lnmWSV8dAqrxj1NaXT42knUGHsgpBWMNu582PmaMmkxUUOrljdI7x7P2WAd+7cASPIY+FKrVx7a2xtdShIBWGWPemRwDnvAfd9aolkx49apxv8kuTUqG0oopNJR5ijLcCtLMwy0wlICceVHSbNNYBpvdrqA0h2V1ANFkBUZEo6LUZRRQok60LFHehgUAg2FBjP7amJOOtaDS/Y+d3iuNQkEaHBEEZO85HGT+78s0spqK2dGLk9FZZWtxfSrDbRtIztggLwM+J8hWr07Q0sIBc30z3V0jHC7z2cfUAAcZ+eetWcNnFp9pLFbQbI4isghR8lsYOSep59fCq6fVGiibUFWV9Pmb9pFt70f8+Bnu+eOec1FlmpaK8cWjG+00oaWRCPEnH8NZKdgN23NaX2oXsZUntpVls51DrIGzj41jL+5IAyfe8B7tCCNZMHJKQ655w2TT0Th9qgrj0qkMjj3jmm7C52nYwfJ5Bp2jouy8AJGd2F805NMwP3wN3HQ4G40lA/dK5/4pqMbHy/X0pF0Zl/YxxAdoqKjue8ypj8smtBpSA3McYK7W5255yB5+NZTTpQe6H2DjPPvcVYas95baU11bACSIgjZ4jPPjx8qADY+0WkW+paY9ncv2bcNFMw/wBNx058jyD6V8gltZoZmikRkdDtZfIirOX2l9o9StrU2llcNZmXY0iLyzAY24zx1PpQGllncTT47UgbseBwB92MfKqcSdUTZRDZL5muHbetWYH8oqZjHkK2MSqWaT1p6CRvI16I49/u0/Bbp5Vxws0h217T5t08q6jR1lmtDmoyihT09aEEnNQFSc0NTShLPQdLbVdTSLO2JO9K/XAHOB8T+dfQBcRzM9nLIBcLxtORnjgj8c1jPZ7U0023ky4DzNkA8bsDpx8a89opzqSJqFnP2dzabgInDEMuR4dSOMnPlUWWVyoqx4/zZqLsNKgV5Ql5b8ruJ2yDpyBjIP41m7qa6NzcXWmR9jqKf7iymcN2o8GXHQnwPj40po/tLZ6/GdO1Hi8iYKrnCdm38rc+PTPXHjUfaES2/Yx6q7RXC8WeoxHaQxyMNgYX93Izzj0NZVs2joy99c2808lxphKJuIksm47Ns84yOMnP0xxWc1Ew3JZYWaCdDhopMgZ8vT8K0ftKkiJE2pxqhByup23Il453nz6ZyP1rK3yTFB2qm5Qe7c2w5A9V6/XIraC0JIrHmEbdnKGR08MePxFaLS7ZLzR4t4dC7MwboVbJGfu6VlmfLNseNl8Mgbq2Xs/EP8Cs5AxffLKr58CGOPu/OqIpGE21wBaCWOUwzEdrExDelWKF8d3BXzPWh6zDg/bFGdoHaA+K+fyoUcgZByW/OpckfGRVCSki4tpCu3Cj/jy+FaOG8ihtibgEIw2lMjLE1j4ZingB8RmrW0vYY8tdWNveKox3z7o8h4Y+RpUEtl1O1XYhlVXXmLb3ceI4BGfvrMsQ0srKO6XJHwzWnsdd0CSZI4rJLGQ+6s0Sj6N/aqn2hiij1EPEBiaMSMBxg5I6eHT763xk+VCS1LNRFeE1uYHie/VlBVbH79WERrgDBNdQy1dRsJYB6BcSUUg+VLTULYtCrtXgNc1cK4IO5kKwAFmA3Zwp5zRHv7h1Mby5D5L7nOc+P9Y/WoyKpQ7hnaM/lSsI3hhCrqFbBAThj+Y+6o8i/RbidwM/rZcSmeAMZl7nujDg9RyPpWk0C+1cWyW9/p/2qwZF7WIjLqvTGAM+6On3eNUbwqvtDFG+C3vYO7OM9eRx48CvoGiTRfYB2n7IykyPISOFb3wMdCEwM+bHihJ/B1wyt9Yywpc3OgXcd1at/wDRO+2ZAecccN5YPxrLSvZreDtRPpt0CQSibFJ+H6Vp/wDqNdW8F9pZtRHHO0Mkk4ijCkFipUHHoOlZ2PWXKbJBHMAoG2VMjr61pG6M2U98VlZpPt0Nwf4nQhvv/WtR7JXZl9nZrVsNGt6HjbHjg7vxH9YqjeewL/8Axltu57y5Ufcav9J0mXT7OC5kKhbpiywK24JjBGfka2X8MpLRaSEYOQGyOh6GqRYmsroxqMROMxknPH8Pyq3kNBnhE8ZV+PEEdVPnXTj5C434sCGAG7IA/iFXGjWJvmAEsUOOAZG6/wBfGspJPdWk32Zo1Mzf6eFJD/KpSWWvw/tbeAtnqiygMf68qlqnTKrvh9Gn/wCny3MYftkD+DRDukfWqzVPZfUtFgE0yLJaAhe1VgcZOBkdRz5VktJ9qNSguTBPc3Vo3I5YjHy/Orx7y6uAe2vJ5UPUNISPp0reEZpmGSSZEV7t9K8QZ6UyqdytjAWjHfpxKCF79MotCzjwZrqIFrq6zixalphRd1BkNccLOtQor0I1wCUXekC5xnI6Z8KGSzyK7gIRhQqd4f2+fjUokWSdI2iEis3MZUMG+R4rprNZlb9gVzlQv2DcfhtLVNl9ivD6lMFSTW5N6RgQRHftyfeyOefj186jqc72O54ZiQTtaKQnPJ90N5fUU5pEEb3N3cRiRXaUopeIRltv/iOmSfPjnNB1a1lA7WRMRRjcSx3CQ9cgjw4PBpOzNXwy2r3dxqF+9xc+8QPl1zShsZ2gEiws8TchkIP1FDmkaR2IPL+FaDRRv0wpt3bGbODj1/OqG/FGKVszAbB2nIPlW4029+1aNYocb4ztbpxt4/SkLi2inG2SIH4/r1rtDiaGSWHczRA7lYrjyyPj0rlJNizTSLhzXoPGfCuYUW2j7R+fdHWnlKlZnFXosNJ09XKT3Kl88KuOPnWr/wAG0+SNdykNt6o+0fSs/YypEdwB4GQNxAptNQ7KTJLR/wAp5FRW5OyyqVD8WgaUzj7baJcyjgPOoOPl0qi9pLGG3uEntkRIpBtKouFDDp934VbvqUTIkrTKqg4JDAA56VR61qaTxm2hw2HDs/Xveh8a1i3ZjOivhFNfuUtBTR9yqUycEB36MprxFohWgccDXV6BXVxwyKHIKMrp6VGVlogFGqBFTY56V4K448t0BuIw4jYE8iRSy9D1A5NLzcBlhMDK3RWurhNox0Ax09PSme6sinJVc8kcfhUrNQ0pD3FyQO83+bfafQr0NTZulOHlHmnQLZ6ckRBUfvEMWBY8+PXy8elUHtPdCJJx2yu+zaAzc8+X9hWg1TUoY41QorpjuiQKwP16Vg9du4ZwkEQxhtx2ZVPQBenielJjj/TVlZaW8t1MqQIWIGTg44HrWq0uwkt7FknXbIXLbQQcfj5Up7IxIFvHODyqD/x68fdV8ejHwppy+AUfpVzxso3Z5IPXqalpPeaSM/vYwvrzR54upwO76cmu06ILe4PdJTjHPOR/zSqVBasMxpiDuQBvF+R8K0V9oNtqFiNSsdttJtJkjYYQke9xjg1QsoKKeoAwB0pp5FKNITHjalYKSTEbHOM8jApZr4wOSzEKOWUY++iTHu7fPpWZ1mVlnRldVQHLKec/EfIUIKx5Oi4F9LqE0gZQLePA2nBO/wDsDTKmkNHhkSy3SjBlbtEUcYGAPyP1p9KoSVE0nsahpoUtEKaQUxmGhWjMtRgFEcUDiIWuqQrq4NC0chqMspqEZryWmFIK5oymgxiiGuOIyt3KS+yyXBPY3HZk9QQSD9/FMy11l79BxT6FSaegdnoIFz2t7cmXP7qDCkeR/TpWIvbV7e5lgcEtE7KePLofpX1BaxXtlGqaszKMFoFY48Tkr+ArNqjfHJthPZSEJZEkE7pyfeHhgD8au7iTaoUAD59T51T+zeW0xRkgNKwOPjirns1WRUHTP5VM3spS0IurHod2c5xyahEht7qOUhVIIJ5AIH9Zq7+yxnseWGTk4NFNvDG8aCJCCw94Z8KRsKQ1LNNZ6ZNagkfaWBIyOnjny8KpJGGeTyemego8hEf7OJFRc/uik25fnr1zXLbO4hW6cHKKMeZBqg1WAXt/ZWMXcklB7SR/dVT4/DirWbDbtwz0PNNaMiyX0UjKpZv8uTjPc3E/XmqI6RnLZzGPcFiyY1ACk8EgAV6jUspNGjrYkY9E3rTsVV8dOw0wo7DRGoMdeOxoHBwK6gq7V1cdZ//Z"
                    },
                    new Product
                    {
                        ProductName = "Sample Product 3",
                        ProductPrice = 19.99,
                        ProductCategory = ProductCategory.Shields,
                        ProductAvailability = "In Stock",
                        ProductImage = "+03mRUv3plVPfzxzevgTTzDgdUhVUv3ptTHuJipszJbqOAipW3UBCmVJ1JV5gfaqVVqUiouCchBRWxyiI7u9fFcdRrkLL8mnRv2UJovMcqr9y4mJgG1DgWwE/F9qxaqU6HVrMkiuPrv7CYmJiYt1Liv//Z"
                    }
                    });
                    context.SaveChanges();
                }

            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
