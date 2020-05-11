// INFORM request message PDU.
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
 * Date: 2008/8/3
 * Time: 15:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;

namespace futurocom.snmp
{
    /// <summary>
    /// INFORM request PDU.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pdu")]
    [Serializable]
    public class InformRequestPdu : TrapV2Pdu
    {
        /// <summary>
        /// Creates a <see cref="InformRequestPdu"/> instance with all content.
        /// </summary>
        /// <param name="requestId">The request id.</param>
        /// <param name="enterprise">Enterprise</param>
        /// <param name="time">Time stamp</param>
        /// <param name="variables">Variables</param>
        [CLSCompliant(false)]
        public InformRequestPdu(
            IPAddress senderIp,
            int requestId, 
            ObjectIdentifier enterprise, 
            uint time, 
            IList<Variable> variables)
            :base ( senderIp, requestId, enterprise, time, variables)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InformRequestPdu"/> class.
        /// </summary>    
        /// <param name="stream">The stream.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "temp1")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "temp2")]
        public InformRequestPdu(EndPoint sourceEndPoint, Stream stream)
            :base(sourceEndPoint, stream)
        {
            
        }

        

        /// <summary>
        /// Type code.
        /// </summary>
        public override SnmpType TypeCode
        {
            get { return SnmpType.InformRequestPdu; }
        }

       
    }
}
