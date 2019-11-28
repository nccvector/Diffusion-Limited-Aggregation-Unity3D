using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    public GameObject particle_prefab;
    public GameObject camera;

    public int particlesPerFrame = 1;

    // Update is called once per frame
    void Update()
    {
        float dist2Spawn = Vector3.Magnitude(camera.transform.position); // Camera distance from origin

        for(int i=0; i<particlesPerFrame; i++){
            Instantiate(particle_prefab, new Vector3(
                Random.Range(-dist2Spawn,dist2Spawn),
                Random.Range(-dist2Spawn,dist2Spawn),
                Random.Range(-dist2Spawn,dist2Spawn)
                ), Quaternion.identity);
        }
    }
}
