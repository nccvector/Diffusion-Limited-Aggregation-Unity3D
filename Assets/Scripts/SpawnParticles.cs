using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnParticles : MonoBehaviour
{
    public GameObject particle_prefab;
    public GameObject camera;

    public int particlesPerFrame = 1;
    float time = 0f;

    // Update is called once per frame
    void Update()
    {
        float dist2Spawn = Vector3.Magnitude(camera.transform.position); // Camera distance from origin

        if(Time.timeSinceLevelLoad - time >= 10f && particlesPerFrame < 4){
            // Double the particles per frame
            particlesPerFrame += 1;
            time = Time.timeSinceLevelLoad;
        }

        for(int i=0; i<particlesPerFrame; i++){
            Instantiate(particle_prefab, new Vector3(
                Random.Range(-dist2Spawn,dist2Spawn),
                Random.Range(-dist2Spawn,dist2Spawn),
                Random.Range(-dist2Spawn,dist2Spawn)
                ), Quaternion.identity);

        }

        // Reset scene if space key pressed or food over
        if(Input.GetKeyDown("space") || Time.timeSinceLevelLoad > 100f){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
