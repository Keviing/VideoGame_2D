using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemigos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cobre;
    public void muertesAll()
    {
        if (transform.childCount == 1)
        {
            cobre.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        muertesAll();
    }
}
