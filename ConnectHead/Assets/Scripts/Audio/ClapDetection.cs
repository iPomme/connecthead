using System.Linq;
using Onorno.Log;
using UnityEngine;

namespace Audio
{
    public class ClapDetection : MonoBehaviourWithLogger
    {
        
        [SerializeField] private AudioSource audioSource;
        [SerializeField]  private float minimumLevel = .0001f;
        float[] clipSampleData = new float[4096];

        [SerializeField] private float maxValue;
        [SerializeField] private float averageValue;

        private string _device;
        private void Start()
        {
            if (_device == null) _device = Microphone.devices[0];
            audioSource.clip = Microphone.Start(_device, true, 3000, 16000);
            while (!(Microphone.GetPosition(_device) > 0))
            {
            }

            audioSource.Play();
        }

        private void Update()
        {
            audioSource.GetSpectrumData(clipSampleData, 0, FFTWindow.Rectangular);

            maxValue = clipSampleData.Max();
            averageValue = clipSampleData.Average();
            var diff = maxValue - averageValue;
            Logger.DebugFormat("diff = {0} ", diff);

            if (diff > minimumLevel)
            {
                Logger.DebugFormat("BANG!!!");

            }

        }
    }
}