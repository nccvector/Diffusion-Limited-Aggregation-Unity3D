using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float speed = 5.0f;
    public bool isStill = false;

    Renderer renderer = new Renderer();

    void Start(){

        renderer = GetComponent<Renderer>();
        if(isStill){
            renderer.enabled = true;
        }else{
            renderer.enabled = false;
        }
    }

    void FixedUpdate(){
        if(!isStill){
            Vector3 random_dir = new Vector3(Random.Range(-10,10),Random.Range(-10,10),Random.Range(-10,10));
            random_dir = Vector3.Normalize(random_dir);
            Vector3 origin_dir = Vector3.Normalize(Vector3.zero - transform.position);

            random_dir += origin_dir;
            random_dir = Vector3.Normalize(random_dir);

            gameObject.transform.position += random_dir * speed * Time.deltaTime;

        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<Particle>().isStill){
            isStill = true;
            renderer.enabled = true;
        }
    }
}
