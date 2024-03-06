
namespace DefaultNamespace
{
    public class Getstates
    {
        //System.Random rnd = new System.Random();
        public string debug = "";
        public int[] States = {0,0};
        public int ActualParameter;
        public bool Connect = false;

        private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        public void GetState(string conData, string medData)
        {
            try                     
            {
                if (conData !="" && medData!="")
                {
                    // ВНИМАНИЕ КОСТЫЛЬ //
                    string medVal = conData.Split(',')[1].Split(':')[1];
                    // КОНЕЦ КОСТЫЛЯ //

                    // ВНИМАНИЕ КОСТЫЛЬ //
                    string conVal = medData.Split(',')[1].Split(':')[1];
                    // КОНЕЦ КОСТЫЛЯ //
                    States[0] = System.Convert.ToInt32(conVal); //Концентрация
                    //States[0] = rnd.Next(0, 100);
                    States[1] = System.Convert.ToInt32(medVal); //Медитация
                    var SG = ContrillerScript.SG;
                    ActualParameter = SG.IsMedit ? SG.Bar.States[1] : SG.Bar.States[0];
                    Connect = true;
                }
                else
                {
                    Connect = false;
                }      
            }
            catch
            {
                Connect = false;
            } 
        }
    }
}