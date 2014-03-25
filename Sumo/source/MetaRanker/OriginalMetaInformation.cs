using System.Collections.Generic;
using System.Xml.Linq;

namespace MetaRanker
{
    public class OriginalMetaInformation
    {
        public XDocument PrimaryMeta { get; private set; }

        public List<XDocument> AlternativeMeta { get; private set; }

        public OriginalMetaInformation(XDocument primaryMeta, List<XDocument> alternativeMeta)
        {
            PrimaryMeta = primaryMeta;
            AlternativeMeta = alternativeMeta;
        }
    }
}