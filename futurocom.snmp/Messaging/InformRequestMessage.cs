// INFORM request message type.
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
 * Time: 15:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using futurocom.snmp.Security;
using System.Net;

namespace futurocom.snmp.Messaging
{
    /// <summary>
    /// INFORM request message.
    /// </summary>
    [Serializable]
    public class InformRequestMessage : TrapV2Message
    {
        private readonly byte[] _bytes;

        /// <summary>
        /// Creates a <see cref="InformRequestMessage"/> with all contents.
        /// </summary>
        /// <param name="requestId">The request id.</param>
        /// <param name="version">Protocol version.</param>
        /// <param name="community">Community name.</param>
        /// <param name="enterprise">Enterprise.</param>
        /// <param name="time">Time ticks.</param>
        /// <param name="variables">Variables.</param>
        [CLSCompliant(false)]
        public InformRequestMessage(int requestId, IPAddress senderIp, VersionCode version, OctetString community, ObjectIdentifier enterprise, uint time, IList<Variable> variables)
            :base(requestId, senderIp, version, community, enterprise, time, variables )
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="InformRequestMessage"/> class.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="messageId">The message id.</param>
        /// <param name="requestId">The request id.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="enterprise">The enterprise.</param>
        /// <param name="time">The time.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="privacy">The privacy provider.</param>
        /// <param name="maxMessageSize">Size of the max message.</param>
        /// <param name="report">The report.</param>
        [CLSCompliant(false)]
        public InformRequestMessage(
            VersionCode version, 
            IPAddress senderIp,
            int messageId, 
            int requestId, 
            OctetString userName, 
            ObjectIdentifier enterprise, 
            uint time, 
            IList<Variable> variables, 
            IPrivacyProvider privacy, 
            int maxMessageSize, 
            ISnmpMessage report)
            
            :base(
            version, 
            senderIp, 
            messageId, 
            requestId, 
            userName, 
            enterprise, 
            time,
            variables, 
            privacy, 
            maxMessageSize)
        {
            if (userName == null)
            {
                throw new ArgumentNullException("userName");
            }
            
            if (variables == null)
            {
                throw new ArgumentNullException("variables");
            }
            
            if (version != VersionCode.V3)
            {
                throw new ArgumentException("only v3 is supported", "version");
            }

            if (enterprise == null)
            {
                throw new ArgumentNullException("enterprise");
            }

            if (report == null)
            {
                throw new ArgumentNullException("report");
            }
            
            if (privacy == null)
            {
                throw new ArgumentNullException("privacy");
            }


            Header = new Header(new Integer32(messageId), new Integer32(maxMessageSize), privacy.ToSecurityLevel() | Levels.Reportable);
            var parameters = report.Parameters;
            var authenticationProvider = Privacy.AuthenticationProvider;
            Parameters = new SecurityParameters(
                parameters.EngineId,
                parameters.EngineBoots,
                parameters.EngineTime,
                userName,
                authenticationProvider.CleanDigest,
                Privacy.Salt);
            var pdu = new InformRequestPdu(
                senderIp,
                requestId,
                enterprise,
                time,
                variables);
            var scope = report.Scope;
            Scope = new Scope(scope.ContextEngineId, scope.ContextName, pdu);

            authenticationProvider.ComputeHash(Version, Header, Parameters, Scope, Privacy);
            _bytes = this.PackMessage().ToBytes();
        }

        internal InformRequestMessage(
            VersionCode version, 
            IPEndPoint sourceEndPoint,
            Header header, 
            SecurityParameters parameters, 
            Scope scope, 
            IPrivacyProvider privacy)
            :base(version, sourceEndPoint.Address, header, parameters, scope, privacy)
        {
            SourceEndPoint = sourceEndPoint;
        }

        public IPEndPoint SourceEndPoint { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="objects">The objects.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        [CLSCompliant(false)]
        public override string ToString(IObjectRegistry objects)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "INFORM request message: time stamp: {0}; community: {1}; enterprise: {2}; varbind count: {3}",
                TimeStamp.ToString(CultureInfo.InvariantCulture),
                this.Community(),
                Enterprise.ToString(objects),
                this.Variables().Count.ToString(CultureInfo.InvariantCulture));
        }
    }
}
