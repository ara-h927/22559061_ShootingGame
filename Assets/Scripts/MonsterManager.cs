using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    public GameObject prefabsMonster;

    float nowTIme;
    float minTime = 1f;
    float maxTime = 5f;

    public float createTime = 1f;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        nowTIme = nowTIme + Time.deltaTime;

        if (nowTIme >createTime)
        {
            GameObject monster = Instantiate(prefabsMonster);
            monster.transform.position = transform.position;
           
            nowTIme = 0;
        }
       
    }
}
