﻿using HtmlAgilityPack;

namespace Sumo.Api.Network
{
    /// <summary>
    /// The Network interface.
    /// </summary>
    public interface INetwork
    {
        /// <summary>
        /// The load document.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <returns>
        /// The <see cref="HtmlDocument"/>.
        /// </returns>
        Page LoadDocument(string url);
    }
}
