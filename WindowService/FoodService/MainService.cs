﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace FoodService
{
    public partial class MainService : ServiceBase
    {
        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpChannel(1234), false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(FoodBUS), "xxx", WellKnownObjectMode.SingleCall);
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
        }

        protected override void OnStop()
        {
        }
    }
}