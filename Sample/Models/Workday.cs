using System;
using System.Collections.Generic;
using System.Globalization;

namespace Sample
{
    public class Workday
    {

        public string BlobProvider { get; set; } = "MysteryShopper";


        public string Date { get; set; } = DateTime.Now.ToString("o", CultureInfo.InvariantCulture);


        public string Start { get; set; } = DateTime.Now.ToString("o", CultureInfo.InvariantCulture);


        public string End { get; set; } = DateTime.Now.ToString("o", CultureInfo.InvariantCulture);


        public int TimeZone { get; set; } = 3;


        public string Status { get; set; } = "Work";


        public string Text { get; set; } = "Вкратце о себе: характер невыносимый, мнение - нерушимое, поведение - неадекватное, любовь - неудержимая";


        public Dictionary<string, Image> Images { get; set; } = new Dictionary<string, Image>()
        {
            ["image-1"] = new Image(),
            ["image-2"] = new Image()
        };

    }
}
