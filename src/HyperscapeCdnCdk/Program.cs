﻿using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HyperscapeCdnCdk
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            app.Synth();
        }
    }
}
