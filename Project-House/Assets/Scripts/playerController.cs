using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public static playerController Instance;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.5f;
   
    string nomeCena;
    public float quantidadeDePilulas = 3;
    public SimpleFollow simpleFollow;

    public List<string> chaves;

    public ContactFilter2D movementFilter;

    Vector2 movementIput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();

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
            

        }


    }

    // Start is called before the first frame update
    void Start()
    {
       
    }
       




  
    
    private void FixedUpdate()
    {
        if (movementIput != Vector2.zero)
        {
            bool success = TryMove(movementIput);
           


            if (!success)
            {
                success = TryMove(new Vector2(movementIput.x, 0));
            }

            if (!success)
            {
                success = TryMove(new Vector2(0, movementIput.y));
            }
            animator.SetFloat("VELOCIDADE", 1);
            
        }
        else
        {
            animator.SetFloat("VELOCIDADE", -1);
            
        }

        
    }
   private bool TryMove(Vector2 direction)
    {
        Vector2 direcao = new Vector2(direction.x, direction.y);
      
        animator.SetFloat("HORIZONTAL", direction.x);
        animator.SetFloat("VERTICAL", direction.y);

        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                   direcao,
                   movementFilter,
                   castCollision,
                   moveSpeed * Time.fixedDeltaTime + collisionOffset);
            if (count == 0)
            {
                rb.MovePosition(rb.position + direcao * moveSpeed * Time.fixedDeltaTime);
                return true;

            }
            
            else
            {
                return true;
            }

        }
        else
        {
            return false;
        }
       

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

    void OnMove(InputValue movementValue)
    {
        movementIput = movementValue.Get<Vector2>();


    }
    public bool ChecarChave(string nomeChave)
    {
        return chaves.Contains(nomeChave);
    }
    public void ChamarDeVoltaMonstro()
    {
        
        
            simpleFollow.Voltar();
            quantidadeDePilulas = 3;
        
        
           
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
              
            
        
