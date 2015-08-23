using System;
using System.Runtime.Remoting.Messaging;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class News : MonoBehaviour
{
    public struct NewsList
    {
        public ArrayList Science;
        public ArrayList Sport;
        public ArrayList Social;
        public ArrayList Criminal;
        public ArrayList Fun;
        public ArrayList Politics;
    }

    public static NewsList AllNews;
    public static NewsList AllNewsCopy;
    public static NewsList CurNews;

    private struct AddingNews
    {
        public string Text;
        public string Header;
        public int ScienceChange;
        public int SportChange;
        public int CriminalChange;
        public int FunChange;
        public int SocialChange;
        public int PoliticsChange;
    }

    private AddingNews newsToAdd;

    public void AddNewsToCategory(ArrayList newsType, string text, string header, int scienceChange, int sportChange, int criminalChange, int funChange, 
                            int politicsChange, int socialChange )
    {
        newsToAdd.Text = text;
        newsToAdd.Header = header;
        newsToAdd.CriminalChange = criminalChange;
        newsToAdd.SportChange = sportChange;
        newsToAdd.ScienceChange = scienceChange;
        newsToAdd.FunChange = funChange;
        newsToAdd.PoliticsChange = politicsChange;
        newsToAdd.SocialChange = socialChange;
        newsType.Add(newsToAdd);
    }
	// Use this for initialization
	public static void InitializeNews ()
	{
	    AllNewsCopy = AllNews;
	}

    public static void AddNewsToCur(ArrayList allNews, ArrayList curNews)
    {
        int i = UnityEngine.Random.Range(0, allNews.Count);
        curNews.Add(allNews[i]);
        allNews.Remove(i);
    }
}
