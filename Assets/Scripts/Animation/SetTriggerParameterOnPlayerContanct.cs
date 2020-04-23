using UnityEngine;

public class SetTriggerParameterOnPlayerContanct : MonoBehaviour
{
    [SerializeField] private string parameterName;
    private int parameterId;
    private Animator Animation { get { return GetComponent<Animator>(); } }

    public void SetPlayerContact()
    {
        Animation.SetTrigger(parameterId);
    }

    private void Awake()
    {
        parameterId = Animator.StringToHash(parameterName);
    }

    private void Update()
    {
        Animation.ResetTrigger(parameterId);
	}

}
