using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNAMS.Manager.Common
{
    public class CommonManager
    {
        private readonly ResponseModel _aModel;

        public CommonManager()
        {
            _aModel=new ResponseModel();
        }
        public int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size    
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            var random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        // Generate a random password    
        public string RandomPassword()
        {
            var builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        public ResponseModel GetYearForDropDown()
        {
            var data = new List<int>();
            var currentYear = DateTime.Now.Year;
            for (var i = currentYear - 3; i < currentYear + 3; i++)
            {
                data.Add(i);
            }
            return _aModel.Respons(data);
        }

        public ResponseModel GetMonthDropDown()
        {
            var data = new List<string>
            {
                "","January","February","March","April","May","June","July","August","September","October","November","December"
            };

            return _aModel.Respons(data);
        }



    }


}
