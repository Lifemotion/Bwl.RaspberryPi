using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Services
{
    public class CameraHostedService:BackgroundService
    {
        #region Fields
        private readonly ILogger<CameraHostedService> _logger;
        public readonly IServiceProvider _services;
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public CameraHostedService(ILogger<CameraHostedService> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;
        }
        #endregion

        #region BackgroundService

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Hosted Service running.");

            await DoWork(stoppingToken);
        }
        #endregion

        #region Methods
        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Hosted Service is working.");

            using (var scope = _services.CreateScope())
            {
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<ICameraService>();

                await scopedProcessingService.DoWork(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {            
            _logger.LogInformation("Hosted Service is stopping.");

            await Task.CompletedTask;
        }
        #endregion
    }
}
