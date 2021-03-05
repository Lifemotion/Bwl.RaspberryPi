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
    public class StatusModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IFrameService _frameService;
        public StatusModel(ILogger<IndexModel> logger, IMemoryCache memoryCache, IFrameService frameService)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _frameService = frameService;
        }
        public void OnGet()
        {
            string time;
            _memoryCache.TryGetValue("_Time", out time);
            ViewData["Time"] = time;

            ViewData["Count"] = _frameService.Count;

            ViewData["Bytes"] = _frameService.GetFrame();
        }
    }
}
