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

using Steeltoe.Management.Census.Common;
using System;

namespace Steeltoe.Management.Census.Internal
{
    [Obsolete("Use OpenCensus project packages")]
    internal class TimestampConverter : ITimestampConverter
    {
        private readonly ITimestamp timestamp;
        private readonly long nanoTime;

        // Returns a WallTimeConverter initialized to now.
        public static ITimestampConverter Now(IClock clock)
        {
            return new TimestampConverter(clock.Now, clock.NowNanos);
        }

        public ITimestamp ConvertNanoTime(long nanoTime)
        {
            return timestamp.AddNanos(nanoTime - this.nanoTime);
        }

        private TimestampConverter(ITimestamp timestamp, long nanoTime)
        {
            this.timestamp = timestamp;
            this.nanoTime = nanoTime;
        }
    }
}
