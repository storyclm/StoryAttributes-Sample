using RightPerception.Story.SDK.EAV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class WorkdaySample : ISample
    {
        const string PARENT_ID = "bbb6d2b1.04ff7216-a4cb-4898-bb1c-05ddee1fe68a";
        readonly StoryAttributesClient _client;

        public WorkdaySample(StoryAttributesClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }


        public async Task Run()
        {
            var setResult = await _client.Set<Profile>(PARENT_ID, new Profile());
            var objectResult = await _client.Get<Profile>(PARENT_ID);
        }

    }
}
