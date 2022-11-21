using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    public GameObject target;
    private Rigidbody2D rdb;
    private Transform player;
    [SerializeField] private float DistanciaDoPlayer;
    [SerializeField] private float velocidadeInimigo;
    public int lives = 1;
    int action;
    GameObject KeepInfo;
    SavePositionPlayer ScriptKI;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] gObjetos = GameObject.FindGameObjectsWithTag("Inimigo");
        if (gObjetos.Length > 1)
        {

            Destroy(gameObject.transform.parent.gameObject);
           

        }
    }
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        KeepInfo = GameObject.FindGameObjectWithTag("KEEPINFO");
        ScriptKI = KeepInfo.GetComponent<SavePositionPlayer>();


        ScriptKI.PlacePlayer();
    }

    
    void FixedUpdate()
    {
        
       

        if (Vector3.Distance(player.position, transform.position) < DistanciaDoPlayer)
        {
            rdb.velocity = (player.position - transform.position).normalized * velocidadeInimigo;
            Invoke("IrProKrl", 3.20f);


        }

      


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, DistanciaDoPlayer);
    }

    void IrProKrl()
    {

        transform.position = new Vector3(500f, 500f);
        ScriptKI.SavePosition();
        Invoke("voltar", 3.20f);



    }
    void Voltar()
    {

        transform.position = player.position - transform.position;
    }
    

    
}
