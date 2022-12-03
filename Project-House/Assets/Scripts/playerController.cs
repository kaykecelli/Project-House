using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public static playerController Instance;

   
    string nomeCena;
    public float quantidadeDePilulas = 3;
    public SimpleFollow simpleFollow;
    [SerializeField] Image BarraDePilulas;
    public bool[] isFull;
    public GameObject[] slots;
    public List<string> chaves;
    Controles controles;
    [SerializeField]
    float velocidade;
    float x, y;

    

    
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
   
    

   

    private void Awake()
    {
        
        if(Instance != null)
        {

            Destroy(transform.parent.gameObject);
            
        }
        else
        {
            Instance = this;
            chaves = new List<string>();
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            controles = new Controles();
           



        }


    }


    private void OnEnable()
    {
        controles.Enable();
    }
    private void OnDisable()
    {
        controles.Disable();
    }
    private void Update()
    {
        y = controles.Jogo.NorteSul.ReadValue<float>();
        x = controles.Jogo.LesteOeste.ReadValue<float>();
    }





    private void FixedUpdate()
    {



        Vector2 direcao = new Vector2(x, y);
        float magnitude = direcao.sqrMagnitude;
        animator.SetFloat("VELOCIDADE", magnitude);
        animator.SetFloat("HORIZONTAL", x);
        animator.SetFloat("VERTICAL", y);

        


        direcao.Normalize();
        // transform.Translate(direcao*velocidade*Time.deltaTime);
        //Vector2 posicao = (Vector2)transform.position + direcao * velocidade * Time.fixedDeltaTime;
        // rb.MovePosition(posicao);
        rb.velocity = direcao * velocidade;

    }
 


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("CHAVE"))
        {
            chaves.Add(other.name);
            
        }
            
        else if(other.CompareTag("PORTAL"))
        {

            if(chaves.Contains(other.name))
            {
                //chama método do portal que o faz abrir:
                other.gameObject.GetComponent<GoToCene>().Abrir();
            }
        }
       
    }

   
    public bool ChecarChave(string nomeChave)
    {
        return chaves.Contains(nomeChave);
    }
    public void ChamarDeVoltaMonstro()
    {
        
        
            simpleFollow.Voltar();
            quantidadeDePilulas = 3;
        BarraDePilulas.fillAmount += 1f;



    }
    public void ControlePilula(int PilulasTiradas)
    {
        quantidadeDePilulas += PilulasTiradas;
        if(quantidadeDePilulas <= 0)
        {
            ChamarDeVoltaMonstro();
        }
        
    
    }
            
}
              
            
        
