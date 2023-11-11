using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Proyecto_1EVA_ALB
{


    public static class SoundManager
    {
        public static MediaPlayer tutorialSoundTrack;
        public static MediaPlayer nivel1SoundTrack;
        public static MediaPlayer nivel2SoundTrack;
        public static MediaPlayer nivel3SoundTrack;
        public static MediaPlayer nivel3TalkSoundTrack;
        public static MediaPlayer topGSoundTrack;
        public static SoundPlayer grabBox;
     
     
       


        public static void loadSongs()
        {
            // Cargar las canciones
            tutorialSoundTrack = new MediaPlayer();
            tutorialSoundTrack.Open(new Uri("sounds/tutorialSoundTrack.wav", UriKind.Relative));
            nivel1SoundTrack = new MediaPlayer();
            nivel1SoundTrack.Open(new Uri("sounds/nivel1SoundTrack.wav", UriKind.Relative));
            nivel2SoundTrack = new MediaPlayer();
            nivel2SoundTrack.Open(new Uri("sounds/nivel2SoundTrack.wav", UriKind.Relative));
            nivel3SoundTrack = new MediaPlayer();
            nivel3SoundTrack.Open(new Uri("sounds/nivel3SoundTrack.wav", UriKind.Relative));
            nivel3TalkSoundTrack = new MediaPlayer();
            nivel3TalkSoundTrack.Open(new Uri("sounds/nivel3TalkSoundTrack.wav", UriKind.Relative));
            nivel3SoundTrack.Volume = 0.2f; // Bajar el volumen de la música
            topGSoundTrack = new MediaPlayer();
            topGSoundTrack.Open(new Uri("sounds/topGSoundTrack.wav", UriKind.Relative));
            

            // Cargar los sonidos
            grabBox = new SoundPlayer();
            grabBox.SoundLocation= "sounds/cogerCaja.wav";
            grabBox.Load();

           
            
           

        }

    }
}
