using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.UI; using TMPro;    public class GameManager : MonoBehaviour {     public bool Lock1;     public bool Lock2;      private int count1;     private int count2;

    public TextMeshProUGUI scoreTeam1;     public TextMeshProUGUI scoreTeam2;     public TextMeshProUGUI quiz;      private enum States     {         begin, vraag_1, antwoord_1, vraag_2, antwoord_2, vraag_3, antwoord_3, vraag_4, antwoord_4, vraag_5, antwoord_5,         vraag_6, antwoord_6, vraag_7, antwoord_7, vraag_8, antwoord_8, vraag_9, antwoord_9, vraag_10, antwoord_10,         vraag_11, antwoord_11, vraag_12, antwoord_12, vraag_13, antwoord_13, vraag_14, antwoord_14, vraag_15, antwoord_15,         vraag_16, antwoord_16, vraag_17, antwoord_17, vraag_18, antwoord_18, vraag_19, antwoord_19, vraag_20, antwoord_20,         EindeRonde_1, EindeRonde_2, EindeRonde_3, StandRonde_1, VoorStandRonde_1, StandRonde_2, VoorStandRonde_2, StandRonde_3, VoorStandRonde_3, Eind,         vraag_1_antwoorden, vraag_2_antwoorden, vraag_3_antwoorden, vraag_4_antwoorden, vraag_5_antwoorden,         vraag_6_antwoorden, vraag_7_antwoorden, vraag_8_antwoorden, vraag_9_antwoorden, vraag_10_antwoorden,         vraag_11_antwoorden, vraag_12_antwoorden, vraag_13_antwoorden, vraag_14_antwoorden, vraag_15_antwoorden,         vraag_16_antwoorden, vraag_17_antwoorden, vraag_18_antwoorden, vraag_19_antwoorden, vraag_20_antwoorden, BonusVraag_1, VoorBonusVraag_1, Eind_Bonus, antwoord_bonus, StandEind, VoorStandEind     };      private States myState;      void Start()     {         count1 = 0;         count2 = 0;         scoreTeam1.text = "Team 1: " + count1.ToString();         scoreTeam2.text = "Team 2: " + count2.ToString();         myState = States.begin;          Lock1 = true;         Lock2 = true;          currentTime1 = Startingtime1;         currentTime2 = Startingtime2;     }      bool antwoord = false;     public int vraag = 0;      public float currentTime1 = 0;     public float Startingtime1 = 1;     bool timerActive1 = false;       public float currentTime2 = 0;     public float Startingtime2 = 1;     bool timerActive2 = false;       void Update()     {         if (myState == States.begin) { State_begin(); }         else if (myState == States.vraag_1) { State_vraag_1(); }         else if (myState == States.vraag_2) { State_vraag_2(); }
        else if (myState == States.vraag_3) { State_vraag_3(); }
        else if (myState == States.vraag_4) { State_vraag_4(); }
        else if (myState == States.vraag_5) { State_vraag_5(); }
        else if (myState == States.vraag_6) { State_vraag_6(); }
        else if (myState == States.vraag_7) { State_vraag_7(); }
        else if (myState == States.vraag_8) { State_vraag_8(); }
        else if (myState == States.vraag_9) { State_vraag_9(); }
        else if (myState == States.vraag_10) { State_vraag_10(); }
        else if (myState == States.vraag_11) { State_vraag_11(); }
        else if (myState == States.vraag_12) { State_vraag_12(); }
        else if (myState == States.vraag_13) { State_vraag_13(); }
        else if (myState == States.vraag_14) { State_vraag_14(); }
        else if (myState == States.vraag_15) { State_vraag_15(); }
        else if (myState == States.vraag_16) { State_vraag_16(); }
        else if (myState == States.vraag_17) { State_vraag_17(); }
        else if (myState == States.vraag_18) { State_vraag_18(); }
        else if (myState == States.vraag_19) { State_vraag_19(); }
        else if (myState == States.vraag_20) { State_vraag_20(); }


        else if (myState == States.vraag_1_antwoorden) { State_vraag_1_antwoorden(); }         else if (myState == States.vraag_2_antwoorden) { State_vraag_2_antwoorden(); }
        else if (myState == States.vraag_3_antwoorden) { State_vraag_3_antwoorden(); }
        else if (myState == States.vraag_4_antwoorden) { State_vraag_4_antwoorden(); }
        else if (myState == States.vraag_5_antwoorden) { State_vraag_5_antwoorden(); }
        else if (myState == States.vraag_6_antwoorden) { State_vraag_6_antwoorden(); }
        else if (myState == States.vraag_7_antwoorden) { State_vraag_7_antwoorden(); }
        else if (myState == States.vraag_8_antwoorden) { State_vraag_8_antwoorden(); }
        else if (myState == States.vraag_9_antwoorden) { State_vraag_9_antwoorden(); }
        else if (myState == States.vraag_10_antwoorden) { State_vraag_10_antwoorden(); }
        else if (myState == States.vraag_11_antwoorden) { State_vraag_11_antwoorden(); }
        else if (myState == States.vraag_12_antwoorden) { State_vraag_12_antwoorden(); }
        else if (myState == States.vraag_13_antwoorden) { State_vraag_13_antwoorden(); }
        else if (myState == States.vraag_14_antwoorden) { State_vraag_14_antwoorden(); }
        else if (myState == States.vraag_15_antwoorden) { State_vraag_15_antwoorden(); }
        else if (myState == States.vraag_16_antwoorden) { State_vraag_16_antwoorden(); }
        else if (myState == States.vraag_17_antwoorden) { State_vraag_17_antwoorden(); }
        else if (myState == States.vraag_18_antwoorden) { State_vraag_18_antwoorden(); }
        else if (myState == States.vraag_19_antwoorden) { State_vraag_19_antwoorden(); }
        else if (myState == States.vraag_20_antwoorden) { State_vraag_20_antwoorden(); }


        else if (myState == States.antwoord_1) { State_antwoord_1(); }
        else if (myState == States.antwoord_2) { State_antwoord_2(); }
        else if (myState == States.antwoord_3) { State_antwoord_3(); }
        else if (myState == States.antwoord_4) { State_antwoord_4(); }
        else if (myState == States.antwoord_5) { State_antwoord_5(); }
        else if (myState == States.antwoord_6) { State_antwoord_6(); }
        else if (myState == States.antwoord_7) { State_antwoord_7(); }
        else if (myState == States.antwoord_8) { State_antwoord_8(); }
        else if (myState == States.antwoord_9) { State_antwoord_9(); }
        else if (myState == States.antwoord_10) { State_antwoord_10(); }
        else if (myState == States.antwoord_11) { State_antwoord_11(); }
        else if (myState == States.antwoord_12) { State_antwoord_12(); }
        else if (myState == States.antwoord_13) { State_antwoord_13(); }
        else if (myState == States.antwoord_14) { State_antwoord_14(); }
        else if (myState == States.antwoord_15) { State_antwoord_15(); }
        else if (myState == States.antwoord_16) { State_antwoord_16(); }
        else if (myState == States.antwoord_17) { State_antwoord_17(); }
        else if (myState == States.antwoord_18) { State_antwoord_18(); }
        else if (myState == States.antwoord_19) { State_antwoord_19(); }
        else if (myState == States.antwoord_20) { State_antwoord_20(); }

        else if (myState == States.EindeRonde_1) { State_EindeRonde_1(); }
        else if (myState == States.VoorStandRonde_1) { State_VoorStandRonde_1(); }
        else if (myState == States.StandRonde_1) { State_StandRonde_1(); }

        else if (myState == States.EindeRonde_2) { State_EindeRonde_2(); }
        else if (myState == States.VoorStandRonde_2) { State_VoorStandRonde_2(); }
        else if (myState == States.StandRonde_2) { State_StandRonde_2(); }          else if (myState == States.EindeRonde_3) { State_EindeRonde_3(); }
        else if (myState == States.VoorStandRonde_3) { State_VoorStandRonde_3(); }
        else if (myState == States.StandRonde_3) { State_StandRonde_3(); }
        else if (myState == States.Eind) { State_Eind(); }

        else if (myState == States.VoorBonusVraag_1) { State_VoorBonusVraag_1(); }
        else if (myState == States.BonusVraag_1) { State_BonusVraag_1(); }
        else if (myState == States.Eind_Bonus) { State_Eind_Bonus(); }
        else if (myState == States.antwoord_bonus) { State_antwoord_bonus(); }
        else if (myState == States.StandEind) { State_StandEind(); }
        else if (myState == States.VoorStandEind) { State_VoorStandEind(); }

        if (timerActive1 == true)         {             currentTime1 -= 1 * Time.deltaTime;             if (currentTime1 <= 0)             {                 Lock1 = true;                 timerActive1 = false;                 currentTime1 = 1;             }         }          if (timerActive2 == true)         {             currentTime2 -= 1 * Time.deltaTime;             if (currentTime2 <= 0)             {                 Lock2 = true;                 timerActive2 = false;                 currentTime2 = 1;             }         }

        if (vraag == 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && (Lock1 == true))
            {
                ScoreTeam1();
                antwoord = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && (Lock1 == true))
            {
                Lock1 = false;
                timerActive1 = true;
                antwoord = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && (Lock1 == true))
            {
                Lock1 = false;
                timerActive1 = true;
                antwoord = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && (Lock1 == true))
            {
                Lock1 = false;
                timerActive1 = true;
                antwoord = false;
            }

            if (Input.GetKeyDown(KeyCode.Q) && (Lock2 == true))
            {
                ScoreTeam2();
                antwoord = true;
            }
            if (Input.GetKeyDown(KeyCode.W) && (Lock2 == true))
            {
                Lock2 = false;
                timerActive2 = true;
                antwoord = false;
            }
            if (Input.GetKeyDown(KeyCode.E) && (Lock2 == true))
            {
                Lock2 = false;
                timerActive2 = true;
                antwoord = false;
            }
            if (Input.GetKeyDown(KeyCode.R) && (Lock2 == true))
            {
                Lock2 = false;
                timerActive2 = true;
                antwoord = false;
            }
        }
        if (vraag == 0)
        {
            Lock1 = true;
            Lock2 = true;
            antwoord = false;
        } 


        if (vraag == 2)         {             if (Input.GetKeyDown(KeyCode.Alpha1) && (Lock1 == true))             {
                Lock1 = false;
                timerActive1 = true;
                antwoord = false;             }             if (Input.GetKeyDown(KeyCode.Alpha2) && (Lock1 == true))             {                 ScoreTeam1();                 antwoord = true;             }             if (Input.GetKeyDown(KeyCode.Alpha3) && (Lock1 == true))             {                 Lock1 = false;                 timerActive1 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.Alpha4) && (Lock1 == true))             {                 Lock1 = false;                 timerActive1 = true;                 antwoord = false;             }              if (Input.GetKeyDown(KeyCode.Q) && (Lock2 == true))             {
                Lock2 = false;                 timerActive2 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.W) && (Lock2 == true))             {                 ScoreTeam2();                 antwoord = true;             }             if (Input.GetKeyDown(KeyCode.E) && (Lock2 == true))             {                 Lock2 = false;                 timerActive2 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.R) && (Lock2 == true))             {                 Lock2 = false;                 timerActive2 = true;                 antwoord = false;             }         }           if (vraag == 3)         {             if (Input.GetKeyDown(KeyCode.Alpha1) && (Lock1 == true))             {
                Lock1 = false;                 timerActive1 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.Alpha2) && (Lock1 == true))             {                 Lock1 = false;                 timerActive1 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.Alpha3) && (Lock1 == true))             {                 ScoreTeam1();                 antwoord = true;             }             if (Input.GetKeyDown(KeyCode.Alpha4) && (Lock1 == true))             {                 Lock1 = false;                 timerActive1 = true;                 antwoord = false;             }              if (Input.GetKeyDown(KeyCode.Q) && (Lock2 == true))             {
                Lock2 = false;                 timerActive2 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.W) && (Lock2 == true))             {                 Lock2 = false;                 timerActive2 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.E) && (Lock2 == true))             {                 ScoreTeam2();                 antwoord = true;             }             if (Input.GetKeyDown(KeyCode.R) && (Lock2 == true))             {                 Lock2 = false;                 timerActive2 = true;                 antwoord = false;             }         }           if (vraag == 4)         {             if (Input.GetKeyDown(KeyCode.Alpha1) && (Lock1 == true))             {
                Lock1 = false;                 timerActive1 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.Alpha2) && (Lock1 == true))             {                 Lock1 = false;                 timerActive1 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.Alpha3) && (Lock1 == true))             {                 Lock1 = false;                 timerActive1 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.Alpha4) && (Lock1 == true))             {                 ScoreTeam1();                 antwoord = true;             }              if (Input.GetKeyDown(KeyCode.Q) && (Lock2 == true))             {
                Lock2 = false;                 timerActive2 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.W) && (Lock2 == true))             {                 Lock2 = false;                 timerActive2 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.E) && (Lock2 == true))             {                 Lock2 = false;                 timerActive2 = true;                 antwoord = false;             }             if (Input.GetKeyDown(KeyCode.R) && (Lock2 == true))             {                 ScoreTeam2();                 antwoord = true;             }         }  
    }               void ScoreTeam1()     {         count1 = count1 + 1;     }     void ScoreTeam2()     {         count2 = count2 + 1;     }           void State_begin()
    {
        quiz.text = "Begin van de quiz \n\nDruk op enter om de quiz te starten";
        scoreTeam1.text = " ";
        scoreTeam2.text = " ";

        if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.vraag_1;         }
    }      void State_vraag_1()     {         quiz.text = "Welke kleur is de huid van een ijsbeer?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 2;             myState = States.vraag_1_antwoorden;         }     }     void State_vraag_1_antwoorden()     {         quiz.text = "Welke kleur is de huid van een ijsbeer?\n" +         "1. Roze\t\t\t" +         "2. Zwart\n" +         "3. Wit\t\t\t" +         "4. Bruin";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_2; }         if (antwoord == true)
        {
            myState = States.vraag_2;
            vraag = 0;
        }
    }       void State_vraag_2()     {         quiz.text = "Welke vlo komt het meest voor in Nederland?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 3;             myState = States.vraag_2_antwoorden;         }     }     void State_vraag_2_antwoorden()     {         quiz.text = "Welke vlo komt het meest voor in Nederland?\n" +         "1. Hondenvlo\t\t\t" +         "2. Mensenvlo \n" +         "3. Kattenvlo\t\t\t" +         "4. Vogelvlo";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_3; }         if (antwoord == true)         {             myState = States.vraag_3;             vraag = 0;
        }     }


    void State_vraag_3()     {         quiz.text = "Welk ras is het hondenpionnetje in het spel Monopoly?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 4;             myState = States.vraag_3_antwoorden;         }     }     void State_vraag_3_antwoorden()     {         quiz.text = "Welk ras is het hondenpionnetje in het spel Monopoly?\n" +         "1. Golden Retriever\t\t\t" +         "2. Chihuahua\n" +         "3. Labrador\t\t\t" +         "4. Schotse Terriër";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_4; }         if (antwoord == true)         {             myState = States.vraag_4;             vraag = 0;
        }     }

    void State_vraag_4()     {         quiz.text = "Hoeveel paar poten heeft een kever?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 1;             myState = States.vraag_4_antwoorden;         }     }     void State_vraag_4_antwoorden()     {         quiz.text = "Hoeveel paar poten heeft een kever?\n" +         "1. 3\t\t\t" +         "2. 4\n" +         "3. 6\t\t\t" +         "4. 8";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_5; }         if (antwoord == true)         {             myState = States.vraag_5;             vraag = 0;
        }     }      void State_vraag_5()     {         quiz.text = "Welk fruit waren de gouden appels in de Griekse mythologie?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 4;             myState = States.vraag_5_antwoorden;         }     }     void State_vraag_5_antwoorden()     {         quiz.text = "Welk fruit waren de gouden appels in de Griekse mythologie?\n" +         "1. Sinaasappels\t\t\t" +         "2. Appels\n" +         "3. Abrikozen\t\t\t" +         "4. Perziken";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_6; }         if (antwoord == true)         {             myState = States.vraag_6;             vraag = 0;         }     }

    void State_vraag_6()     {         quiz.text = "Wat is het scheikundige symbool voor goud?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 1;             myState = States.vraag_6_antwoorden;         }     }     void State_vraag_6_antwoorden()     {         quiz.text = "Wat is het scheikundige symbool voor goud?\n" +         "1. Au\t\t\t" +         "2. Go\n" +         "3. As\t\t\t" +         "4. Ag";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_7; }         if (antwoord == true)         {             myState = States.vraag_7;             vraag = 0;         }     }

    void State_vraag_7()     {         quiz.text = "Welke kleur heeft licht met een golflengte van 470 nm?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 4;             myState = States.vraag_7_antwoorden;         }     }     void State_vraag_7_antwoorden()     {         quiz.text = "Welke kleur heeft licht met een golflengte van 470 nm?\n" +         "1. Rood\t\t\t" +         "2. Geel\n" +         "3. Groen\t\t\t" +         "4. Blauw";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.EindeRonde_1; }         if (antwoord == true)         {             myState = States.EindeRonde_1;             vraag = 0;         }     }
   
    void State_EindeRonde_1()     {         quiz.text = "Dit is het einde van de eerste ronde.";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.antwoord_1; }     }      void State_antwoord_1()     {         quiz.text = "Welke kleur is de huid van een ijsbeer?\n\n" + "Zwart";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_2; }     }
    void State_antwoord_2()     {         quiz.text = "Welke vlo komt het meest voor in Nederland?\n\n" + "Kattenvlo";         if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.antwoord_3;         }     }
    void State_antwoord_3()     {         quiz.text = "Welk ras is het hondenpionnetje in het spel Monopoly?\n\n" + "Schotse Terriër";         if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.antwoord_4;         }     }
    void State_antwoord_4()     {         quiz.text = "Hoeveel paar poten heeft een kever?\n\n" + "3";         if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.antwoord_5;         }     }
    void State_antwoord_5()     {         quiz.text = "Welk fruit waren de gouden appels in de Griekse mythologie?\n\n" + "Perziken";         if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.antwoord_6;         }     }
    void State_antwoord_6()     {         quiz.text = "Wat is het scheikundige symbool voor goud?\n\n" + "Au";         if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.antwoord_7;         }     }
    void State_antwoord_7()     {         quiz.text = "Welke kleur heeft licht met een golflengte van 470 nm?\n\n" + "Blauw";         if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.VoorStandRonde_1;         }     }      void State_VoorStandRonde_1()     {         quiz.text = "Dit is de tussenstand:";


        if (Input.GetKeyDown(KeyCode.Return))
        {
            myState = States.StandRonde_1;
            scoreTeam1.text = "Team 1: " + count1.ToString();
            scoreTeam2.text = "Team 2: " + count2.ToString();          }
    }
        void State_StandRonde_1()
    {
        if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.vraag_8;
            scoreTeam1.text = " ";
            scoreTeam2.text = " ";         }     }      void State_vraag_8()     {         quiz.text = "Sinds welk jaar is ijshockey een olympische sport?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 2;             myState = States.vraag_8_antwoorden;         }     }     void State_vraag_8_antwoorden()     {         quiz.text = "Sinds welk jaar is ijshockey een olympische sport?\n" +         "1. 1916\t\t\t" +         "2. 1920\n" +         "3. 1940\t\t\t" +         "4. 2000";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_9; }         if (antwoord == true)         {             myState = States.vraag_9;             vraag = 0;         }     }       void State_vraag_9()     {         quiz.text = "Bij welke sport kan men de titel Mr. Olympia halen?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 2;             myState = States.vraag_9_antwoorden;         }     }     void State_vraag_9_antwoorden()     {         quiz.text = "Bij welke sport kan men de titel Mr. Olympia halen?\n" +         "1. Atletiek\t\t\t" +         "2. Bodybuilding\n" +         "3. Schaatsen\t\t\t" +         "4. Schaatsen";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_10; }         if (antwoord == true)         {             myState = States.vraag_10;             vraag = 0;         }     }

    void State_vraag_10()     {         quiz.text = "Hoe heet het als je naar de wind toe draait bij zeilen?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 1;             myState = States.vraag_10_antwoorden;         }     }     void State_vraag_10_antwoorden()     {         quiz.text = "Hoe heet het als je naar de wind toe draait bij zeilen?\n" +         "1. Oploeven\t\t\t" +         "2. Overstag gaan\n" +         "3. Gijpen\t\t\t" +         "4. Afloeven";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_11; }         if (antwoord == true)         {             myState = States.vraag_11;             vraag = 0;         }     }

    void State_vraag_11()     {         quiz.text = "Hoe wordt een groep wielrenners ook wel genoemd?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 4;             myState = States.vraag_11_antwoorden;         }     }     void State_vraag_11_antwoorden()     {
        quiz.text = "Hoe wordt een groep wielrenners ook wel genoemd?\n" +
       "1. Een olepton\t\t\t" +
       "2. Fietsers\n" +
       "3. Een wielrennergroep\t\t\t" +
       "4. Een peleton";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_12; }         if (antwoord == true)         {             myState = States.vraag_12;             vraag = 0;         }     }      void State_vraag_12()     {         quiz.text = "Wat bedoelt men met elleboogsport?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 3;             myState = States.vraag_12_antwoorden;         }     }     void State_vraag_12_antwoorden()     {         quiz.text = "Wat bedoelt men met elleboogsport?\n" +         "1. Armpje drukken\t\t" +         "2. Duimworstelen\n" +         "3. Tooghangen\t\t\t" +         "4. Hooghangen";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_13; }         if (antwoord == true)         {             myState = States.vraag_13;             vraag = 0;         }     }

    void State_vraag_13()     {         quiz.text = "Wat is de topsnelheid van een cheeta?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 3;             myState = States.vraag_13_antwoorden;         }     }     void State_vraag_13_antwoorden()     {         quiz.text = "Wat is de topsnelheid van een cheeta?\n" +         "1. 90 km/h\t\t\t" +         "2. 100 km/h\n" +         "3. 110 km/h\t\t\t" +         "4. 120 km/h";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_14; }         if (antwoord == true)         {             myState = States.vraag_14;             vraag = 0;         }     }      void State_vraag_14()     {         quiz.text = "Wat is de meest voorkomende bloedgroep?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 4;             myState = States.vraag_14_antwoorden;         }     }     void State_vraag_14_antwoorden()     {         quiz.text = "Wat is de meest voorkomende bloedgroep?\n" +         "1. A\t\t\t" +         "2. B\n" +         "3. C\t\t\t" +         "4. O";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.EindeRonde_2; }         if (antwoord == true)         {             myState = States.EindeRonde_2;             vraag = 0;         }     }       void State_EindeRonde_2()     {         quiz.text = "Dit is het einde van de tweede ronde.";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.antwoord_8; }     }      void State_antwoord_8()     {         quiz.text = "Sinds welk jaar is ijshockey een olympische sport?\n\n" + "1920";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_9; }     }

    void State_antwoord_9()     {         quiz.text = "Bij welke sport kan men de titel Mr. Olympia halen?\n\n" + "Bodybuilding";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_10; }     }
    void State_antwoord_10()     {         quiz.text = "Hoe heet het als je naar de wind toe draait bij zeilen?\n\n" + "Oploeven";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_11; }     }
    void State_antwoord_11()     {         quiz.text = "Hoe wordt een groep wielrenners ook wel genoemd?\n\n" + "Een peleton";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_12; }     }
    void State_antwoord_12()     {         quiz.text = "Wat bedoelt men met elleboogsport?\n\n" + "Tooghangen";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_13; }     }
    void State_antwoord_13()     {         quiz.text = "Wat is de topsnelheid van een cheeta?\n\n" + "110 km/h";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_14; }     }
    void State_antwoord_14()     {         quiz.text = "Wat is de meest voorkomende bloedgroep?\n\n" + "O";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.VoorStandRonde_2; }     }      void State_VoorStandRonde_2()     {         quiz.text = "Dit is de tussenstand:";


        if (Input.GetKeyDown(KeyCode.Return))
        {
            myState = States.StandRonde_2;
            scoreTeam1.text = "Team 1: " + count1.ToString();
            scoreTeam2.text = "Team 2: " + count2.ToString();          }
    }
    void State_StandRonde_2()
    {
        if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.vraag_15;
            scoreTeam1.text = " ";
            scoreTeam2.text = " ";         }     }

    void State_vraag_15()     {         quiz.text = "Waar brandde het olympischvuur voor het eerst?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 3;             myState = States.vraag_15_antwoorden;         }     }     void State_vraag_15_antwoorden()     {         quiz.text = "Waar brandde het olympischvuur voor het eerst?\n" +         "1. Athene\t\t\t" +         "2. Londen\n" +         "3. Amsterdam\t\t\t" +         "4. Olypus";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_16; }         if (antwoord == true)         {             myState = States.vraag_16;             vraag = 0;         }     }

    void State_vraag_16()     {         quiz.text = "Welke stad wordt ook wel de sleutelstad genoemd?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 4;             myState = States.vraag_16_antwoorden;         }     }     void State_vraag_16_antwoorden()     {         quiz.text = "Welke stad wordt ook wel de sleutelstad genoemd?\n" +         "1. Amsterdam\t\t\t" +         "2. Utrecht \n" +         "3. Arnhem\t\t\t" +         "4. Leiden";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_17; }         if (antwoord == true)         {             myState = States.vraag_17;             vraag = 0;         }     }
    void State_vraag_17()     {         quiz.text = "Wat is het op een na grootste continent?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 1;             myState = States.vraag_17_antwoorden;         }     }     void State_vraag_17_antwoorden()     {         quiz.text = "Wat is het op een na grootste continent?\n" +         "1. Afrika\t\t\t" +         "2. Australië\n" +         "3. Zuid-Amerika\t\t\t" +         "4. Eurazië";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_18; }         if (antwoord == true)         {             myState = States.vraag_18;             vraag = 0;         }     }
    void State_vraag_18()     {         quiz.text = "Welke stad is oranje bij het klassieke Monopoly-spel?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 3;             myState = States.vraag_18_antwoorden;         }     }     void State_vraag_18_antwoorden()     {         quiz.text = "Welke stad is oranje bij het klassieke Monopoly-spel?\n" +         "1. Rotterdam\t\t\t" +         "2. Amsterdam\n" +         "3. Utrecht\t\t\t" +         "4. Den Haag";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_19; }         if (antwoord == true)         {             myState = States.vraag_19;             vraag = 0;         }     }
    void State_vraag_19()     {         quiz.text = "Welke kleur was Coca-Cola oorspronkelijk?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 1;             myState = States.vraag_19_antwoorden;         }     }     void State_vraag_19_antwoorden()     {         quiz.text = "Welke kleur was Coca-Cola oorspronkelijk?\n" +         "1. Groen\t\t\t" +         "2. Geel\n" +         "3. Oranje\t\t\t" +         "4. Blauw";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.vraag_20; }         if (antwoord == true)         {             myState = States.vraag_20;             vraag = 0;         }     }
    void State_vraag_20()     {         quiz.text = "Wie is de leukste docent?\n\n";         if (Input.GetKeyDown(KeyCode.Return))         {             vraag = 0;             myState = States.vraag_20_antwoorden;         }     }     void State_vraag_20_antwoorden()     {         quiz.text = "Wie is de leukste docent?\n" +         "1. Meneer Goedbloed\t\t" +         "2. Mevrouw Ouwekerk\n" +         "3. Meneer Looije\t\t" +         "4. Meneer van Oosterom";          if (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Alpha4)) ||            (Input.GetKeyDown(KeyCode.Q)) || (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.E)) || (Input.GetKeyDown(KeyCode.R)))         {
            myState = States.EindeRonde_3;             vraag = 0;
        }            if (Input.GetKeyDown(KeyCode.Return)) { myState = States.EindeRonde_3; }         if (antwoord == true)         {             myState = States.EindeRonde_3;             vraag = 0;         }     }      void State_EindeRonde_3()     {         quiz.text = "Dit is het einde van de derde ronde.";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.antwoord_15; }     }      void State_antwoord_15()     {         quiz.text = "Waar brandde het olympischvuur voor het eerst?\n\n" + "Amsterdam";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_16; }     }

    void State_antwoord_16()     {         quiz.text = "Welke stad wordt ook wel de sleutelstad genoemd?\n\n" + "Leiden";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_17; }     }
    void State_antwoord_17()     {         quiz.text = "Wat is het op een na grootste continent?\n\n" + "Afrika";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_18; }     }
    void State_antwoord_18()     {         quiz.text = "Welke stad is oranje bij het klassieke Monopoly-spel?\n\n" + "Utrecht";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_19; }     }     void State_antwoord_19()     {
        quiz.text = "Welke kleur was Coca-Cola oorspronkelijk?\n\n" + "Groen";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.antwoord_20; }     }
    void State_antwoord_20()     {         quiz.text = "Wie is de leukste docent?\n\n" + "Meneer van Oosterom\n" + "Met de groeten van Elvonc ;)";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.VoorStandRonde_3; }     }
    void State_VoorStandRonde_3()     {         quiz.text = "Dit is de eindstand:";


        if (Input.GetKeyDown(KeyCode.Return))
        {
            myState = States.StandRonde_3;
            scoreTeam1.text = "Team 1: " + count1.ToString();
            scoreTeam2.text = "Team 2: " + count2.ToString();          }
    }
    void State_StandRonde_3()
    {
        if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.Eind;
            scoreTeam1.text = " ";
            scoreTeam2.text = " ";          }          if (Input.GetKeyDown(KeyCode.Space))
        {
            myState = States.VoorBonusVraag_1;
            scoreTeam1.text = " ";
            scoreTeam2.text = " ";

        }      }


    void State_VoorBonusVraag_1()
    {
        quiz.text = "Bonusvraag: \n";
        if (Input.GetKeyDown(KeyCode.Return))
        {
            myState = States.BonusVraag_1;

        }

    }
    void State_BonusVraag_1()
    {
        quiz.text = "Bonusvraag: \n" +
           "Hoeveel centimeter is 16 inch?";
        if (Input.GetKeyDown(KeyCode.Return))
        {
            myState = States.Eind_Bonus;
        }
    }

    void State_Eind_Bonus()     {         quiz.text = "Dit was de bonusvraag.";          if (Input.GetKeyDown(KeyCode.Return)) { myState = States.antwoord_bonus; }     }

    void State_antwoord_bonus()     {         quiz.text = "Hoeveel centimeter is 16 inch?\n\n" + "40,64 centimeter";         if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.VoorStandEind;         }     }

    void State_VoorStandEind()     {         quiz.text = "Dit is de eindstand:";


        if (Input.GetKeyDown(KeyCode.Return))
        {
            myState = States.StandEind;
            scoreTeam1.text = "Team 1: " + count1.ToString();
            scoreTeam2.text = "Team 2: " + count2.ToString();          }
    }

    void State_StandEind()
    {
        if (Input.GetKeyDown(KeyCode.Return))         {             myState = States.Eind;
            scoreTeam1.text = " ";
            scoreTeam2.text = " ";          }
    }

    void State_Eind()     {         quiz.text = "Dit is het einde van de Kwikkest Kwis.\n\n" +             "Druk op enter om opnieuw te beginnen";         if (Input.GetKeyDown(KeyCode.Return))         { myState = States.vraag_1;}     } }