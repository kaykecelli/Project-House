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
            //valido apenas para o player como primeiro filho

        }
    }
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        NextAction();
        KeepInfo = GameObject.FindGameObjectWithTag("KEEPINFO");
        ScriptKI = KeepInfo.GetComponent<SavePositionPlayer>();


        ScriptKI.PlacePlayer();
    }

    // Update is called once per frame
    void Andar()
    {
        //Checagem da distancia do player
       

        if (Vector3.Distance(player.position, transform.position) < DistanciaDoPlayer)
        {
            rdb.velocity = (player.position - transform.position).normalized * velocidadeInimigo;

        }

        Invoke("NextAction", 2.20f);


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, DistanciaDoPlayer);
    }

    void IrProKrl()
    {

        transform.position = transform.position + new Vector3(500f, 500f);
        ScriptKI.SavePosition();
    }
    

    void NextAction()
    {
        switch (action)
        {
            case 0:
                Andar();
                break;
            case 1:
                IrProKrl();
                break;
            
        }
        action++;
        if (action > 2)
        {
            action = 0;
        }
    }
}
