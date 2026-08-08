using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Objects")]
    public GameObject ObjetoSpawn;
    public GameObject[] ObjetosSpawn;


    [Header("Spawn Settings")]
    public int CantidadObjetosSpawn = 5;
    public float TiempoEntreSpawns = 2f;
    public float OffsetSpawnXMax = 19;
    public float OffsetSpawnXMin = -19;
    public float SpawnY = 65f;
    public float SpawnZ = 95f;
    public float ForceSpawnObject = 10f;

    void Start()
    {
        StartCoroutine(BucleCreacionObjetos());
    }

    public IEnumerator BucleCreacionObjetos()
    {
        
        while (true)
        {
            GameObject[] ObjetosSpawnEnEscena = GameObject.FindGameObjectsWithTag("ObjetoSpawn");
            if(ObjetosSpawnEnEscena.Length < CantidadObjetosSpawn)
            {
                yield return new WaitForSeconds(TiempoEntreSpawns);
                CrearObjetoSpawn();
            }
        }
    }

    public void CrearObjetoSpawn()
    {
        GameObject ObjetoSpawnPadre = Instantiate(ObjetoSpawn, new Vector3(Random.Range(OffsetSpawnXMin, OffsetSpawnXMax), SpawnY, SpawnZ), Quaternion.identity);
        CrearObjetoHijoSpawn(ObjetoSpawnPadre);
        Rigidbody rb = ObjetoSpawnPadre.GetComponentInChildren<Rigidbody>();
        //rb.AddForce(Vector3.down * ForceSpawnObject);
    }


    public  GameObject CrearObjetoHijoSpawn(GameObject ObjetoSpawnPadre)
    {
        int ObjetoRandom = Random.Range(0, 10);

        if (ObjetoRandom >= 0 && ObjetoRandom <= 5)//Gana el objeto positivo como spawn
        {
            GameObject ObjetoHijo = Instantiate(ObjetosSpawn[0], ObjetoSpawnPadre.transform);
            return ObjetoHijo;
        }
        else if(ObjetoRandom > 5 && ObjetoRandom < 10)//Gana el objeto negativo como spawn
        {
            ObjetoRandom = Random.Range(1, ObjetosSpawn.Length);
            GameObject ObjetoHijo = Instantiate(ObjetosSpawn[ObjetoRandom], ObjetoSpawnPadre.transform);
        }
        
        Debug.Log("Esta Fuera del rango en al crear el numero random");
        return null;
        
        

    }

}
