using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Player Data")]
    public PlayerData playerData;


    [Header("Spawn Objects")]
    public GameObject[] ObjetosSpawn;


    [Header("Spawn object Settings")]
    public int CantidadObjetosSpawn = 5;
    public float TiempoEntreSpawns = 2f;
    public float OffsetSpawnXMax = 19;
    public float OffsetSpawnXMin = -19;
    public float SpawnY = 65f;
    public float SpawnZ = 95f;
    private float ImpulsoMaximo;
    private float ImpulsoMinimo;


    [Header("Spawn Obstacles")]

 
    GameObject ReferencesSpawnObstacles;

    public GameObject[] SpawnObstacles;
    public int CantidadobstaculosSpawn = 2;
    public float TiempoEntreSpawnsObstaculos = 3f;
    public float TiempoDestruccionObstaculos = 15f;
    public float OffsetSpawnXMaxObstacles;
    public float OffsetSpawnXMinObstacles;
    public float SpawnYObstacles;
    public float SpawnZObstacles;

    void Awake()
    {
        ReferencesSpawnObstacles = GameObject.Find("ReferenceObstacles");
        OffsetSpawnXMaxObstacles = ReferencesSpawnObstacles.GetComponent<Transform>().position.x + ReferencesSpawnObstacles.GetComponent<Transform>().localScale.x / 2;
        OffsetSpawnXMinObstacles = ReferencesSpawnObstacles.GetComponent<Transform>().position.x - ReferencesSpawnObstacles.GetComponent<Transform>().localScale.x / 2;
        SpawnYObstacles = ReferencesSpawnObstacles.GetComponent<Transform>().position.y + ReferencesSpawnObstacles.GetComponent<Transform>().localScale.y / 2;
        SpawnZObstacles = ReferencesSpawnObstacles.GetComponent<Transform>().position.z + ReferencesSpawnObstacles.GetComponent<Transform>().localScale.z / 2;

        ImpulsoMaximo = playerData.Impulso[1];
        ImpulsoMinimo = playerData.Impulso[0];

    }

    void Start()
    {
        StartCoroutine(BucleCreacionObjetos());
        StartCoroutine(BucleCreacionObstaculos());


    }

    public void actualizarImpulso()
    {
        ImpulsoMaximo = playerData.Impulso[1];
        ImpulsoMinimo = playerData.Impulso[0];
    }

    public IEnumerator BucleCreacionObjetos()
    {
        
        while (true)
        {
            GameObject[] ObjetosSpawnEnEscenaPositivo = GameObject.FindGameObjectsWithTag("ObjetoPositivo");
            GameObject[] ObjetosSpawnEnEscenaNegativo = GameObject.FindGameObjectsWithTag("ObjetoNegativo");
            GameObject[] ObjetosSpawnEnEscenaPoder = GameObject.FindGameObjectsWithTag("ObjetoPoder");
            if(ObjetosSpawnEnEscenaPositivo.Length + ObjetosSpawnEnEscenaNegativo.Length + ObjetosSpawnEnEscenaPoder.Length < CantidadObjetosSpawn)
            {
               
                CrearObjetoSpawn();
                //Debug.Log("Objetos en escena: " + (ObjetosSpawnEnEscenaPositivo.Length + ObjetosSpawnEnEscenaNegativo.Length));
            } 
            
            yield return new WaitForSeconds(TiempoEntreSpawns);
        }
    }

    public IEnumerator BucleCreacionObstaculos()
    {
        while (true)
        {
            GameObject[] ObstaculosSpawnEnEscena = GameObject.FindGameObjectsWithTag("Obstaculo");
            if (ObstaculosSpawnEnEscena.Length < CantidadobstaculosSpawn)
            {
                CrearObstaculoSpawn();
                //Debug.Log("Obstaculos en escena: " + ObstaculosSpawnEnEscena.Length);
            }
            yield return new WaitForSeconds(TiempoEntreSpawnsObstaculos);
        }
    }

    public void CrearObjetoSpawn()
    {
        int NumeroRandom = Random.Range(0, 10);
        float ImpulsoRandom = Random.Range(ImpulsoMinimo, ImpulsoMaximo);

        if (NumeroRandom >= 0 && NumeroRandom <= 5)//Gana el objeto positivo como spawn
        {
            GameObject Objeto;
            if (NumeroRandom == 5)
            {
                Objeto = Instantiate(ObjetosSpawn[1], new Vector3(Random.Range(OffsetSpawnXMin, OffsetSpawnXMax), SpawnY, SpawnZ), Quaternion.identity);      
            }
            else
            {
                Objeto = Instantiate(ObjetosSpawn[0], new Vector3(Random.Range(OffsetSpawnXMin, OffsetSpawnXMax), SpawnY, SpawnZ), Quaternion.identity);
            }
            Rigidbody rb = Objeto.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.down * ImpulsoRandom, ForceMode.Impulse);
            //Debug.Log("Se creo el objeto positivo" + Objeto.name);
            Objeto.AddComponent<DetectarColision>();
        }
        else if(NumeroRandom > 5 && NumeroRandom < 10)//Gana el objeto negativo como spawn
        {
            NumeroRandom = Random.Range(2, ObjetosSpawn.Length);
            GameObject Objeto = Instantiate(ObjetosSpawn[NumeroRandom], new Vector3(Random.Range(OffsetSpawnXMin, OffsetSpawnXMax), SpawnY, SpawnZ), Quaternion.identity);
            Rigidbody rb = Objeto.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.down * ImpulsoRandom, ForceMode.Impulse);
            //Debug.Log("Se creo el objeto negativo" + Objeto.name);
            Objeto.AddComponent<DetectarColision>();
        } 
    }

    public void CrearObstaculoSpawn()
    {
        GameObject Obstaculo;
        Obstaculo = Instantiate(SpawnObstacles[Random.Range(0, SpawnObstacles.Length)], 
            new Vector3(Random.Range(OffsetSpawnXMinObstacles, OffsetSpawnXMaxObstacles), 
            SpawnYObstacles, SpawnZObstacles), Quaternion.identity);

        Debug.Log("Se creo el obstaculo" + Obstaculo.name);
        StartCoroutine(DestruirObjeto(Obstaculo));
    }

    public IEnumerator DestruirObjeto(GameObject Obstaculo)
    {
        yield return new WaitForSeconds(TiempoDestruccionObstaculos);
        Destroy(Obstaculo);
    }
}
