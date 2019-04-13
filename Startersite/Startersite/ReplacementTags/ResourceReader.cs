using Startersite.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;
using Startersite.Resources;

namespace Startersite.ReplacementTags
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