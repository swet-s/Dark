using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MultiSound : MonoBehaviour
{
    public Transform[] clickEmitter;
    private void Awake()
    {
        foreach (Transform butt in clickEmitter)
        {
            butt.GetComponent<Button>().onClick.AddListener(() => { PlaySound();});
        }

    }

    void PlaySound()
    {
        FindObjectOfType<AudioCreater>().PlayClick();
    }
}
