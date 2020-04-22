using System.Collections.Generic;
using UnityEngine;

public class GlobalCache : MonoBehaviour
{
    public class DataCache
    {
        private readonly Dictionary<string, object> cache = new Dictionary<string, object>();
        
        internal DataCache() { }

        public void Clear()
        {
            cache.Clear();
        }

        public void Set(string key, object value)
        {
            cache[key] = value;
        }

        public void Erase(string key)
        {
            cache.Remove(key);
        }

        public bool Contains(string key)
        {
            return cache.ContainsKey(key);
        }

        public T Get<T>(string key)
        {
            return (T)cache[key];
        }

        public T GetOrDefault<T>(string key) where T : new()
        {
            return Contains(key) ? Get<T>(key) : new T(); ;
        }
    }

    public static DataCache Cache
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Cache == null)
        {
            Cache = new DataCache();
            Debug.Log(string.Format("Cache created: {0}", Cache));
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Saving...");
            new DataRepository().Save("Assets/Saves/Test123.xml");
        }
    }
}
