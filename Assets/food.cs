using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{

    // Use this for initialization
    public bool  judge1=false;
    public bool judge2=false;
    private GameObject g;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 创建食物
    /// </summary>
    /// <returns></returns>
    public GameObject CreateFood()
    {
        float x = Random.Range(-4.5f, 4.5f);
        float z = Random.Range(-4.5f, 4.5f);
        
        g = Instantiate(transform.gameObject, new Vector3(x, 1f, z), Quaternion.identity) as GameObject;
        return g;
    }
    /// <summary>
    /// 创建食物
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public GameObject CreateFood(GameObject gameObject)
    {
        float x = Random.Range(-4.5f, 4.5f);
        float z = Random.Range(-4.5f, 4.5f);
        if (judge1 && judge2)
        {

        }
        else if (!judge1 && !judge2)
        {
        }
        else
        {
            g = Instantiate(transform.gameObject, new Vector3(x, 1f, z), Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
        judge1 = false;
        judge2 = false;
        return g;
    }
    //销毁食物
    public void Destroy()
    {
        Destroy(transform.gameObject);
    }
}
