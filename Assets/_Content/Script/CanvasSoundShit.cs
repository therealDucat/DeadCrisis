using System;
using _Content.Script.Utils;
using FMODUnity;
using UnityEngine;
using Sirenix.OdinInspector;

public class CanvasSoundShit : MonoBehaviour
{
    [Header("Weapon")]
    public EventReference pickupAmmo;
    public EventReference pickupPistol;
    public EventReference pickupShotgun;
	
	[Header("Items")]
	public EventReference pickupItem;
	public EventReference pickupKeycard;
	public EventReference collectKitten;	
}
