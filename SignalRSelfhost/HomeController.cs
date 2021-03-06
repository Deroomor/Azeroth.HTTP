﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SignalRSelfhost {
    public class HomeController : ApiController {
        [HttpGet]
        public List<int> GetEntities() {
            var lst = System.Linq.Enumerable.Range(0, 10).ToList();
            return lst;
        }

        [HttpPost]
        public void Msg(ChatContent cc) {
            var hubcontext = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<LolHub>();
            var all = hubcontext.Clients.All;
            all.refresh("未知",cc.Msg);
        }
    }

    public class ChatContent {

        public string Msg { get; set; }
    }
}
