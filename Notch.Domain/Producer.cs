﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notch.Domain
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}