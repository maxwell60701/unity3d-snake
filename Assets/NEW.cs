using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEW : MonoBehaviour,Isnakehead
{

    // Use this for initialization
    public GameObject message;
    public GameObject gb;//食物预设体
    private Vector3 _b;
    
    public GameObject body; //蛇身体预设体
    public float speed = 5f;//速度
    private float _timer = 0f;
    private Vector3 direction = Vector3.forward;

    public bool isover = false;
    private GameObject firstBody; //第一节身体
    private GameObject lastBody;  //最后一节身体
    private GameObject next;
    // Use this for initialization
    void Start()
    {
        //gb.GetComponent<food>().CreateFood();
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Move();

    }
    /// <summary>
    /// 移动
    /// </summary>
    public void Move()
    {
        Debug.Log(1);
        if (!isover)
        {


            _timer += Time.deltaTime;
           
            if (_timer >= (1f / speed))
            {
                Vector3 old = transform.position;
                transform.Translate(direction);
                
                if (firstBody != null)
                {

                    //   firstBody.transform.position = old;  
                    firstBody.GetComponent<body>().moveTo(old);
                }
                _timer = 0f;

            }

        }
        else
        {


        }


    }

    //private void CreateFood()
    //{
    //    float x = Random.Range(-5f, 5f);
    //    float z = Random.Range(-5f, 5f);
    //    GameObject g = Instantiate(gb, new Vector3(x, 1f, z), Quaternion.identity) as GameObject;
    //}
    /// <summary>
    /// 转弯
    /// </summary>
    /// <returns></returns>
    public Vector3 Turn()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //transform.Translate(Vector3.forward);
            if (direction != Vector3.back)
            {
                direction = Vector3.forward;
            }
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // transform.Translate(Vector3.back);
            if (direction != Vector3.forward)
            {
                direction = Vector3.back;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.Translate(Vector3.left);
            if (direction != Vector3.right)
            {
                direction = Vector3.left;
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // transform.Translate(Vector3.right);
            if (direction != Vector3.left)
            {
                direction = Vector3.right;
            }
        }
        return direction;
    }
   /// <summary>
   /// 创建身体
   /// </summary>
    public void CreateBody()
    {

       GameObject  _body = Instantiate(body, new Vector3(1000f,1000f,1000f), Quaternion.identity) as GameObject;
        if (lastBody != null)
        {
            lastBody.GetComponent<body>().next = _body;
        }
        if (firstBody == null)
        {

            firstBody = _body;
            //  print("firstBody==null");
        }
        lastBody = _body;

    }
    /// <summary>
    ///  触碰事件
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToString() == "bound")
        {
            isover = true;
        }
        if (other.tag.ToString() == "boundai")
        {
            isover = true;
        }
        if (other.tag.ToString() == "food")
        {
            gb.GetComponent<food>().judge1 = true;
           // Destroy(other.gameObject);
            CreateBody();
            ComputerScript.g=gb.GetComponent<food>().CreateFood(other.gameObject);
        }
    }
}
