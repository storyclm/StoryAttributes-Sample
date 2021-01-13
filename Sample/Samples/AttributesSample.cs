using RightPerception.Story.SDK.EAV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class AttributesSample : ISample
    {
        const string PARENT_ID = "bbb6d2b1.04ff7216-a4cb-4898-bb1c-05ddee1fe68a";
        readonly StoryAttributesClient _client;

        public AttributesSample(StoryAttributesClient client) =>
            _client = client ?? throw new ArgumentNullException(nameof(client));

        static StoryAttribute CreateNode(string parentId, string id, string key, object value, params StoryAttribute[] attributes) =>
            new StoryAttribute()
            {
                ParentId = parentId,
                Id = id,
                Key = key,
                Value = value,
                Modified = DateTime.UtcNow,
                Attributes = attributes.ToList()
            };


        StoryAttribute storyAttribute =>
            CreateNode(PARENT_ID, "Level_1-1", "Data", "main data",
                CreateNode("Level_1-1", "Level_2-1", "age", 33),
                CreateNode("Level_1-1", "Level_2-2", "numberInteger", 222),
                CreateNode("Level_1-1", "Level_2-3", "bool_type", true,
                    CreateNode("Level_2-3", "Level_3-1", "First", "Аркадий"),
                    CreateNode("Level_2-3", "Level_3-2", "NumberFloat", 888.777,
                        CreateNode("Level_3-2", "Level_4-1", "type", 2))));

        public async Task Run()
        {
            var result = await _client.Get(PARENT_ID);
            var setResult = await _client.Set(storyAttribute);
            var getSetResult = await _client.Get(PARENT_ID);
            var deletedResult = await _client.Remove(getSetResult.First().Id);
        }

    }
}
