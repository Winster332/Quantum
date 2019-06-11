using System.Threading;
using NAudio.Wave;

namespace Quantum.Platform.Audio
{
  public class WindowsSoundPlayer : ISoundPlayer
  {
    public WindowsSoundPlayer()
    {
    }

    public void Play(string audioFilePath)
    {
      using(var audioFile = new AudioFileReader(audioFilePath))
      using(var outputDevice = new WaveOutEvent())
      {
        outputDevice.Init(audioFile);
        outputDevice.Play();
        while (outputDevice.PlaybackState == PlaybackState.Playing)
        {
          Thread.Sleep(1000);
        }
      }
    }
  }
}