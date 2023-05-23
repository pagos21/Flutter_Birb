using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour {
    public GameObject Pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float hightOffset = 20;
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
        float lowerPoint = transform.position.y - hightOffset;
        float highestPoint = transform.position.y + hightOffset;
        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowerPoint, highestPoint), 0), transform.rotation);
    }
}
