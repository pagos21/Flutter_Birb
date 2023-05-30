using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour
{
    public GameObject Clouds;
    public float spawnRate = 3;
    private float timer = 0;
    public float hightOffset = 20;
    private float speed = 13;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        speed += 1;
        float lowerPoint = transform.position.y - hightOffset;
        float highestPoint = transform.position.y + hightOffset;
        GameObject clouds = Instantiate(Clouds, new Vector3(transform.position.x, Random.Range(lowerPoint, highestPoint), 18), transform.rotation);
        CloudsMoveScript cloudsMoveScript = clouds.GetComponent<CloudsMoveScript>();
        //In questo modo riesco a creare una nuova instanza di PipeMove con un valore che posso decidere da questo script.
        //Ad esempio riesco ad assegnare la variabile moveSpeed ad un valore incrementale per aumentare la difficoltà ogni 2 secondi
        cloudsMoveScript.moveSpeed = speed;
    }
}
