using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Objects")]
    public GameObject[] ObjetosSpawn;


    [Header("Spawn Settings")]
    public int CantidadObjetosSpawn = 5;
    public float TiempoEntreSpawns = 2f;
    public float OffsetSpawnXMax = 19;
    public float OffsetSpawnXMin = -19;
    public float SpawnY = 65f;
    public float SpawnZ = 95f;
    private float ImpulsoMaximo = 100f;
    private float ImpulsoMinimo = 10f;

    void Start()
    {
        StartCoroutine(BucleCreacionObjetos());
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

    public void CrearObjetoSpawn()
    {
        int NumeroRandom = Random.Range(0, 10);
        float ImpulsoRandom = Random.Range(ImpulsoMinimo, ImpulsoMaximo);

        if (NumeroRandom >= 0 && NumeroRandom <= 5)//Gana el objeto positivo como spawn
        {
            GameObject Objeto;
            if (NumeroRandom >= 4)
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
}
