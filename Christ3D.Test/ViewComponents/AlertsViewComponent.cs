using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christ3D.Test.ViewComponents
{
    public class AlertsViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // 获取到缓存中的错误信息
            var errorData = _cache.Get("ErrorData");
            var notificacoes = await Task.Run(() => (List<string>)errorData);
            // 遍历添加到ViewData.ModelState 中
            notificacoes?.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c));
            return View();

        }
    }
}
