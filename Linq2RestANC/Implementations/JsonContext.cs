﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonContext.cs" company="Reimers.dk">
//   Copyright © Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the JsonContext class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Linq2Rest.Implementations
{
    using Linq2Rest.Provider;
    using System;

    /// <summary>
    /// Defines the JsonContext class.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the item returned from the service.</typeparam>
    public class JsonContext<T> : RestContext<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonContext{T}"/> class. 
        /// </summary>
        /// <param name="source">The <see cref="Uri"/> of the resource collection.</param>
        /// <param name="knownTypes"><see cref="Type"/> to be known by the serializer.</param>
        public JsonContext(Uri source, params Type[] knownTypes)
            : base(new JsonRestClient(source), new JsonDataContractSerializerFactory(knownTypes))
        {
            CustomContract.Requires<ArgumentNullException>(source != null);
            CustomContract.Requires<ArgumentNullException>(knownTypes != null);
            CustomContract.Requires<ArgumentException>(source.Scheme == HttpUtility.UriSchemeHttp || source.Scheme == HttpUtility.UriSchemeHttps);
        }
    }
}
