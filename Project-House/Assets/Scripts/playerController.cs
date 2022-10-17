using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.5f;


    [SerializeField]
    string novaCena;


    public ContactFilter2D movementFilter;

    Vector2 movementIput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();

    private void Awake()
    {
        
        GameObject[] gObjetos = GameObject.FindGameObjectsWithTag("Principal");
        if (gObjetos.Length > 1)
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(gameObject.transform.parent.gameObject);
            //valido apenas para o player como primeiro filho
            gObjetos[0].transform.GetChild(0).transform.position = pos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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
                return false;
            }

        }
        else
        {
            return false;
        }
       

    }












    void OnMove(InputValue movementValue)
    {
        movementIput = movementValue.Get<Vector2>();


    }
    public void UsarPilula()
    {
      

        if (Input.GetKeyDown(KeyCode.G))
        {
            
            SceneManager.LoadScene(novaCena);

        }




    }
}
