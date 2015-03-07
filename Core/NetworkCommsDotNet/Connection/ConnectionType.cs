﻿//  Copyright 2011-2013 Marc Fletcher, Matthew Dean
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
//  A commercial license of this software can also be purchased. 
//  Please see <http://www.networkcomms.net/licensing/> for details.

using System;
using System.Collections.Generic;

namespace NetworkCommsDotNet
{
    /// <summary>
    /// The type of <see cref="Connection"/>.
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>
        /// An undefined connection type. This is used as the default value.
        /// </summary>
        Undefined,

        /// <summary>
        /// A TCP connection type. Used by <see cref="TCPConnection"/>.
        /// </summary>
        TCP,

        /// <summary>
        /// A UDP connection type. Used by <see cref="UDPConnection"/>.
        /// </summary>
        UDP,

        //We may support others in future such as SSH, FTP, SCP etc.
    }
}