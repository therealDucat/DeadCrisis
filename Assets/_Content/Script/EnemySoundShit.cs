using System;
using _Content.Script.Utils;
using FMODUnity;
using UnityEngine;
using Sirenix.OdinInspector;
public class EnemySoundShit : MonoBehaviour
{
	[Header("Sounds")]
    public EventReference impactSound;
    public EventReference headOffSound;
	public EventReference fallDeadSound;
    public EventReference stepSounds;
	public EventReference standUpSound;
	public EventReference calmAmbientSound;
	public EventReference spotPlayerSound;
	public EventReference chaseSound;
	
    private Transform _cachedTransform = null;
    public Transform cachedTransform { 
        get { 
            if ( _cachedTransform ) { 
                return _cachedTransform; 
            } else { 
                _cachedTransform = transform;
                return _cachedTransform; 
            }  
        } 
    }
	
	public void Step()
    {
		//Debug.Log("Step");
		if (!Physics.Raycast(transform.position + Vector3.up, Vector3.down, out var hit, 2)) return;
		var groundIndex = GetGroundIndex(hit.collider.material.name);

		FMODManager.Instance.PlaySoundWithParameter(stepSounds, new[]
			{
				new FMODManager.Parameters("surface", groundIndex)
			},
			transform.position);
    }
	
	private int GetGroundIndex(string materialName)
    {
		//Debug.Log("GetGroundIndex");
        if (materialName.StartsWith("WoodMaterial")) return 0;
        if (materialName.StartsWith("RugMaterial")) return 1;
        if (materialName.StartsWith("ConcreteMaterial")) return 2;
        if (materialName.StartsWith("GrassMaterial")) return 3;
        if (materialName.StartsWith("DirtMaterial")) return 4;
        if (materialName.StartsWith("SnowMaterial")) return 5;
        if (materialName.StartsWith("MetalMaterial")) return 6;
        return 5;
    }
    
}