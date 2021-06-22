using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType { pistol}

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public string name;
    public string description;

    public float force;
    public float recoil;
    public Mesh model;
    public int damage;
    public int roundsPerMinute;
    public int clip;
    public int spareRounds;
    public int reloadTime;
    public bool lethal;
    public int effectiveRange;
    public AmmoType ammo;
}
