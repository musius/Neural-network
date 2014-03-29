﻿using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NeuralNetwork
{
    public class SenseNode : Node
    {
        /// <summary>
        ///     Sense node, no connections
        /// </summary>
        public SenseNode() : base(net => net)
        {
        }

        public override double CalculateOutput()
        {
            return Output;
        }

        public void SetState(double state)
        {
            base.Output = state;
        }
    }
}