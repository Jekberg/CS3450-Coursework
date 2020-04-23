using UnityEngine;

public class SetFloatParameterToMovementSpeed : MonoBehaviour
{
    [SerializeField] private string parameterName;
    private int parameterId;
    private Vector3 previousPosition;

    private Animator Animation { get { return GetComponent<Animator>(); } }

    private void Awake()
    {
        parameterId = Animator.StringToHash(parameterName);
        previousPosition = transform.position;
    }

    private void Update()
    {
        var currentPos = transform.position;
        Animation.SetFloat(parameterId, (currentPos - previousPosition).magnitude / Time.deltaTime);
        previousPosition = currentPos;
    }
}
