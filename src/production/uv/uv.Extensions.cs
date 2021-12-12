// Copyright (c) Bottlenose Labs Inc. (https://github.com/bottlenoselabs). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System.Diagnostics.CodeAnalysis;
using C2CS;
using JetBrains.Annotations;

// ReSharper disable once InconsistentNaming
// ReSharper disable once CheckNamespace

[SuppressMessage(
    "StyleCop.CSharp.NamingRules",
    "SA1300",
    MessageId = "Element should begin with upper-case letter",
    Justification = "'uv' is the name of the product.")]
[PublicAPI]
public static unsafe partial class uv
{
    public static void CheckErrorCode(string functionName, int errorCode)
    {
        var status = errorCode >= 0 ? "success" : "failure";

        if (errorCode == 0)
        {
            Console.WriteLine($"{functionName}: {status}");
        }
        else
        {
            var name = GetErrorCodeName(errorCode);
            var description = GetErrorCodeDescription(errorCode);
            Console.WriteLine($"{functionName}: {status} {name} {description}");
        }
    }

    public static string GetErrorCodeName(int errorCode)
    {
        var cString = uv_err_name(errorCode);
        var result = Runtime.String(cString);
        return result;
    }

    public static string GetErrorCodeDescription(int errorCode)
    {
        var buffer = stackalloc byte[512];
        var cString = uv_strerror_r(errorCode, buffer, 512);
        var result = Runtime.String(cString);
        return result;
    }
}
