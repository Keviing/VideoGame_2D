using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AldeaManager : MonoBehaviour
{
    public GameObject menuVictoria;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            menuVictoria.SetActive(true);

        }

    }
}
