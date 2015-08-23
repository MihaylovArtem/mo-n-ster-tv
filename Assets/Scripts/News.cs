using System;
using System.Runtime.Remoting.Messaging;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class News : MonoBehaviour
{
    public  struct NewsList
    {
        public ArrayList Science;
        public ArrayList Sport;
        public ArrayList Social;
        public ArrayList Criminal;
        public ArrayList Fun;
        public ArrayList Politics;

        public NewsList(int i) {
            Science = new ArrayList();
            Sport = new ArrayList();
            Social = new ArrayList();
            Criminal = new ArrayList();
            Fun = new ArrayList();
            Politics = new ArrayList();
        }
    }

    public static NewsList AllNews = new NewsList(1);
    public static NewsList AllNewsCopy = new NewsList(1);
    public static NewsList CurNews = new NewsList(1);

    public struct AddingNews
    {
        public string Text;
        public string Header;
        public int ScienceChange;
        public int SportChange;
        public int CriminalChange;
        public int FunChange;
        public int SocialChange;
        public int PoliticsChange;

        public AddingNews(int i) {
            Text = "";
            Header = "";
            ScienceChange = 0;
            SportChange = 0;
            CriminalChange = 0;
            FunChange = 0;
            SocialChange = 0;
            PoliticsChange = 0;
        }
    }

    public static AddingNews clearNews = new AddingNews(1);

    public static void AddNewsToCategory(ArrayList newsType, string text, string header, int scienceChange, int sportChange, int criminalChange, int funChange, 
                            int politicsChange, int socialChange ) {
        AddingNews newsToAdd = new AddingNews();
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
		AddNewsToCategory (AllNews.Politics, "This Morning Vladimir Putin has visited summit in Nigeria. The new antiterror program was admitted.", "Vladimir Putin & Nigeria", 0, 0, 0, 0, 3, -2);
		AddNewsToCategory (AllNews.Politics, "60% percent of Americans don’t want to know anything about them. 30% are really interested. 10% have never heard about the 2016 elections.", "2016 presidential candidates", 0, 0, 0, 6, -3, -2); 
		AddNewsToCategory (AllNews.Politics, "Poroshenko: All is OK. Don’t Worry.", "Conflict in Ukraine", 0, 0, 1, 4, -3, -3); 
		AddNewsToCategory (AllNews.Politics, "S. & N. Korea trade warmongering accusations following exchange of fire.", "North Korea", 0, 0, 3, -6, 3, -2); 
		AddNewsToCategory (AllNews.Politics, "According to a new opinion poll, 41 percent of Russians consider the events of 1991 that ended in the breakup of the Soviet Union as tragic and perilous, but 34 percent hold that since then the nation chose the right path of development.", "1991 coup", 0, 0, 0, -4, 5, 1); 
		AddNewsToCategory (AllNews.Politics, "There are no sanctions now!", "Russia", 0, 0, -4, -4, 10, 10); 
		AddNewsToCategory (AllNews.Politics, "Northern Ireland minister says IRA may still be operating despite peace deal.", "Ireland", 0, 0, 1, 4, -5, 3); 
		AddNewsToCategory (AllNews.Politics, "France and Britain target traffickers in migrant policing push.", "Migrants", 0, 0, -1, 0, 7, -3); 
		AddNewsToCategory (AllNews.Politics, "During visit to Ukraine, Defence Secretary Michael Fallon announces UK will step up pace of training Ukrainian forces and add extra skills.", "Ukranian forces", 0, 2, 0, 0, 6, -3); 
		AddNewsToCategory (AllNews.Politics, "Supreme Court strikes down law in Jerusalem passport case.", "Jerusaleum", 0, 0, 2, -0, -5, 4); 

		AddNewsToCategory (AllNews.Fun, "1) Bend The Rules: Hewlett-Packard (HP) 2) Refreshingly Honest: Honest Tea 3) The Last Selfie: World Wildlife Fund (WWF)", "Social Media Campaigns", 1, -2, -3, 4, 5, 1); 
		AddNewsToCategory (AllNews.Fun, "PowerPoint won!", "Keynote Vs. PowerPoint", 0, -2, -3, 4, 0, 1); 
		AddNewsToCategory (AllNews.Fun, "J.K. Rowling announced a new book called  Harry Potter : apocalypse.", "J.K. Rowling", 0, 0, 0, 5, 0, -5); 
		AddNewsToCategory (AllNews.Fun, "Santa Barbara comes back. The «pilot» of new season of Santa Barbara was shown this Friday. 889 series left.", "Santa Barbara", -5, 0, 0, 7, 0, -2); 
		AddNewsToCategory (AllNews.Fun, "The world's highest paid actress is Jennifer Lawrence, the 25-year-old Hunger Games star, is the world's highest paid actress.", "Highest paid actress", 0, 0, 0, 2, -3, +1);
		AddNewsToCategory (AllNews.Fun, "A giant panda at a zoo in the United States has given birth to twin cubs.", "Panda", 0, 0, -3, 4, 0, 1); 
		AddNewsToCategory (AllNews.Fun, "'Oldest' message in a bottle found more than 108 years on", "'Oldest' message", 2, 0, -3, 5, 0, 3); 
		AddNewsToCategory (AllNews.Fun, "Russians prefer «Corona extra» like Dominic Toretto", "Corona", 0, 0, 3, -2, 0, -2); 
		AddNewsToCategory (AllNews.Fun, "There are too much Vodka in Russia, so it has spread all over the world.", "Vodka", 0, -3, -3, 10, 0, -1); 
		AddNewsToCategory (AllNews.Fun, "The biggest Hamburger - 1000kg, was made by thirsty Granny.", "Hamburger", 3, -2, -3, -3, -1, 3); 
		AddNewsToCategory (AllNews.Fun, "Xbox two released!", "Xbox", 0, -6, 0, 15, 0, 0);
		AddNewsToCategory (AllNews.Fun, "iPhone 7u comes this September. U - means UltraSpeed.", "iPhone 7u", 3, -2, -9, 10, 0, 1); 

		AddNewsToCategory (AllNews.Social, "Aunt Zina from Uvelka, Chelyabinsk, Russia lost her cat called Vasya.", "Aunt Zina", -6, +1, 0, 0, 0, +2); 
		AddNewsToCategory (AllNews.Social, "The military should avoid turning the conduct of warfare over to machines, because nowadays one should be focused on ending war, not extending it into a robot era, Mark Gubrud, physicist and expert on emerging technology and human security.!", "Robots replacing soldiers", 5, 0, 5, 0, 0, -8); 
		AddNewsToCategory (AllNews.Social, "Today’s geopolitical environment has made the task of creating a national payment system in Russia extremely urgent.", "Payment Cards", 0, 0, +4, -3, 0, -2); 
		AddNewsToCategory (AllNews.Social, "Man opens fire on Amsterdam to Paris train, gets overpowered by passengers ", "Fire on train", 0, 0, 3, -4, 0, -1); 
		AddNewsToCategory (AllNews.Social, "Gunman kills self at Brighton Beach federal building ", "Brighton Beach", 0, 0, 3, -4, 0, -1); 
		AddNewsToCategory (AllNews.Social, "Ten dead as typhoon hits Philippines", "Typhoon", 0, 0, 3, -3, 0, 2); 
		AddNewsToCategory (AllNews.Social, "The long-lost Nazi train full of gold which may have been found in Poland", "Gold", 0, 0, 0, 4, -5, 3); 
		AddNewsToCategory (AllNews.Social, "An explosion is reported at a chemical plant in China's eastern Shandong province", "China", 0, 0, 0, -2, -6, 8); 
		AddNewsToCategory (AllNews.Social, "Suits. Season 5 reached the highest rate at IMDB.", "Suits", -1, 0, 0, 4, 0, 3); 
		AddNewsToCategory (AllNews.Social, "Sharing childcare makes for happier couples with better sex lives, US research suggests.", "Research", 3, 0, 0, -2, 0, 5); 
		AddNewsToCategory (AllNews.Social, "Smartphone sales in China have fallen year-on-year for the first time, according to data gathered by Gartner.", "Smartphones", 0, 0, 0, -4, 0, 5);

		AddNewsToCategory (AllNews.Sport, "Messi reached the Golden Socks medal. ", "Messi", 0, 5, -6, 4, 0, -1);
		AddNewsToCategory (AllNews.Sport, "Dota 2 became a new olympic sport. ", "Dota2 News", 0, 4, 0, 4, 0, -5);
		AddNewsToCategory (AllNews.Sport, "A number of famous Kenyan distance runners are to take part in a 22-day ‘walk for peace,’ across the north of the country. The 836 km event is aimed at stopping ethnic violence in the area and hopes to raise $250,000 to support peace initiatives. ", "Star athletes", 0, 5, 0, -4, 0, 3);
		AddNewsToCategory (AllNews.Sport, "A 15-year-old powerlifting champion, Maryana Naumova from Russia, has met with 'The Terminator,' Arnold Schwarzenegger, and asked him to make peace between US and Russia. He promised to work on it, she said.", "World's 'strongest' girl", 0, 0, 0, -3, 5, -1);
		AddNewsToCategory (AllNews.Sport, "All three medals taken by Russia in the pairs’ competition saw the country completing the 2015 European Figure Skating Championships with an impressive 9 medals, including 2 golds snatched in two medals sweeps. ", "Figure skating Euros", 0, 6, 0, 2, -7, 1);
		AddNewsToCategory (AllNews.Sport, "Barcelona won the Champions League. ", "FBC", 0, 7, 0, 2, -5, 0);
		AddNewsToCategory (AllNews.Sport, "Cristiano Ronaldo due to the 'TOP SPORTSMEN 2015 RATING' is the fastest football player in the worldl. ", "Ronaldo", 0, 3, 0, -3, 0, 4);
		AddNewsToCategory (AllNews.Sport, "The preparations for Olympic Games 2016 are coming to the end. ", "Olympic Games 2016", 0, 1, 0, 0, -5, 10);
		AddNewsToCategory (AllNews.Sport, "Basketball Star Quan Chi has ended his career (not proofed). ", "Basketball Star", 0, -6, 0, 0, 0, 5);
		AddNewsToCategory (AllNews.Sport, "FIFA has changed its president. ", "FIFA", 0, 3, 2, -9, 3, 1);

		AddNewsToCategory (AllNews.Criminal, "A teenager has been hailed a hero after helping a kidnapped woman escape from the clutches of her ex-boyfriend.", "Teenage hero", 0, 5, +6, 0, -10, 5);
		AddNewsToCategory (AllNews.Criminal, "Investigators are trying to determine why an armed veteran opened fire in a federal building in Manhattan, fatally shooting a security guard before killing himself. ", "Federal building shooting ", -5, 0, 8, -2, 0, -3);
		AddNewsToCategory (AllNews.Criminal, "A man convicted in the 1999 slaying of an 84-year-old woman through a unique glove and DNA match has been sentenced to life in prison. ", "Life in prison", -3, 0, +6, -3, 0, -1);
		AddNewsToCategory (AllNews.Criminal, "Barak Obama was killed by his bodyguard. ", "Obama is DEAD (not proffed)", 0, 0, -15, 0, 0, 20);
		AddNewsToCategory (AllNews.Criminal, "A Baseball star was murdered at his own house.", "Murder. Bill Strawberry ", 0, -15, 0, 10, 0, 10);
		AddNewsToCategory (AllNews.Criminal, "Dutch police make arrest over fake Van Gogh painting.", "Van Gogh)", 0, 0, 6, 0, 0, -2);

		AddNewsToCategory (AllNews.Science, "We're smarter than chickens", "Human & Chicken", 2, -1, -2, -2, -1, 10);
		AddNewsToCategory (AllNews.Science, "The July average temperature across global land and ocean surfaces was 1.46°F (0.81°C) above the 20th century average.", "Global Warming", 5, 0, 0, -2, 0, -5);
		AddNewsToCategory (AllNews.Science, "Black holes may make ideal dark matter labs", "Dark Energy", 5, 0, 0, -3, 0, 0);
		AddNewsToCategory (AllNews.Science, "Scientists invented a new car with air energy reactor!", "Cars ", 10, -10, 0, 3, -5, 10);
		AddNewsToCategory (AllNews.Science, "A new nuclear weapon in Pakistan was developed", "Weapons", 0, 0, 20, -10, 0, 0);


		AllNewsCopy = AllNews;
	}

    public static void AddNewsToCur(ArrayList allNews, ArrayList curNews) {
        if (allNews.Count > 0) {
            int i = UnityEngine.Random.Range(0, allNews.Count);
            curNews.Add(allNews[i]);
            allNews.RemoveAt(i);
        }
    }

    public static void RemoveSelectedNewsFromCur(ArrayList arrayOfNews) 
    {
        foreach (var news in arrayOfNews) {
            if (CurNews.Science.Contains(news)) CurNews.Science.Remove(news);
            if (CurNews.Sport.Contains(news)) CurNews.Sport.Remove(news);
            if (CurNews.Social.Contains(news)) CurNews.Social.Remove(news);
            if (CurNews.Criminal.Contains(news)) CurNews.Criminal.Remove(news);
            if (CurNews.Fun.Contains(news)) CurNews.Fun.Remove(news);
            if (CurNews.Politics.Contains(news)) CurNews.Politics.Remove(news);
        }
    }
}
