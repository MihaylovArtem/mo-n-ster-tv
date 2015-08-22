using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static int Audience = 0;
    public static int Money = 1000;
    public static int DayCount = 1;
    public static int NewsInDayCount = 0;

    public const int MaxNewsInDay = 3;

    public  struct Interest
    {
        public static int Science = 100;
        public static int Social = 100;
        public static int Fun = 100;
        public static int Sport = 100;
        public static int Criminal = 100;
    }


	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
    void CheckCategory(ArrayList allNews, ArrayList curNews)
    {
        if (allNews.Count < 3)
        {
            News.AddNewsToCur(allNews, curNews);
        }
    }
	void Update () 
    {
	    if (NewsInDayCount == MaxNewsInDay)
	    {
	        DayCount++;
	        NewsInDayCount = 0;
	        CheckCategory(News.AllNewsCopy.Sport, News.CurNews.Sport);
            CheckCategory(News.AllNewsCopy.Science, News.CurNews.Science);
            CheckCategory(News.AllNewsCopy.Fun, News.CurNews.Fun);
            CheckCategory(News.AllNewsCopy.Social, News.CurNews.Social);
            CheckCategory(News.AllNewsCopy.Politics, News.CurNews.Politics);
            CheckCategory(News.AllNewsCopy.Criminal, News.CurNews.Criminal);
	    }
	    else
	    {
	        //выбор новости
	        NewsInDayCount++;
	    }
	}
}
