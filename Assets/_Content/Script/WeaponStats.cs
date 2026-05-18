using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStats : MonoBehaviour
{
    [Header("WEAPON PARAMS")]
    public string weaponName;
    public float weaponDamage = 10f;
    public float fireDelay = 0.3f;
    public float reloadingTime = 1.2f;
    public int ammoInClip = 8;
    public int bulletsPerShot = 1;
    public Vector2 weaponSpread;
    public bool drawTrasser;
    public bool stop;
    public float shakeIntensity = 0.7f;
    public float shakeTime = 0.2f;
    
    [Space(10)]  [Header("PREFABS")]
    public GameObject clipObject;

    [Space(10)] [Header("SCENE OBJECTS")]
    public ParticleSystem muzzleFlash;
    public ParticleSystem shells;
    public Text bulletsAmountText;
    public Transform shootSpot;
    public Transform clipTransform;
    
}
