﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistletoeGrowthController : MonoBehaviour {

    public GameObject small_plant;
    public GameObject big_plant;
    public GameObject finial_plant;
    public bool enable_growth = true;

    // Use this for initialization
    private bool isRunning = false;


    private void Start()
    {
        //StartCoroutine(Plant_growth());
        
    }

    private void OnMouseDown()
    {
        if (gameController.debugMode)
            StartCoroutine(Plant_growth_animation());
    }

    public void Plant_growth()
    {
        if (!enable_growth)
            return;
        StartCoroutine(Plant_growth_animation());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Plant_growth_animation()
    {
        isRunning = true;
        while (true)
        {
            small_plant.transform.localScale = Vector3.Lerp(small_plant.transform.localScale, big_plant.transform.localScale, Time.deltaTime * 0.2f);
            small_plant.transform.position = Vector3.Lerp(small_plant.transform.position, big_plant.transform.position, Time.deltaTime * 0.2f);
            yield return null;
            if (Vector3.Distance(small_plant.transform.localScale, big_plant.transform.localScale) < 0.1f &&
                Vector3.Distance(small_plant.transform.position, big_plant.transform.position) < 0.1f)
                break;
        }
        isRunning = false;
        finial_plant.SetActive(true);
        Destroy(small_plant.gameObject);
        Destroy(big_plant.gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("waterMagic")&&!isRunning) {
            Plant_growth();
            
        }
    }
}