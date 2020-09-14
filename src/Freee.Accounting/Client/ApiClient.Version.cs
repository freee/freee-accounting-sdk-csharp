// Copyright (c) freee K.K. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license
// information.

using System.Reflection;

using RestSharp;

namespace Freee.Accounting.Client
{
    public partial class ApiClient
    {
        partial void InterceptRequest(IRestRequest request)
        {
            request.AddHeader("X-Api-Version", "2020-06-15");
            request.AddHeader("X-Freee-Client-CSharp", typeof(ApiClient).Assembly
                                                                         ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                                                         ?.InformationalVersion);
        }
    }
}
