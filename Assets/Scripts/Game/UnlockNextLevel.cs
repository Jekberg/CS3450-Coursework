using UnityEngine;
public class UnlockNextLevel : MonoBehaviour
{
    [SerializeField] private int nextLevel;    

    private void OnDestroy()
    {
        if (GlobalCache.Cache.GetOrDefault<bool>("Level Complete"))
            GlobalCache.Cache.Set("Level Progress", nextLevel);
    }
}
