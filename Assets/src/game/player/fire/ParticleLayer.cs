using UnityEngine;
using System.Collections;

public class ParticleLayer : MonoBehaviour {

    public float layerHeight = 0f;
    private Vector3 position;

    void Start()
    {
        position = transform.localPosition;
    }

    void Update()
    {
        GameObject go = Camera.main.gameObject;
        Vector3 vec = go.transform.position - transform.position;
        if(transform.parent && (vec.magnitude > layerHeight || layerHeight < 0))
            transform.position = transform.parent.TransformPoint(position) + vec.normalized * layerHeight;
    }

}
