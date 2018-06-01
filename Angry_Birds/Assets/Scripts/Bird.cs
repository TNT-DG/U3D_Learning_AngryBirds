using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private bool isClick;
    
    public float maxDis = 1.5f;
    private SpringJoint2D sp;
    private Rigidbody2D rg;

    //获取引用
    public LineRenderer right;
    public Transform rightPos;
    public LineRenderer left;
    public Transform leftPos;


    private void Awake()
    {
        sp = gameObject.GetComponent<SpringJoint2D>();
        rg = gameObject.GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// 鼠标按下
    /// </summary>
    private void OnMouseDown()
    {
        isClick = true;
        rg.isKinematic = true;
    }

    /// <summary>
    /// 鼠标弹起
    /// </summary>
    private void OnMouseUp()
    {
        isClick = false;
        rg.isKinematic = false;
        Invoke("Fly", 0.1f);
    }

    private void Update()
    {
        //小鸟位置跟随
        if (isClick)
        {
            //获得游戏视图中鼠标点击位置的坐标，并将之转换为世界坐标系坐标
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.position += new Vector3(0, 0, 10);
            //坐标Z轴归零
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);
            //如果拉伸长度过大
            if (Vector3.Distance(rightPos.position, transform.position) > maxDis)
            {
                //向量归一化，并乘以最大长度maxDis,得到最大长度的拉伸向量
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos *= maxDis;
                transform.position = pos + rightPos.position; 
            }

            Line();
        }
    }

    void Fly()
    {
        sp.enabled = false;
    }


    /// <summary>
    /// 画线
    /// </summary>
    void Line()
    {
        right.SetPosition(0, rightPos.position);
        right.SetPosition(1, transform.position);

        left.SetPosition(0, leftPos.position);
        left.SetPosition(1, transform.position);
    }

}
