using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour {

    public float spawnEffectTime = 2;
    public float pause = 1;
    public AnimationCurve fadeIn;

    ParticleSystem ps;
    float timer = 0;
    Renderer _renderer;

    int shaderProperty;
    public Material dissolve;

    public bool triggered;
	void Start ()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();
        ps = GetComponentInChildren <ParticleSystem>();
        var shape = ps.shape;
        shape.shapeType = ParticleSystemShapeType.MeshRenderer;
        shape.meshRenderer = this.GetComponent<MeshRenderer>();
        var main = ps.main;
        main.duration = spawnEffectTime;
        ps.Stop();

        triggered = false;
        

    }
	
	void Update ()
    {


        if (triggered)
        {
            if (timer < spawnEffectTime + pause)
            {
                timer += Time.deltaTime;
            }
            
            _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));
        }

        if (_renderer.material.HasProperty(shaderProperty) && _renderer.material.GetFloat(shaderProperty) == 1.0f && !ps.isPlaying) {
            Destroy(this.gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("FireMagic")&&!triggered)
        {
            ps.Play();
            triggered = true;
            this.gameObject.GetComponent<MeshRenderer>().material = dissolve;
        }
    }


}
