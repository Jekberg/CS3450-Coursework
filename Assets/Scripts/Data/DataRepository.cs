﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class DataRepository : MonoBehaviour
{
    [Serializable]
    public struct SaveState
    {
        public float userScore;
        public int gameProgress;
    }

    private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(SaveState));

    public void Save(string fileName)
    {
        var state = new SaveState();
        state.userScore = GlobalCache.Cache.GetOrDefault<float>("Total_Score");
        state.gameProgress = GlobalCache.Cache.GetOrDefault<int>("Level Progress");

        using (var stream = new MemoryStream())
        {
            Serializer.Serialize(stream, state);
            stream.Position = 0;

            var document = new XmlDocument();
            document.Load(stream);
            document.Save(fileName);
        }
    }

    public void Load(string fileName)
    {
        var document = new XmlDocument();
        document.Load(fileName);

        var state = new SaveState();
        using (var x = new StringReader(document.OuterXml))
            state = (SaveState)Serializer.Deserialize(x);

        GlobalCache.Cache.Set("Total_Score", state.userScore);
        GlobalCache.Cache.Set("Level Progress", state.gameProgress);
    }
}
