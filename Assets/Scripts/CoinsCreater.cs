using UnityEngine;
using UnityEngine.UIElements;

public class CoinsCreater : MonoBehaviour
{
    public GameObject coin;
    public Vector3[] position;
    public float separation;
    void Start()
    {
        GameObject[] coins = new GameObject[position.Length];
        for (int i = 0; i < position.Length; i++)
        {
            coins[i] = Instantiate(coin, Vector3.zero, Quaternion.identity);
            coins[i].transform.parent = gameObject.transform;
            coins[i].transform.position = position[i] * separation;
        }
    }
}
