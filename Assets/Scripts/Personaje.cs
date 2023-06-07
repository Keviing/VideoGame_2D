using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject MenuGameOver;
    [SerializeField] private float velocidad;
    [SerializeField] private BoxCollider2D colEspada;
    private float posColX = (float)-0.2861199;
    private float posColY = (float)-0.1455585;
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer SpritePersonaje;
    private int vidaPersonaje = 3;
    [SerializeField] UiManager uiManager;
    public bool gameOver = false;
    public bool start = false;
    public bool restart = false;
    // Start is called before the first frame update
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        SpritePersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Ataca");
        }

        if (start == true && gameOver == true)
        {
            // Resto del código...

            if (Input.GetKeyDown(KeyCode.X))
            {
                restart = true;
            }
        }


    }

    private void FixedUpdate()
    {
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }


        if (start == true && gameOver == true) {
            MenuGameOver.SetActive(true);

            if(Input.GetKeyDown(KeyCode.X))
            {
               
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && gameOver == false)
        {
            MenuPrincipal.SetActive(false);
            movimiento();

        }
        
    }

    private void movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rig.velocity = new Vector2(horizontal, vertical)* velocidad;
        anim.SetFloat("Caminar", Mathf.Abs(rig.velocity.magnitude));
        if (horizontal > 0)
        {
            colEspada.offset = new Vector2(-posColX,posColY);
            SpritePersonaje.flipX = true;
        } else if (horizontal < 0) {
            colEspada.offset = new Vector2(posColX, posColY);
            SpritePersonaje.flipX=false;
        }

    }

    public void CausarHerida()
    {
        if (vidaPersonaje > 0)
        {
            vidaPersonaje--;
            uiManager.RestaCorazones(vidaPersonaje);
            if(vidaPersonaje == 0)
            {
                gameOver = true;
                anim.SetTrigger("Muere");
                Invoke(nameof(Morir),1f);
                Debug.Log("Hemos Muerto");
                print(gameOver.ToString());
                

            }
        }
    }

    private void Morir()
    {
        Destroy(this.gameObject);
    }
}
