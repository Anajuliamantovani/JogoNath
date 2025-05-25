//using Mono.Cecil;
using UnityEngine;
//using static System.Runtime.CompilerServices.RuntimeHelpers;
//using UnityEngine.Windows;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    [SerializeField] private float velocidade;
    float velocidadeNormalizada;
    Vector3 posicaoInicial;
    [SerializeField] private GameObject muro;
    [SerializeField] private Sprite bauAberto;
    [SerializeField] private GameObject superBau;
    [SerializeField] private Sprite bauSupremoAberto;
    [SerializeField] private GameObject[] videos;
    [SerializeField] private GameObject musiquinha;

    [SerializeField] bool chaveAzul;
    [SerializeField] bool chaveVerde;
    [SerializeField] bool chaveRosa;
    [SerializeField] bool chaveRoxa;

    [SerializeField] bool abrirBau;

    [SerializeField] bool bauAzul;
    [SerializeField] bool bauVerde;
    [SerializeField] bool bauRosa;
    [SerializeField] bool bauRoxo;

    GameObject bau;
    void Start()
    {
       posicaoInicial = transform.position;
    }

    void Update()
    {
        movimento();
        acoes();
        aparecerBau();
    }
    public void movimento()
    {
        velocidadeNormalizada = velocidade * Time.deltaTime;

        if (UnityEngine.Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, velocidadeNormalizada, 0); 
        }

        if (UnityEngine.Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -velocidadeNormalizada, 0);
        }

        if (UnityEngine.Input.GetKey(KeyCode.D))
        {
            transform.Translate(velocidadeNormalizada, 0, 0);
        }

        if (UnityEngine.Input.GetKey(KeyCode.A))
        {
            transform.Translate(-velocidadeNormalizada, 0, 0);
        }
    }

    public void playerRespawn()
    {
       transform.position = posicaoInicial;
    }

    void acoes()
    {
        if (bau != null && abrirBau == true && UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            bau.GetComponent<SpriteRenderer>().sprite = bauAberto;
            if (bau.name == "superBau")
            {
                bau.GetComponent<SpriteRenderer>().sprite = bauSupremoAberto;
                videos[0].SetActive(true);
                musiquinha.SetActive(false);
            }
        }
    }

    public void sairTela()
    {
        videos[0].SetActive(false); 
        musiquinha.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Parede")
        {
            playerRespawn();
        }

        if(collision.gameObject.name == "ChaveAzul")
        {
            chaveAzul = true;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "ChaveRoxa")
        {
            chaveRoxa = true;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "ChaveRosa")
        {
            chaveRosa = true;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "ChaveVerde")
        {
            chaveVerde = true;
            collision.gameObject.SetActive(false);
        }

        //////////////////////////

        if (collision.gameObject.name == "BauRoxo" && chaveRoxa == true)
        {
            abrirBau = true;
            bauRoxo = true;
            bau = collision.gameObject;
        }

        if (collision.gameObject.name == "BauRosa" && chaveRosa == true)
        {
            abrirBau = true;
            bauRosa = true;
            bau = collision.gameObject;
        }

        if (collision.gameObject.name == "BauVerde"  && chaveVerde == true)
        {
            abrirBau = true;
            bauVerde = true;
            bau = collision.gameObject;
        }

        if (collision.gameObject.name == "BauAzul"  && chaveAzul == true)
        {
            abrirBau = true;
            bauAzul = true;
            bau = collision.gameObject;
        }

        if (collision.gameObject.name == "superBau")
        {
            abrirBau = true;
            bau = collision.gameObject;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Escada")
        {
            muro.GetComponent<TilemapCollider2D>().enabled = false;
        }
        if (collision.gameObject.name == "BauAzul" && UnityEngine.Input.GetKeyDown(KeyCode.E) && chaveAzul == true)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = bauAberto;
        }

    }

    void aparecerBau()
    {
        if (bauAzul == true && bauRosa == true && bauRoxo == true && bauVerde == true)
        {
            superBau.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Escada")
        {
            muro.GetComponent<TilemapCollider2D>().enabled = true;
        }

        if (collision.gameObject.name == "BauRoxo" && chaveRoxa == true)
        {
            abrirBau = false;
            bau = null;
        }

        if (collision.gameObject.name == "BauRosa" && chaveRosa == true)
        {
            abrirBau = false;
            bau = null;
        }

        if (collision.gameObject.name == "BauVerde" && chaveVerde == true)
        {
            abrirBau = false;
            bau = null;
        }

        if (collision.gameObject.name == "BauAzul" && chaveAzul == true)
        {
            abrirBau = false;
            bau = null;
        }

        if (bauAzul == true && bauRosa == true && bauRoxo == true && bauVerde == true)
        {
          
            if (collision.gameObject.name == "superBau")
            {
                abrirBau = false;
                bau = null;
            }
        }


    }



    //*****Lrembrete

    //if(input.getkey(keycode.e) //enquanto tiver precionado
    //input.getkeyDown
    //input.getkeyUp

    //Tranform.translate(0,0,0);

    //Time.DeltaTime;

}
