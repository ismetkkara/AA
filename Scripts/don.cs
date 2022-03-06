using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class don : MonoBehaviour
{
    [SerializeField]
    float donmeHizi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, donmeHizi * Time.deltaTime);
    }
}
