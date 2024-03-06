using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SeansElement : MonoBehaviour
    {
        [SerializeField] private GameObject Player;
        [SerializeField] private GameObject Name;
        [SerializeField] private GameObject Date;
        [SerializeField] private GameObject Size;
        [SerializeField] private GameObject Time;

        public void SetInfo(Seans seans)
        {
            Player.GetComponent<Text>().text = seans.UserName.ToString();
            Name.GetComponent<Text>().text = seans.Name;
            Date.GetComponent<Text>().text = seans.GetDate();
            Size.GetComponent<Text>().text = $"{seans.Size}X{seans.Size}";
            float minutes = Mathf.FloorToInt(seans.PlayTime / 60);
            float seconds = Mathf.FloorToInt(seans.PlayTime % 60);
            Time.GetComponent<Text>().text = $"{minutes:00} : {seconds:00}";


        }
    }
}