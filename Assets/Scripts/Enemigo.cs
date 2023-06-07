using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public Transform personaje; 
    private NavMeshAgent agent;
    private int indiceRuta;
    public Transform[] puntosRuta;
    private bool objetivoDetectado;
    private SpriteRenderer sprite;
    private Transform objetivo;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }   

    private void Update()
    {


        this.transform.position = new Vector3(transform.position.x, transform.position.y,0);
        if(personaje != null)
        {
            float distancia = Vector3.Distance(personaje.position, this.transform.position);
            if (this.transform.position == puntosRuta[indiceRuta].position)
            {
                if (indiceRuta < puntosRuta.Length - 1)
                {
                    indiceRuta++;
                }
                else if (indiceRuta == puntosRuta.Length - 1)
                {
                    indiceRuta = 0;
                }
            }
            if (distancia < 3)
            {
                objetivoDetectado = true;
            }
            MovimientoEnemigo(objetivoDetectado);
            RotarEnemigo();
        }
        void MovimientoEnemigo(bool esDetectado)
        {
            if (esDetectado)
            {
                agent.SetDestination(personaje.position);
                objetivo = personaje;
            }
            else
            {
                agent.SetDestination(puntosRuta[indiceRuta].position);
                objetivo = puntosRuta[indiceRuta];
            }
        }

        void RotarEnemigo()
        {
            if (this.transform.position.x < objetivo.position.x)
            {
                //sprite.flipX = true;
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                //   sprite.flipX=false;
                transform.localScale = new Vector2(1, 1);

            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Ataca");

        }
    }
}
