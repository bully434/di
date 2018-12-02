using System;
using System.Collections.Generic;
using TagCloud.TagCloudVisualization.Analyzer;

namespace TagCloud.Interfaces
{
    public interface ITagCloudLayouter
    {
        List<Tag> GetTags(Dictionary<String, int> weightedWords);
    }
}