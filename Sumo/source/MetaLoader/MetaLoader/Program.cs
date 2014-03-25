namespace MetaLoader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using Network;
    using Network.Interfaces;

    using Sumo.Api;

    /// <summary>
    /// The program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Gets or sets the shops.
        /// </summary>
        internal static List<IBookShop> Shops { get; set; }

        /// <summary>
        /// The main.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Shops = new List<IBookShop>();

            var solutionPath = AppDomain.CurrentDomain.BaseDirectory;
            var pluginsList = Directory.GetFiles(solutionPath + "\\shops", "*.dll");

            AddPlugins(pluginsList);
        }

        /// <summary>
        /// The add plugins.
        /// </summary>
        /// <param name="pluginsList">
        /// The plugins list.
        /// </param>
        private static void AddPlugins(IEnumerable<string> pluginsList)
        {
            foreach (var plugin in pluginsList)
            {
                var pluginBody = Assembly.LoadFrom(plugin);
                var pluginTypes = pluginBody.GetTypes();
                foreach (var pluginType in pluginTypes)
                {
                    if (CheckPluginType(pluginType)) AddPlugin(pluginType);
                }
            }
        }

        /// <summary>
        /// The check plugin type.
        /// </summary>
        /// <param name="pluginType">
        /// The plugin type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool CheckPluginType(Type pluginType)
        {
            if (!typeof(IBookShop).IsAssignableFrom(pluginType)) return false;

            foreach (var constructor in pluginType.GetConstructors())
                if ((constructor.GetParameters().Length == 1) && (constructor.GetParameters()[0].ParameterType == typeof(INetwork))) return true;

            return false;
        }

        /// <summary>
        /// The add type.
        /// </summary>
        /// <param name="pluginType">
        /// The plugin type.
        /// </param>
        private static void AddPlugin(Type pluginType)
        {
            var network = new HttpNetwork();
            var pluginCopy = Activator.CreateInstance(pluginType, new object[] { network });
            Shops.Add((IBookShop)pluginCopy);
        }
    }
}
