using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class Image
    {
        public string Id { get; set; } = "7B2A2139-005E-4458-A5E1-D724F1D54291";

        public string Name { get; set; } = "File1.jpg";

        public string Path { get; set; } = "https://clmsstorage.blob.core.windows.net/mediafiles/ff8b5e1d838d43fe9cfbf70cce3917aa67b83d2fd07d417bbdb621274777f421?sv=2016-05-31&sr=b&sig=3intsoRJJDtbrMAP9VCG53ZVEL6BYfM7dGa0VYmFqQk%3D&st=2021-01-12T11%3A08%3A28Z&se=2021-01-12T21%3A13%3A28Z&sp=r";

        public int Size { get; set; } = 5536;

        public string MediaType { get; set; } = "image/jpeg";
    }
}
