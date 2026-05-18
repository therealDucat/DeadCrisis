using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{

    public ParticleSystem particleLauncher;
//    public ParticleSystem splatterParticles;
    public ParticleDecalPool splatDecalPool;
    public Gradient particleColorGradient;

    List<ParticleCollisionEvent> collisionEvents;

    void Start ()
    {
        collisionEvents = new List<ParticleCollisionEvent> ();
    }

    void OnParticleCollision (GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents (particleLauncher, other, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++)
        {
            splatDecalPool.ParticleHit (collisionEvents [i], particleColorGradient);
            //EmitAtLocation (collisionEvents[i]);
        }

    }

//    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
//    {
//        if (splatterParticles != null)
//        {
//            splatterParticles.transform.position = particleCollisionEvent.intersection;
//            splatterParticles.transform.rotation = Quaternion.LookRotation (particleCollisionEvent.normal);
//            splatterParticles.Emit(1);
//       }
//    }

    void Update()
    {        
    }
}
