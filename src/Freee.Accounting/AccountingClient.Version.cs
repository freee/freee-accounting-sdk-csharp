// Copyright (c) freee K.K. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license
// information.

namespace Freee.Accounting
{
    using System.Reflection;

    public partial class AccountingClient
    {
        partial void CustomInitialize()
        {
            HttpClient.DefaultRequestHeaders.Add("X-Freee-Client-CSharp", typeof(AccountingClient).Assembly
                                                                                                  ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                                                                                  ?.InformationalVersion);
        }
    }
}
