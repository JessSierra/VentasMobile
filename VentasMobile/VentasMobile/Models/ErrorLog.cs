using System;
using System.Collections.Generic;
using System.Text;

namespace VentasMobile.Models
{
  public  class ErrorLog
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public List<ErrorLog> Ok()
        {
            List<ErrorLog> List = new List<ErrorLog>();
            ErrorLog Log = new ErrorLog();
            Log.Key = "ok";
            List.Add(Log);
            return List;
        }

        public List<ErrorLog> NewLog(string Key, string Value)
        {
            List<ErrorLog> List = new List<ErrorLog>();
            ErrorLog Log = new ErrorLog();
            Log.Key = Key;
            Log.Value = Value;
            List.Add(Log);
            return List;
        }
    }

}
