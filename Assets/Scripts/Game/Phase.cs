using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour
{
    struct ObjectiveItem
    {
        public GameObject objective;
        public Func<bool> iscomplete;
    }

    private HashSet<ObjectiveItem> objectives = new HashSet<ObjectiveItem>();

    public bool Completed
    {
        get {
            return objectives
                .Select(objective => objective.iscomplete())
                .Aggregate(true, (status, agg) => agg && status);
        }
    }

    public IEnumerable<GameObject> ToComplete
    {
        get { return objectives.Select(objective => objective.objective); }
    }

    public void AddObjective(GameObject objective, Func<bool> isComplete)
    {
        ObjectiveItem item = new ObjectiveItem();
        item.objective = objective;
        item.iscomplete = isComplete;
        objectives.Add(item);
    }
}
