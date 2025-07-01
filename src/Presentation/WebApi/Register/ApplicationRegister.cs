using MetroPass.Application.Impl;
using MetroPass.Application.Interface;

namespace MetroPass.Presentation.Register
{
    public static class ApplicationRegister
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection service)
        {
            service.AddScoped<ISwipeCardAppService, SwipeCardAppService>();
            service.AddScoped<IJwtService, JwtAppService>();
            return service;
        }
    }
}