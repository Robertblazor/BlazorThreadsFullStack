using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorThreadsUi.Helpers
{
    public static class AuthenticationProviderHelpers
    {
        public static async Task<UserModel> GetUserFromAuthAsync( this AuthenticationStateProvider provider,
            IUserCollection userData
            )
        {
            var authState = await provider.GetAuthenticationStateAsync();
            string identifier = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
            return await userData.GetUserByAzureAsync(identifier);
        }
    }
}
