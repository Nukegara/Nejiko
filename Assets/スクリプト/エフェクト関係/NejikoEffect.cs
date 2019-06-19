using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoEffect : MonoBehaviour
{
    string nejikoAnim;
    ParticleSystem runEffect;
    // Start is called before the first frame update
    void Start()
    {
        runEffect = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        runEffect.Play();
    }
}
