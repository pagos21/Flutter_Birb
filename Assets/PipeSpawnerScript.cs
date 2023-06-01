using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour {
    public GameObject Pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float hightOffset = 20;
    private float speed = 30;
    public Rigidbody2D rigidBirb;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        }
        else {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe() {

        speed += 1;
        
        float lowerPoint = transform.position.y - hightOffset;
        float highestPoint = transform.position.y + hightOffset;
        GameObject pipe = Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowerPoint, highestPoint), 2), transform.rotation);
        PipeMoveScript pipeMoveScript = pipe.GetComponent<PipeMoveScript>();
        //In questo modo riesco a creare una nuova instanza di PipeMove con un valore che posso decidere da questo script.
        //Ad esempio riesco ad assegnare la variabile moveSpeed ad un valore incrementale per aumentare la difficoltà ogni 2 secondi
        pipeMoveScript.moveSpeed = speed;
        Transform topPipe = pipe.transform.GetChild(0);
        Transform bottomPipe = pipe.transform.GetChild(1);
        topPipe.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        bottomPipe.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        rigidBirb.mass = 100;
    }
}
