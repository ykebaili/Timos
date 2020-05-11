// Walk mode enum.
// Copyright (C) 2008-2010 Malcolm Crowe, Lex Li, and other contributors.
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/7/30
 * Time: 19:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace futurocom.snmp.Messaging
{
    using System;
    
    /// <summary>
    /// Walk mode.
    /// </summary>
    [Serializable]
    public enum WalkMode
    {
        /// <summary>
        /// Default mode walk to the end of MIB view.
        /// </summary>
        Default = 0,
        
        /// <summary>
        /// In this mode, walk within subtree.
        /// </summary>
        WithinSubtree = 1
    }
}
