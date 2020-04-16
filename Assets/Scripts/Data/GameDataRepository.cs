using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class GameDataRepository : MonoBehaviour
{
    [Serializable]
    public struct SaveState
    {
        string name;
        float userScore;
        float timePlayed;
        uint nextLevel;
    }

    private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(SaveState));

    public string Location
    {
        get;
        set;
    }

    public void Save(int id)
    {
        using (var stream = new MemoryStream())
        {
            Serializer.Serialize(stream, null);
            stream.Position = 0;

            var document = new XmlDocument();
            document.Load(stream);
            document.Save("");
        }
    }

    public void Load(int id)
    {
    }
}
