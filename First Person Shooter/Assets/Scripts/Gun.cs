using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public string gunName;
    public GameObject prefab;

    [Header("Stats")]
    public float minDamage;
    public float maxDamage;
    public float maxRange;

    public virtual void OnMouseDown(Transform cameraPos)
    {
        
    }

    public virtual void OnMouseHold(Transform cameraPos)
    {

    }
}
