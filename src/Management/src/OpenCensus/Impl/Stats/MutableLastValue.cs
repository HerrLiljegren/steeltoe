﻿// Copyright 2017 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

namespace Steeltoe.Management.Census.Stats
{
    [Obsolete("Use OpenCensus project packages")]
    internal sealed class MutableLastValue : MutableAggregation
    {
        internal double LastValue = double.NaN;

        // TODO(songya): remove this once interval stats is completely removed.
        internal bool Initialized = false;

        internal MutableLastValue()
        {
        }

        internal static MutableLastValue Create()
        {
            return new MutableLastValue();
        }

        internal override void Add(double value)
        {
            LastValue = value;

            // TODO(songya): remove this once interval stats is completely removed.
            if (!Initialized)
            {
                Initialized = true;
            }
        }

        internal override void Combine(MutableAggregation other, double fraction)
        {
            MutableLastValue mutable = other as MutableLastValue;
            if (mutable == null)
            {
                throw new ArgumentException("MutableLastValue expected.");
            }

            MutableLastValue otherValue = (MutableLastValue)other;

            // Assume other is always newer than this, because we combined interval buckets in time order.
            // If there's a newer value, overwrite current value.
            this.LastValue = otherValue.Initialized ? otherValue.LastValue : this.LastValue;
        }

        internal override T Match<T>(Func<MutableSum, T> p0, Func<MutableCount, T> p1, Func<MutableMean, T> p2, Func<MutableDistribution, T> p3, Func<MutableLastValue, T> p4)
        {
            return p4.Invoke(this);
        }
    }
}
