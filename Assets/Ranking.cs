using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Ranking : MonoBehaviour
{
    public static List<ScoreInfo> list = new List<ScoreInfo>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    int compare1(ScoreInfo a, ScoreInfo b)
    {
        return a.score < b.score ? -1 : 1;
    }
    public static void SortList()
    {
        List<ScoreInfo> slist = list.OrderByDescending(s => s.score).ToList();
        list = slist;
    }
}
