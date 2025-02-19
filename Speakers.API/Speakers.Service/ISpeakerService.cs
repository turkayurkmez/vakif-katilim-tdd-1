﻿using Speakers.Domain;

namespace Speakers.Service
{
    public interface ISpeakerService
    {
        IEnumerable<Speaker> GetSpeakers();
        IEnumerable<Speaker> SearchSpeakersByName(string name);

        Speaker Create(Speaker speaker);
        Speaker GetSpeaker(int id);
    }
}