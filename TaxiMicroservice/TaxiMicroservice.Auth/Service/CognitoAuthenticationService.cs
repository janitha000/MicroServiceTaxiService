using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger logger;

        public CognitoAuthenticationService(ILogger<CognitoAuthenticationService> _logger)
        {
            logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public async Task<ApiResult> LoginAsync(User user)
        {
            logger.LogDebug("Called for signin");
            try
            {
                var cognito = new AmazonCognitoIdentityProviderClient(_region);
                var request = new AdminInitiateAuthRequest
                {
                    UserPoolId = "us-east-1_gf5MTchOu",
                    ClientId = _clientId,
                    AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH
                };

                request.AuthParameters.Add("USERNAME", user.Name);
                request.AuthParameters.Add("PASSWORD", user.Password);
                var response = await cognito.AdminInitiateAuthAsync(request);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    logger.LogDebug("Login successed"); ;
                    return new ApiResult(true, response.AuthenticationResult.IdToken);
                }
                else
                {
                    logger.LogDebug($"login failed. {response.HttpStatusCode}");
                    return new ApiResult(false, "Login failed");
                }

            }
            catch(Exception ex)
            {
                logger.LogError($"login failed with exception. {ex.Message}");
                return new ApiResult(false, ex);
            }
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
