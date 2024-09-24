using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ValladoCalc.BusinessLogic.Services.Implementations.Services;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services
{
    public static class DependentyInjection
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddTransient<IAngleService, AngleService>();
            services.AddTransient<ICOE2RVService, COE2RVService>();
            services.AddTransient<IKepEqtnEService, KepEqtnEService>();
            services.AddTransient<IKepEqtnPService, KepEqtnPService>();
            services.AddTransient<IRV2COEService, RV2COEService>();

            return services;
        }
    }
}