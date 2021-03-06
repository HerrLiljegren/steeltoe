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

namespace Steeltoe.Management.Census.Utils
{
    internal static class DoubleUtil
    {
        [Obsolete("Use OpenCensus project packages")]
        public static long ToInt64(double arg)
        {
            if (double.IsPositiveInfinity(arg))
            {
                return 0x7ff0000000000000L;
            }

            if (double.IsNegativeInfinity(arg))
            {
                unchecked
                {
                    return (long)0xfff0000000000000L;
                }
            }

            if (double.IsNaN(arg))
            {
                return 0x7ff8000000000000L;
            }

            if (arg == double.MaxValue)
            {
                return long.MaxValue;
            }

            if (arg == double.MinValue)
            {
                return long.MinValue;
            }

            return Convert.ToInt64(arg);
        }
    }
}
