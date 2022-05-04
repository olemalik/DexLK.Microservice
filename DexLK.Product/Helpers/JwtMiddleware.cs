using DexLK.Product.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace DexLK.Product.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Audience _audience;

        public JwtMiddleware(RequestDelegate next, IOptions<Audience> audience)
        {
            _next = next;
            _audience = audience.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var endpoint = context.GetEndpoint();
            if (token != null)
            {
                await attachUserToContext(context, userService, token);
            }
            else if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() is object)
            {
                context.Items.Add("User", new User { Id = 0 });
            }  
            await _next(context);
        }

        private async Task attachUserToContext(HttpContext context,IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_audience.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // attach user to context on successful jwt validation
                //Call An Api to validate the User
                userService._token  = token;
                var user = await userService.GetById(userId);
                if (user is null)
                {
                    throw new SecurityTokenValidationException("Unauthorized: Failed to validate the Token");
                }
                context.Items.Add("User", user );
              //  context.Items["User"] =user;
            }
            catch (SecurityTokenValidationException stvex)
            {
                // The token failed validation!
                // TODO: Log it or display an error.
                throw new Exception($"Token failed validation: {stvex.Message}");
            }
            catch (ArgumentException argex)
            {
                // The token was not well-formed or was invalid for some other reason.
                // TODO: Log it or display an error.
                throw new Exception($"Token was invalid: {argex.Message}");
            }
            //catch(Exception ex)
            //{
            //    //context. (new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized });
            //    // do nothing if jwt validation fails
            //    // user is not attached to context so request won't have access to secure routes
            //}
        }
    }
}
