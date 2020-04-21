using System;
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
    }

    private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(SaveState));

    public void Save(string fileName)
    {
        var state = new SaveState();
        state.userScore = GlobalCache.Cache.Get<float>("Total_Score");

        using (var stream = new MemoryStream())
        {
            Serializer.Serialize(stream, state);
            stream.Position = 0;

            var document = new XmlDocument();
            document.Load(stream);
            document.Save(fileName);
        }
    }

    public void Load(int id)
    {
    }
}
