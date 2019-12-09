using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///<\summary>
public class FindingAI : MonoBehaviour
{
    class PathPoint
    {
        Vector3 pos;
        PathPoint last;
        public PathPoint()
        {
            last = null;
        }
        public PathPoint(Vector3 pos)
        {
            this.pos = pos;
            last = null;
        }
        public void SetLastPoint(PathPoint l)
        {
            last = l;
        }
        public PathPoint LastPoint()
        {
            return last;
        }
        public Vector3 GetPos()
        {
            return pos;
        }

    };

    GameObject player;
    private void Start()
    {
        dir = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        FindPlayer();
    }

    private Stack<PathPoint> path;
    private Queue<PathPoint> find;
    public float precision;
    private Vector3[] dirs = { Vector3.up, Vector3.right, Vector3.down, Vector3.left };


    void FindPlayer()
    {
        if (precision <= 0)
            precision = 1;
        find = new Queue<PathPoint>();
        find.Enqueue(new PathPoint(transform.position));
        PathPoint pp = find.Peek();
        Debug.Log(Vector2.Distance(player.transform.position, pp.GetPos()));
        while (Vector2.Distance(player.transform.position, pp.GetPos()) > precision&& Vector2.Distance(player.transform.position, pp.GetPos()) <= 11f*precision)
        {
            pp = find.Peek();
            if (Vector2.Distance(player.transform.position, pp.GetPos()) <= precision)
            {
                path = new Stack<PathPoint>();
                PathPoint back = pp;
                while (back.LastPoint() != null)
                {
                    path.Push(back);
                    //Debug.Log(back.LastPoint().GetPos());
                    back = back.LastPoint();
                }
                StartCoroutine(Move());
                return;
            }
            Debug.Log(find.Count);
            for (int i=0;i<4;i++)
            {
                PathPoint nextPP = new PathPoint(pp.GetPos() + dirs[i] * precision);
                //距离缩短
                if (Vector2.Distance(player.transform.position, pp.GetPos())> Vector2.Distance(player.transform.position, nextPP.GetPos()))
                {
                    //无障碍物
                    if (true)
                    {
                        find.Enqueue(nextPP);
                        nextPP.SetLastPoint(pp);
                    }
                    //有障碍物
                    else
                    {
                        continue;
                    }
                }
            }
            if (find.Peek()!=null)
            {
                find.Dequeue();
            }
        }
    }

    IEnumerator Move()
    {
        while(path.Count>0)
        {
            Vector3 pos = path.Peek().GetPos();

            dir = pos;
            yield return new WaitForSeconds(precision/speed);
            path.Pop();
        }
        dir = transform.position;
    }

    private float speed=3f;
    private Vector3 dir;

    private void Update()
    {
        if(dir!=transform.position)
        transform.position = Vector3.MoveTowards(transform.position,dir,speed*Time.deltaTime);
    }
    

}
