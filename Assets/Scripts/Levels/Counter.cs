using UnityEngine.Events;
using UnityEngine;

public class Counter : MonoBehaviour
{

    public int totalUnit;

    public void countdown()
    {
        totalUnit -= 1;
        if (totalUnit == 0)
            OnZero.Invoke();

    }


    [Header("Events")]

    public UnityEvent OnZero;
    public class BoolEvent : UnityEvent<bool> { }
}
