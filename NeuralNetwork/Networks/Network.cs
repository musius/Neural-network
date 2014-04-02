using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Networks.Layers;

namespace NeuralNetwork.Networks
{
    public class Network
    {
        private Layer _endLayer;
        private List<Layer> _layers = new List<Layer>();
        private SenseLayer _senseLayer;

        protected Network()
        {
        }

        public Network(SenseLayer senseLayer, params Layer[] layers)
        {
            _senseLayer = senseLayer;
            _layers = layers.Take(layers.Length - 1).ToList();
            EndLayer = layers.Last();
        }

        protected SenseLayer SenseLayer
        {
            get { return _senseLayer; }
            set { _senseLayer = value; }
        }

        protected List<Layer> Layers
        {
            get { return _layers; }
            set { _layers = value; }
        }

        protected Layer EndLayer
        {
            get { return _endLayer; }
            set { _endLayer = value; }
        }

        public ICollection<double> Run(ICollection<double> objectFeatures)
        {
            SenseLayer.SetInput(objectFeatures);
            return EndLayer.CalculateStates();
        }

        public void BackPropagation(ICollection<double> error, double learningCoef)
        {
            EndLayer.SetDeltaForEndLayer(error);
            for (int i = Layers.Count - 1; i >= 0; i--)
            {
                Layer layer = Layers[i];
                layer.CalculateDelta();
            }

            EndLayer.ReweightRecursively(learningCoef);
        }
    }
}