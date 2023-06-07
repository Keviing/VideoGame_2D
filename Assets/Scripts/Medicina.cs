using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicina : MonoBehaviour
{

    public delegate void SumaMedicina(int medicina);
    public static event SumaMedicina sumaMedicina;
    [SerializeField] private int cantidadMedicina;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Player"))
        {
            if ( sumaMedicina != null)
            {
                SumarMedicina();
                Destroy(this.gameObject);

            }

        }

        
    }
    private  void SumarMedicina()
    {
        sumaMedicina(cantidadMedicina);

    }
}
