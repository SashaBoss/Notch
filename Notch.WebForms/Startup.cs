﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Notch.WebForms.Startup))]
namespace Notch.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
