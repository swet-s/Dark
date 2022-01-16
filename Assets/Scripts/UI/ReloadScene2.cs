using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReloadScene2 : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
