﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace test2.Models
{
    public class CardModel
    {
        public int Id { get; set; }

        public string Title {  get; set; }

        public string Description { get; set; }

        public string ImageSource {  get; set; }

        public bool ItsRed { get; set; }
    }
}
