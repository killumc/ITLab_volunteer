using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace test2.Utilities
{
    public class PaymentSimulator
    {
        public bool ImitatePayment(string projectName, int? amount)
        {

            try
            {
                var donation = new { Project = projectName, Amount = amount, Date = DateTime.Now };
                var filePath = "Donations.json";
                List<object> donations = new();

                if (File.Exists(filePath))
                    donations = JsonSerializer.Deserialize<List<object>>(File.ReadAllText(filePath)) ?? new();

                donations.Add(donation);


                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                };

                File.WriteAllText(filePath, JsonSerializer.Serialize(donations, options));
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
