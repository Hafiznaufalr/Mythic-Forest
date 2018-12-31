using UnityEngine;
using UnityEngine.SceneManagement;
public class HalamanManager : MonoBehaviour
{
  public bool isEscapeToExit;
  // Use this for initialization
  void Start ()
  {
  }
  // Update is called once per frame
  void Update ()
  {

  
  }
  public void MulaiPermainan ()
  {
    SceneManager.LoadScene ("Level1");
  }
  public void KembaliKeMenu ()
  {
    SceneManager.LoadScene ("Menu");
  }
   public void Info ()
  {
    SceneManager.LoadScene ("Info");
  }
   public void Exit ()
  {
   Application.Quit ();
  }
}