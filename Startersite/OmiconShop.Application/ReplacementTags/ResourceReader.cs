using OmiconShop.Application.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;

namespace OmiconShop.Application.ReplacementTags
{
    public class ResourceReader
    {
        public string GetResourceValueByKey(string key)
        {
            string resourceValue = null;

            try
            {
                resourceValue = key;
            }
            catch (Exception e)
            {
                CreateLogFiles logFiles = new CreateLogFiles();
                logFiles.CreateErrorLog(e.Message);
            }

            return resourceValue;
        }
    }
}