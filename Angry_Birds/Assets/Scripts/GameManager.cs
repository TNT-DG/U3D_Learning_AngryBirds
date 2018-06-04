using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<Bird> birds;
    public List<Pig> pigs;
    public static GameManager _instance;
    private Vector3 newPos;

    private void Awake()
    {
        _instance = this;
        if (birds.Count > 0)
        {
            newPos = birds[0].transform.position;
        }
    }

    private void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[0].gameObject.transform.position = newPos;
                birds[0].enabled = true;
                birds[0].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }

    /// <summary>
    /// 判断游戏逻辑
    /// </summary>
    public void NextBird()
    {
        if (pigs.Count > 0)
        {
            if (birds.Count > 0)
            {
                //下一只飞
                Initialized();
            }
            else
            {
                //输了
            }
        }
        else
        {
            //赢了
        }
    }

}
