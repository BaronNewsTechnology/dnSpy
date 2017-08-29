﻿/*
    Copyright (C) 2014-2017 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using dnSpy.Contracts.Debugger;
using dnSpy.Contracts.Debugger.DotNet;
using dnSpy.Debugger.DotNet.Metadata;

namespace dnSpy.Debugger.DotNet.CorDebug.Impl {
	sealed class DbgCorDebugInternalAppDomainImpl : DbgDotNetInternalAppDomain {
		public override DmdAppDomain ReflectionAppDomain => AppDomainController.AppDomain;
		public override DbgAppDomain AppDomain => appDomain ?? throw new InvalidOperationException();
		DbgAppDomain appDomain;
		internal DmdAppDomainController AppDomainController { get; }
		public DbgCorDebugInternalAppDomainImpl(DmdAppDomainController appDomainController) =>
			AppDomainController = appDomainController ?? throw new ArgumentNullException(nameof(appDomainController));
		internal void SetAppDomain(DbgAppDomain appDomain) {
			this.appDomain = appDomain ?? throw new ArgumentNullException(nameof(appDomain));
			AppDomainController.AppDomain.GetOrCreateData(() => appDomain);
		}
		protected override void CloseCore() { }
	}
}
