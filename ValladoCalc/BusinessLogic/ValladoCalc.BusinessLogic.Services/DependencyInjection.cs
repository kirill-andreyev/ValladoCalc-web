using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ValladoCalc.BusinessLogic.Services.Implementation.Services;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services
{
    public static class DependentyInjection
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddTransient<IAngleService, AngleService>();
            services.AddTransient<ICOE2RVService, COE2RVService>();
            services.AddTransient<IKepEqtnService, KepEqtnService>();
            services.AddTransient<IRV2COEService, RV2COEService>();
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IPsiToService, PsiToService>();
            services.AddTransient<IAnomalyService, AnomalyService>();
            services.AddTransient<IFindTOFService, FindTOFService>();

            return services;
        }
    }
}