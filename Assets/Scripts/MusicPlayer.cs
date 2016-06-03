using UnityEngine;
using System.Collections;

public class MusicPlayer: MonoBehaviour
{
      private static MusicPlayer _instance;

      public AudioClip MainClip;
      public AudioClip GameClip;
      public AudioClip EndClip;

      private AudioSource _music;

      void Start()
      {
            //If this object is referring to a game object and that game object is not
            //equals to this one destroy it.
            if ( _instance != null && _instance != this )
            {
                  Destroy( gameObject );
                  print( "Duplicate music player self-destructing!" );
            } else
            {
                  _instance = this;
                  DontDestroyOnLoad( gameObject );
                  _music = GetComponent<AudioSource>();
                  _music.clip = MainClip;
                  _music.loop = true;
                  _music.Play();
            }
      }


      //Play Music At The Given Time.
      private void OnLevelWasLoaded(int level)
      {
            Debug.Log( "Level Loaded: Music Starting: " + level );

            //Stop the current music playing
            _music.Stop();

            //Load the designated music;
            if ( level == 0 )
            {
                  _music.clip = MainClip;
            }

            if ( level == 1 )
            {
                  _music.clip = GameClip;
            }

            if ( level == 2 )
            {
                  _music.clip = EndClip;
            }

            _music.Play();
            _music.loop = true;
      }
}
