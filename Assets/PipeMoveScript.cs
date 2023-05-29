using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    //la deadzone è la parte dello schermo non visibile dove vengono distrutti i componenti per fare spazio alla memoria
    public float deadZone = -45;
    // Start is called before the first frame update.

    void Start()
    {
        //Debug.Log(moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = transform.position + (Vector3.left  * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            //Debug.Log("pipe deleted, yo");
            Destroy(gameObject);
        }
    }

}
