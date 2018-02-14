
using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour,Isnakehead
{

    // Use this for initialization
    public GameObject message;
    public  GameObject gb;  //食物预设体
    private Vector3 _b;
    public static GameObject g;
    public GameObject body;  //身体预设体
    public float speed = 5f;  //蛇的移动速度
    private float _timer = 0f;
    private Vector3 direction = Vector3.forward;

    public bool isover = false;
    private GameObject firstBody;  //第一节身体
    private GameObject lastBody;  //最后一节身体
    private GameObject next;
    // Use this for initialization
    void Start()
    {
        g=gb.GetComponent<food>().CreateFood();
       
    }

    // Update is called once per frame
    void Update()
    {
        AiBehavior();
        // Turn();
        Move();

    }
    /// <summary>
    /// 移动
    /// </summary>
    public void Move()
    {

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
    /// <summary>
    /// 电脑思考
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="g"></param>
    /// <returns></returns>
    private Vector3 computerturn(Vector3 direction, GameObject g)
    {
        var xfood = g.transform.position.x;
        var zfood = g.transform.position.z;
        if (transform.position.x - xfood <= 0.5&& transform.position.x - xfood>=-0.5)
        {
            if (transform.position.z - zfood > 0.9)
            {
                direction = Vector3.back;
            }
            else if (transform.position.z - zfood <= 0.9&& transform.position.z - zfood >= -0.9)
            {
                computerturn(direction, g);
            }
            else
            {
                direction = Vector3.forward;
            }
        }
        else if (transform.position.x - xfood > 0.5)
        {
            direction = Vector3.left;
        }
        else 
        {
            direction = Vector3.right;
        }
        return direction;
    }
    /// <summary>
    /// 电脑确定路线
    /// </summary>
    /// <param name="g"></param>
    /// <returns></returns>
    private Vector3 Calulcate(GameObject g)
    {
        Vector3 direction = Vector3.forward;
      
       //  Debug.Log("X为:"+(this.transform.position.x).ToString());
       // Debug.Log("Z为:"+(this.transform.position.z).ToString());
        // Debug.Log(direction);
        
       
       
        
        return computerturn(direction, g);
    }
    /// <summary>
    /// 电脑行为
    /// </summary>
    private void AiBehavior()
    {
       
        if(g!=null)
        {
            Turn(Calulcate(g));
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
    /// <param name="_direction"></param>
    /// <returns></returns>
    private Vector3 Turn(Vector3 _direction)
    {


        direction = _direction;


        return direction;
    }
    /// <summary>
    /// 创建身体
    /// </summary>
    public void CreateBody()
    {

        GameObject _body = Instantiate(body, new Vector3(1000f, 1000f, 1000f), Quaternion.identity) as GameObject;
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
    /// 触碰事件
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToString() == "bound")
        {
            isover = true;
        }
        if (other.tag.ToString() == "boundplayer")
        {
            isover = true;
        }
        if (other.tag.ToString() == "food")
        {
            gb.GetComponent<food>().judge2 = true;
            //Destroy(other.gameObject);
            CreateBody();
            g=gb.GetComponent<food>().CreateFood(other.gameObject);
        }
    }

    public Vector3 Turn()
    {
        throw new System.NotImplementedException();
    }
}
