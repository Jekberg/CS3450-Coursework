using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    private uint maxEnemyCapacity;
    private HashSet<EnemyController> enemies = new HashSet<EnemyController>();

    
}
