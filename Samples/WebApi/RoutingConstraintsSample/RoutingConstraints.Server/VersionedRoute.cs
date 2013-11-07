﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Web.Http.Routing;

namespace RoutingConstraints.Server
{
    /// <summary>
    /// Provides an attribute route that's restricted to a specific version of the api.
    /// </summary>
    internal class VersionedRoute : RouteProviderAttribute
    {
        public VersionedRoute(string template, int allowedVersion)
            : base(template)
        {
            AllowedVersion = allowedVersion;
        }

        public int AllowedVersion
        {
            get;
            private set;
        }

        public override HttpRouteValueDictionary Constraints
        {
            get
            {
                var constraints = new HttpRouteValueDictionary();
                constraints.Add("version", new VersionConstraint(AllowedVersion));
                return constraints;
            }
        }
    }
}
