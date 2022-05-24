using UnityEngine;

public class MusicManager : MonoBehaviour
{
   [SerializeField]private AudioSource[] sounds;

   private void Awake()
   {
      DontDestroyOnLoad(this.gameObject);
   }
   public  void PlayMenuMusic()
   {
      OpenAnySound("Map1");
   }
   public  void PlayMap1Music()
   {
      OpenAnySound("Witch");
   }
   public  void PlayWitchMusic()
   {
      OpenAnySound("Menu");
   }
   public  void PlayBattleMusic()
   {
      OpenAnySound("Battle");
   }
   public  void PlayPriestMusic()
   {
      OpenAnySound("Priest");
   }
   
   private void OpenAnySound(string name)
   {
      if (name.Equals("StopAll"))
      {
         foreach (var audio in FindObjectsOfType<AudioSource>()) audio.Stop();
         return;
      }
      
      foreach (var sound in sounds)
      {
         if (name.Equals(sound.clip.name)) sound.Play();
         else sound.Stop();
      }
   }
}
