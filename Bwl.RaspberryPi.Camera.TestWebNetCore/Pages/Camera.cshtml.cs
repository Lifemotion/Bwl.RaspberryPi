using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwl.RaspberryPi.Camera.TestWebNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Bwl.RaspberryPi.Camera.TestWebNetCore.Pages
{
    public class CameraModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMemoryCache _memoryCache;
        public CameraModel(ILogger<IndexModel> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }
        public void OnGet()
        {
            string time;
            _memoryCache.TryGetValue("_Time", out time);
            ViewData["Time"] = time;
        }
    }
}
