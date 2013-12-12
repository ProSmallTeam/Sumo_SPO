namespace LabirintShop
{
    using System.Collections.Generic;

    using Network.Interfaces;

    using Sumo.API;

    /// <summary>
    /// The labirint book shop.
    /// </summary>
    public class LabirintBookShop : IBookShop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabirintBookShop"/> class.
        /// </summary>
        /// <param name="network">
        /// The network.
        /// </param>
        public LabirintBookShop(INetwork network)
        {
            this.Network = network;
        }

        /// <summary>
        /// Gets or sets the network.
        /// </summary>
        private INetwork Network { get; set; }

        /// <summary>
        /// The search.
        /// </summary>
        /// <param name="pattern">
        /// The pattern.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<Book> Search(Book pattern)
        {
            return new List<Book>();
        }
    }
}
