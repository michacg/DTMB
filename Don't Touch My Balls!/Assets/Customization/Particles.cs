using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public ParticleSystem particles;
    public GameObject boba;

    public List<ParticleCollisionEvent> collisions;
    private int numCollisionsEvents;

    // Start is called before the first frame update
    void Start()
    {
        collisions = new List<ParticleCollisionEvent>();

    }

    void OnParticleCollision(GameObject other)
    {
        particles.GetCollisionEvents(other, collisions);

        Instantiate(boba, collisions[0].intersection, Quaternion.identity);
    }
}
