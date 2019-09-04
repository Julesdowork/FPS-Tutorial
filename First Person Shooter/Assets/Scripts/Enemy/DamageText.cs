using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] float destroyTime = 1f;
    // Don't need these if changing positions through animation
    //[SerializeField] Vector3 offset;
    //[SerializeField] Vector3 randomizeOffset;
    [SerializeField] Color damageColor;

    TextMeshPro damageText;

    void Awake()
    {
        damageText = GetComponent<TextMeshPro>();
        //transform.localPosition += offset;
        //transform.localPosition += new Vector3(
        //    Random.Range(-randomizeOffset.x, randomizeOffset.x),
        //    Random.Range(-randomizeOffset.y, randomizeOffset.y),
        //    Random.Range(-randomizeOffset.z, randomizeOffset.z));
        Destroy(gameObject, destroyTime);
    }

    public void Initialize(int value)
    {
        damageText.text = value.ToString();
    }
}
