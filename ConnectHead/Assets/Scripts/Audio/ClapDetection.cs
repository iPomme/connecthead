using System.Linq;
using Onorno.Log;
using UnityEngine;

namespace Audio
{
    public class ClapDetection : MonoBehaviourWithLogger
    {
        
        [SerializeField] private AudioSource audioSource;
        [SerializeField]  private float minimumLevel = .0001f;
        float[] clipSampleData = new float[1024];

        private string _device;
        private void Start()
        {
            if (_device == null) _device = Microphone.devices[0];
            audioSource.clip = Microphone.Start(_device, true, 60, 16000);
            while (!(Microphone.GetPosition(null) > 0))
            {
            }

            audioSource.Play();
        }

        private void Update()
        {
            audioSource.GetSpectrumData(clipSampleData, 0, FFTWindow.Rectangular);
            float calculatedValue = clipSampleData.Max();

            if (calculatedValue > minimumLevel)
            {
                Logger.DebugFormat("BANG!!!");
            }
            
        }
    }
}