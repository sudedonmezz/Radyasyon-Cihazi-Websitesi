using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ZSStore.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td",Attributes ="user-role")]
    public class UserRoleTagHelper : TagHelper
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        [HtmlAttributeName("user-name")]
        public String? Email{get;set;}
        public UserRoleTagHelper(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
       public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
{
    if (string.IsNullOrEmpty(Email))
    {
        output.Content.AppendHtml("Email bulunamadı.");
        return;
    }

    var user = await _userManager.FindByEmailAsync(Email);
    if (user == null)
    {
        output.Content.AppendHtml("Kullanıcı bulunamadı.");
        return;
    }

    TagBuilder ul = new TagBuilder("ul");
    var roles = _roleManager.Roles.ToList().Select(r => r.Name);

    foreach (var role in roles)
    {
        TagBuilder li = new TagBuilder("li");
        li.InnerHtml.Append($"{role,-8} : {await _userManager.IsInRoleAsync(user, role)}");
        ul.InnerHtml.AppendHtml(li);
    }
    output.Content.AppendHtml(ul);
}



    }
}