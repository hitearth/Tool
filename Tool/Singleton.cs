using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hitearth.Tool
{
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        public static Singleton Instance { get { return instance; } }

        private Singleton()
        {

        }

    }
}
