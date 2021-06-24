using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Casino
{
    class Setting
    {
        private bool play_music = true;

        Plugin.SimpleAudioPlayer.ISimpleAudioPlayer sound_player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();


        //This will play sound
        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Bingo_Casino.Assets." + filename);
            return stream;
        }

        public async void sound(string fileName)
        {
            var mute = play_music;
            if (mute)
            {
                Stream stream;

                stream = GetStreamFromFile(fileName);

                sound_player.Load(stream);

                sound_player.Play();

                await Task.Delay((int)stream.Length);

                stream.Close();
                stream.Dispose();
            }

            //System.Threading.Thread.Sleep(2000);

        }


        public void mute(bool mute)
        {
            if (mute == true)
            {
                sound_player.Volume = 0;
                play_music = false;

            }
            else
            {
                sound_player.Volume = 100;
                play_music = true;
            }
        }




    }
}
