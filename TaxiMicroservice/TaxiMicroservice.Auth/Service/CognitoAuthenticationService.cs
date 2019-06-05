using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiMicroservice.Auth.Entities;

namespace TaxiMicroservice.Auth.Service
{

    public class CognitoAuthenticationService : IAuthService
    {
        private readonly RegionEndpoint _region = RegionEndpoint.USEast1;
        private const string _clientId = "10psr24c9geo1836d792nc79cg";

        public async Task<ApiResult> LoginAsync(User user)
        {
            throw new NotImplementedException();


        }

        public async Task<ApiResult> RegisterAsync(User user)
        {
            try
            {
                var cognito = new AmazonCognitoIdentityProviderClient(_region);
                var request = new SignUpRequest
                {
                    ClientId = _clientId,
                    Password = user.Password,
                    Username = user.Name
                };

                var emailAttribute = new AttributeType
                {
                    Name = "email",
                    Value = user.Email
                };

                request.UserAttributes.Add(emailAttribute);
                var response = await cognito.SignUpAsync(request);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    return new ApiResult(true, "User registration successful");
                else
                    return new ApiResult(false, "User registration unsuccessful");
            }
            catch (Exception ex)
            {
                return new ApiResult(false, ex);
            }
        }
    }
}
