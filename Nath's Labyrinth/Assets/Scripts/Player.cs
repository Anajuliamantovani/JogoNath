using Mono.Cecil;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{

    [SerializeField] private float velocidade;
    float velocidadeNormalizada;
    Vector3 posicaoInicial;

    void Start()
    {
       posicaoInicial = transform.position;
    }

    void Update()
    {
        movimento();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "parede")
        {
            playerRespawn();
        }
    }

    //*****Lrembrete
        
        //if(input.getkey(keycode.e) //enquanto tiver precionado
        //input.getkeyDown
        //input.getkeyUp

        //Tranform.translate(0,0,0);

        //Time.DeltaTime;
    
}
