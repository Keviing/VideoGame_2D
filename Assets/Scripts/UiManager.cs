using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private int totalMedicinas;
    [SerializeField] private TMP_Text TextoMedicina;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonDesactivado;

    private void Start()
    {
        Medicina.sumaMedicina += SumarMedicinas; 
    }

    private void SumarMedicinas( int medicina)
    {
        totalMedicinas += medicina;
        TextoMedicina.text = totalMedicinas.ToString();

    }

    public void RestaCorazones(int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado; 
    }
}
