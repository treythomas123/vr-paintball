using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {

    void Awake()
    {
        Destroy(gameObject, 5);
    }
}
