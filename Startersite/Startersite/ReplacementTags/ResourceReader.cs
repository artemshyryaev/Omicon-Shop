using Startersite.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;

namespace Startersite.ReplacementTags
{
    public class ResourceReader
    {
        ResourceManager resourceManager;

        public ResourceReader(string resourceNamespace)
        {
            this.resourceManager = new ResourceManager(resourceNamespace, Assembly.GetExecutingAssembly());
        }

        public string GetResourceValueByKey(string key)
        {
            string resourceValue = null;

            try
            {
                resourceValue = resourceManager.GetString(key);
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